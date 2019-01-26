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

		private void Subscribe()
		{
			Email.Unload += Email_Unload;
		}
		private void Email_Unload()
		{
			instance = null;
		}

		private static NewEmail instance;

		public static NewEmail Get()
		{
			if (instance == null)
			{
				instance = new NewEmail();
				instance.Subscribe();
			}
			return instance;
		}

		public static NewEmail Display()
		{
			var eml = Get();
			eml.Email.Display();
			return eml;
		}

		public static void Kill()
		{
			
			instance = null;
		}

		public MailItem Email { get; set; }


	}
}
