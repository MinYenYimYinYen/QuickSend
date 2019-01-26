using Microsoft.Office.Interop.Outlook;
using QuickSend_AppLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuickSend.GlobalObjects
{
	public abstract class AbstractAttachment : Button
	{

		public AbstractAttachment()
		{
			this.Command = AttachCommand;
		
		}

		public ICommand	AttachCommand=>new Command((param)=>
		{//Command Logic
			Attach();
		}, (param) =>
		{//Code to check if button is active
			return CanAttach();
		});

		public virtual void Attach()
		{
			NewMail.Attachments.Add(FileInfo);
		}
		public abstract bool CanAttach();

		public virtual FileInfo FileInfo { get; set; }

		public MailItem NewMail { get; private set; }
	}
}
