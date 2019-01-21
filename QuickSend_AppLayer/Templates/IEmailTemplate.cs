using QuickSend_AppLayer.Calc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend_AppLayer.Templates
{
	public interface IEmailTemplate
	{
		string GetSubject();
		string GetBody();
		ObservableCollection<Input> RequiredInputs { get;  }


	}
}
