using QuickSend.Templates;
using QuickSend.Templates.CancelSave;
using QuickSend_AppLayer.Templates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.UserInterface.Collections
{
    public class EmailTemplates:ObservableCollection<IEmailTemplate>
    {
		public EmailTemplates()
		{
			this.Add(new WebLeadTemplate());
			this.Add(new PriceOrService());
			this.Add(new PriceObjection());
		}
    }
}
