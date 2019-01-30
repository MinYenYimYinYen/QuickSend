using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.Infrastructure
{
	public class Reply:AbstractEmail
	{
		private Reply()
		{
			if(ThisAddIn.SelectedMail != null)
			{
				Message = ((MailItem)(ThisAddIn.SelectedMail)).Reply();
			}			
		}

		private static Reply instance;

		public static Reply Get()
		{
			if (instance == null)
			{
				instance = new Reply();
			}
			return instance;
		}
	}
}
