using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.WPF.AppLayer.TemplateObjects
{
	public interface TemplateInput<T>
	{
		PropertyInfo PropertyInfo { get; set; }
		string Label { get; set; }
		T Value { get; set; }
	}

}
