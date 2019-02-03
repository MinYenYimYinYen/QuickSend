using QuickSend_AppLayer.Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vis = System.Windows.Visibility;

namespace QuickSend.Templates.CancelSave
{
	public class PriceObjectionInput : Input
	{
		public PriceObjectionInput(PriceObjection instance, PropertyInfo propertyInfo, string label) : base(instance, propertyInfo, label)
		{
			instance.OfferLowerPriceChanged += Instance_OfferLowerPriceChanged;
			instance.OfferRemoveServicesChanged += Instance_OfferRemoveServicesChanged;
		}

		private void Instance_OfferRemoveServicesChanged(object sender, Vis e)
		{
			if (MasterInput != null && MasterInput.Property.Name == nameof(PriceObjection.OfferRemoveSevices))
			{
				if ((bool)MasterInput.Value == true)
				{
					this.Visibility = Vis.Visible.ToString();
				}
				else { this.Visibility = Vis.Collapsed.ToString(); }
			}
		}

		private void Instance_OfferLowerPriceChanged(object sender, Visibility e)
		{
			if (MasterInput != null && MasterInput.Property.Name == nameof(PriceObjection.OfferLowerPrice))
			{
				if ((bool)MasterInput.Value == true)
				{
					this.Visibility = Vis.Visible.ToString();
				}
				else { this.Visibility = Vis.Collapsed.ToString(); }
			}
		}
	}
}
