using QuickSend_AppLayer.Calc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuickSend;
using Microsoft.Office.Interop.Outlook;
using Exception = System.Exception;
using QuickSend_AppLayer.Infrastructure;
using QuickSend.Infrastructure;
using System.Windows;

namespace QuickSend_AppLayer.Templates
{
	public abstract class AbstractTemplate : IEmailTemplate, INotifyPropertyChanged
	{




		public abstract string GetSubject();


	public abstract string GetBody();


		public abstract  string Title { get;  }

		public abstract ObservableCollection<Input> RequiredInputs { get; }

		public MailItem Message { get; private set; }

		public ICommand TemplateCreate => new Command((param) =>
			{//Code to run
				try
				{
					Message = NewEmail.Get().Message;
					Subject = GetSubject();
					Body = GetBody();
					AssignSubject.Execute(Subject);
					AssignBody.Execute(Body);
					Message.Display(true);

					
				}
				catch (Exception ex)
				{
					if(ex.Message == "Outlook can't do this because a dialog box is open. Please close it and try again.")
					{
						MessageBox.Show("Close or discard the current email before creating a new one.");
					}
					else throw ex;
				}
			}, (param) =>
			{//Code to check if button is active
				if (NewEmail.Get().CanDispose()||Reply.Get().CanDispose())
				{ return false; }
				
				return CanCreateTemplate();	
			});

		public ICommand DiscardNewMessage => new Command((param) =>
		{
			var newMail = NewEmail.Get();
			if(newMail.CanDispose()) newMail.Dispose();

			var reply = Reply.Get();
			if (reply.CanDispose()) reply.Dispose();

		}, (param) =>
		{
			if (NewEmail.Get().CanDispose()||Reply.Get().CanDispose())
			{ return true; }
			else return false;
		});


		public abstract bool CanCreateTemplate();

		private string subject;
		public string Subject
		{
			get => subject;
			set
			{
				subject = value;
				OnPropertyChanged(nameof(Subject));
			}
		}

		private string body;
		public string Body
		{
			get => body;
			set
			{
				body = value;
				OnPropertyChanged(nameof(Body));
			}
		}

		public ICommand AssignSubject => new Command((param) =>
		{//Command Logic
			Message.Subject = param.ToString();

		}, (param) =>
		{//Code to check if button is active
			if (Message != null && param != null) return true;
			else return false;
		});

		public ICommand AssignBody => new Command((param) =>
		{//Command Logic
			Message.Body = param.ToString();

		}, (param) =>
		{//Code to check if button is active
			if (Message != null && param != null) return true;
			else return false;
		});

		public ICommand TemplateReply  => new Command((param) =>
		{//Code to run
			try
			{
				Message = Reply.Get().Message;
				Body = GetBody();
				Body = Body + Environment.NewLine + Message.Body;
				AssignBody.Execute(Body);
				Message.Display(true);
			}
			catch (Exception ex)
			{
				if (ex.Message == "Outlook can't do this because a dialog box is open. Please close it and try again.")
				{
					MessageBox.Show("Close or discard the current email before creating a new one.");
				}
				else throw ex;
			}
		}, (param) =>
		{//Code to check if button is active
			if (NewEmail.Get().CanDispose())
			{ return false; }

			return CanCreateTemplate();
		});

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
