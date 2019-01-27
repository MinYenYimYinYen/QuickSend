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

		public MailItem NewMail { get; private set; }

		public ICommand TemplateBuild => new Command((param) =>
			{//Code to run
				try
				{
					NewMail = NewEmail.Get().Email;
					Subject = GetSubject();
					Body = GetBody();
					AssignSubject.Execute(Subject);
					AssignBody.Execute(Body);
					NewMail.Display(true);
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
				if (NewEmail.CanDispose())
				{ return false; }
				
				return CanBuildTemplate();	
			});

		public ICommand DiscardMessage => new Command((param) =>
		{
			NewEmail.Dispose();
		}, (param) =>
		{
			if (NewEmail.CanDispose())
			{ return true; }
			else return false;
		});


		public abstract bool CanBuildTemplate();

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
			NewMail.Subject = param.ToString();

		}, (param) =>
		{//Code to check if button is active
			if (NewMail != null && param != null) return true;
			else return false;
		});

		public ICommand AssignBody => new Command((param) =>
		{//Command Logic
			NewMail.Body = param.ToString();

		}, (param) =>
		{//Code to check if button is active
			if (NewMail != null && param != null) return true;
			else return false;
		});




		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
