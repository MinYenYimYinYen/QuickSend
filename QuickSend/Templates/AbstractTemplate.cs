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
				Subject = GetSubject();
				Body = GetBody();
				try
				{
					NewMail = (MailItem)QuickSend.ThisAddIn.ThisApp.CreateItem(OlItemType.olMailItem);
					NewMail.Display(true);
				}
				catch (Exception)
				{

					NewMail.Close(OlInspectorClose.olDiscard);
					NewMail = null;
				}
				
			}, (param) =>
			{//Code to check if button is active
				return CanBuildTemplate();
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
