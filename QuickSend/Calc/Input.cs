using QuickSend.Templates.CancelSave;
using QuickSend_AppLayer.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vis = System.Windows.Visibility;

namespace QuickSend_AppLayer.Calc
{
	public class Input : INotifyPropertyChanged
	{

		private  string _visibility;

		public Input() { }
		public Input(PriceObjection instance, PropertyInfo propertyInfo, string label,Vis visibility)
		{
			Instance = instance;
			Property = propertyInfo;
			Label = label;
			Visibility = visibility.ToString();
		}

		private void Instance_OfferLowerPriceChanged(object sender, Vis e)
		{
			Visibility = e.ToString();
		}

		public Input MasterInput { get; set; }
		public IEmailTemplate Instance { get; set; }
		public PropertyInfo Property { get; set; }
		public string Label { get; set; }
		//public bool IsVisible { get => _isVisible;
		//	set
		//	{
		//		_isVisible = value;
		//		OnPropertyChanged(nameof(Visibility));
		//	}
		//}

		//public string Visibility => IsVisible ? Vis.Visible.ToString() : Vis.Collapsed.ToString();

		public string Visibility
		{
			get => _visibility;
			set {
				_visibility = value;
				OnPropertyChanged(nameof(Visibility));
			}
		}


		public object Value
		{
			get => Property.GetValue(Instance);
			set => Property.SetValue(Instance, value);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


	}
}
