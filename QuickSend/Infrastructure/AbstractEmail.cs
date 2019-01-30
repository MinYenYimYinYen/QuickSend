using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.Infrastructure
{
	public abstract class AbstractEmail
	{
		public MailItem Message { get; set; }
		public  void Display()
		{
			Message.Display();
		}

		public bool CanDispose()
		{
			try
			{
				Inspector x = Message.GetInspector;
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}

		public void Dispose()
		{
			Inspector x = Message.GetInspector;
			Message.GetInspector.Close(SaveMode: OlInspectorClose.olDiscard);
			Message.Close(SaveMode: OlInspectorClose.olDiscard);
			Message = null;
		}
	}
}
