using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.Infrastructure
{
	public class NewEmail
	{
		private NewEmail()
		{
			Email = (MailItem)(ThisAddIn.ThisApp.CreateItem(OlItemType.olMailItem));
		}

		private static NewEmail instance;
		public MailItem Email { get; set; }

		public static NewEmail Get()
		{
			if (instance == null)
			{
				instance = new NewEmail();
			}
			return instance;
		}

		public static void Display() => Get().Email.Display();


		public static bool CanDispose()
		{
			try
			{
				var x = instance.Email.GetInspector;
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}

		internal static void Dispose()
		{
			var x = instance.Email.GetInspector;
			instance.Email.GetInspector.Close(SaveMode: OlInspectorClose.olDiscard);
			instance.Email.Close(SaveMode: OlInspectorClose.olDiscard);
			instance = null;
		}
	}
}
