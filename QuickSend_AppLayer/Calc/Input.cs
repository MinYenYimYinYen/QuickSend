using QuickSend_AppLayer.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend_AppLayer.Calc
{
	public class Input
	{
		public IEmailTemplate Instance { get; set; }
		public PropertyInfo Property { get; set; }
		public string Label { get; set; }
		public object Value
		{
			get
			{
				return Property.GetValue(Instance);
			}
			set
			{
				Property.SetValue(Instance, value);
			}
		}

	}
}
