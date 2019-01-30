using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.Infrastructure
{
	public class NewEmail:AbstractEmail
	{
		private NewEmail()
		{
			Message = (MailItem)(ThisAddIn.ThisApp.CreateItem(OlItemType.olMailItem));
		}

		private static NewEmail instance;

		public static NewEmail Get()
		{
			if (instance == null)
			{
				instance = new NewEmail();
			}
			return instance;
		}

	}
}
