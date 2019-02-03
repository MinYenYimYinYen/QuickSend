using QuickSend_AppLayer.Calc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visibility = System.Windows.Visibility;

namespace QuickSend.Templates.CancelSave
{
	public class PriceObjection : PriceOrService
	{
		private bool _offerRemoveSevices;
		private bool _offerLowerPrice;

		public PriceObjection()
		{
			ServicesToRemove = new ObservableCollection<ServiceToRemove>();
		}

		//private void PriceObjection_OfferRemoveServicesChanged(object sender, Visibility e)
		//{
		//	Input prop = Inputs
		//		.Where(i => i.Property.Name == nameof(OfferRemoveSevices))
		//		.Single();
		//	prop.Value = e;
		//}


		//private void PriceObjection_OfferLowerPriceChanged(object sender, Visibility e)
		//{
		//	Input prop = Inputs
		//		.Where(i => i.Property.Name == nameof(OfferRemoveSevices))
		//		.Single();
		//	prop.Value = e;
		//}

		public event EventHandler<Visibility> OfferLowerPriceChanged;
		public void OnOfferLowerPriceChanged(Visibility visibility)
		{
			OfferLowerPriceChanged?.Invoke(this, visibility);
		}

		public event EventHandler<Visibility> OfferRemoveServicesChanged;
		public void OnOfferRemoveServicesChanged(Visibility visibility)
		{
			OfferRemoveServicesChanged?.Invoke(this, visibility);
		}



		public override string Title => "Cancel Save: Better Price";


		public bool OfferRemoveSevices
		{
			get => _offerRemoveSevices;
			set
			{
				_offerRemoveSevices = value;
				Visibility vis;
				if (value)
				{
					vis = Visibility.Visible;
				}
				else
				{
					vis = Visibility.Collapsed;
				}
				_offerRemoveSevices = value;
				OnOfferRemoveServicesChanged(vis);
			}
		}
		public ObservableCollection<ServiceToRemove> ServicesToRemove { get; set; }

		public bool OfferLowerPrice
		{
			get => _offerLowerPrice;
			set
			{
				_offerLowerPrice = value;
				Visibility vis;
				if (value)
				{
					vis = Visibility.Visible;
				}
				else
				{
					vis = Visibility.Collapsed;
				}
				_offerLowerPrice = value;
				OnOfferLowerPriceChanged(vis);
			}
		}
		public double AppPriceReduction { get; set; }
		public int AppCount { get; set; }

		public new ObservableCollection<PriceObjectionInput> Inputs
		{
			get
			{
				PriceObjectionInput removeServicesInput = new PriceObjectionInput
					(this, GetType().GetProperty(nameof(OfferRemoveSevices)), "Remove Services");

				PriceObjectionInput offerLowerPrice = new PriceObjectionInput
					(this, GetType().GetProperty(nameof(OfferLowerPrice)), "Offer Lower Price");
				PriceObjectionInput servicesToRemove = new PriceObjectionInput
					(this, GetType().GetProperty(nameof(ServicesToRemove)), "Services To Remove")
				{
					MasterInput = removeServicesInput,
					Visibility= Visibility.Collapsed.ToString()
				};

				PriceObjectionInput appPriceReduction = new PriceObjectionInput
					(this, GetType().GetProperty(nameof(AppPriceReduction)), "Reduction Amount")
				{
					MasterInput = offerLowerPrice,
					Visibility = Visibility.Collapsed.ToString()
				};

				PriceObjectionInput appCount = new PriceObjectionInput
					(this, GetType().GetProperty(nameof(AppCount)), "App Count")
				{
					MasterInput = offerLowerPrice,
					Visibility = Visibility.Collapsed.ToString()
				};

				ObservableCollection<PriceObjectionInput> collection = new ObservableCollection<PriceObjectionInput>
				{
					removeServicesInput,
					servicesToRemove,
					offerLowerPrice,
					appPriceReduction,
					appCount
				};

				return collection;
			}
		}

		public override string GetBody()
		{
			double savings = 0;
			StringBuilder str = new StringBuilder();

			str.Append($"The program you currently have with us is one of our higher end programs.  It's a good program, but if it's too expensive at this point we should take a look at our options.  Throwing in the towel could mean losing much of the progress you've made.   We should be able to put something together that'll be easier on the bank account and still maintain a good looking lawn.\n  ");

			if (OfferRemoveSevices)
			{
				int i = 0;

				int servCount = GetServicesToRemove().Count();
				str.Append("If we remove the ");

				foreach (ServiceToRemove serviceToRemove in GetServicesToRemove())
				{
					i++;

					str.Append(serviceToRemove.Service);
					savings += serviceToRemove.Price;

					if (servCount > 2 && i + 1 < servCount)
					{
						str.Append(", ");
					}

					if (i + 1 == servCount)
					{
						str.Append(" and ");
					}
				}
				str.Append($", you'd be saving {savings.ToString("$#.00")}.  ");
			}

			if (OfferLowerPrice)
			{
				savings += AppPriceReduction * AppCount;
				str.Append($"If I lowered your price per application by {AppPriceReduction.ToString("$#.00")} per visit, you'd be saving {savings.ToString("$#.00")}");
			}

			str.Append("\nI'd like the chance to discuss this with you.  If you could give me a call or reply back that would be great!\n");
			str.Append("I appreciate your business!\n\n");
			str.Append("Sincerely,\nDarla");
			return str.ToString();
		}

		public override bool CanBuildTemplate()
		{
			bool eval;
			if (OfferRemoveSevices)
			{
				eval = GetServicesToRemove().Count() > 0;
				if (eval == false)
				{
					return false;
				}
			}

			if (OfferLowerPrice)
			{
				eval = AppPriceReduction > 0;
				if (eval == false)
				{
					return false;
				}

				eval = AppCount > 0;
				if (eval == false)
				{
					return false;
				}
			}

			return true;
		}

		private IEnumerable<ServiceToRemove> GetServicesToRemove()
		{

			return ServicesToRemove
				.Where(s => string.IsNullOrWhiteSpace(s.Service) == false)
				.Where(s => s.Price != 0);
		}
	}
}
