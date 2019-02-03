using QuickSend.Calc;
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
	public class Input<T> : Input where T:Type
	{
		public Input(PriceObjection instance, PropertyInfo propertyInfo, string label) : base(instance, propertyInfo, label)
		{
		}
		public Input()		{		}

		public T Value
		{
			get => Property.GetValue(Instance) as T;
			set => Property.SetValue(Instance, value);
		}

		public Input<T> MasterInput { get; set; }
	}


	public  class Input: INotifyPropertyChanged 
	{

		private  string _visibility;

		public Input() { }
		public Input(PriceObjection instance, PropertyInfo propertyInfo, string label)
		{
			Instance = instance;
			Property = propertyInfo;
			Label = label;
		}

		private void Instance_OfferLowerPriceChanged(object sender, Vis e)
		{
			Visibility = e.ToString();
		}


		public IEmailTemplate Instance { get; set; }
		public PropertyInfo Property { get; set; }
		public string Label { get; set; }


		public string Visibility
		{
			get => _visibility;
			set {
				_visibility = value;
				OnPropertyChanged(nameof(Visibility));
			}
		}




		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


	}
}
