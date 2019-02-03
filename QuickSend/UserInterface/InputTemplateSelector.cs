using QuickSend_AppLayer.Calc;
using QuickSend_AppLayer.Templates;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuickSend.UserInterface
{
	public class InputTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			FrameworkElement elem = container as FrameworkElement;
			if (elem == null)
			{
				return null;
			}


			if ((item as Input).Value.GetType()==typeof(bool))
			{
				var x = elem.FindResource("BoolDataTemplate") as DataTemplate;
				return elem.FindResource("BoolDataTemplate") as DataTemplate;
			}
			if ((item as Input).Value.GetType() == typeof(string))
			{
				return elem.FindResource("StringDataTemplate") as DataTemplate;
			}
			if ((item as Input).Value.GetType() == typeof(double))
			{
				return elem.FindResource("StringDataTemplate") as DataTemplate;
			}



			return null;

		}
	}
}
