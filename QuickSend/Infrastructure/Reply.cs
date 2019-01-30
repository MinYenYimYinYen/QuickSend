using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.Infrastructure
{
	public class Reply
	{
		private Reply()
		{
			if(ThisAddIn.SelectedMail != null)
			{
				Message = ((MailItem)(ThisAddIn.SelectedMail)).Reply();
			}
			
		}

		private static Reply instance;
		public MailItem Message { get; set; }

		public static Reply Get()
		{
			if (instance == null)
			{
				instance = new Reply();
			}
			return instance;
		}

		public static void Display() => Get().Message.Display();


		public static bool CanDispose()
		{
			try
			{
				var x = instance.Message.GetInspector;
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}

		internal static void Dispose()
		{
			var x = instance.Message.GetInspector;
			instance.Message.GetInspector.Close(SaveMode: OlInspectorClose.olDiscard);
			instance.Message.Close(SaveMode: OlInspectorClose.olDiscard);
			instance = null;
		}
	}
}
