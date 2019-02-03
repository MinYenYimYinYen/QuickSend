using QuickSend_AppLayer.Calc;
using QuickSend_AppLayer.Templates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.Templates
{
	public class PriceOrService : AbstractTemplate
	{

		public string Name { get; set; }

		public override string Title => "Renewal: Cancel Reply";

		public override ObservableCollection<Input> Inputs =>
			new ObservableCollection<Input>
			{
				new Input
				{
					Instance = this,
					Property = GetType().GetProperty(nameof(Name)),
					Label=nameof(Name)
				}
			};

		public override bool CanBuildTemplate()
		{
			return !string.IsNullOrWhiteSpace(Name);
		}

		public override string GetBody()
		{
			return $"Hello {Name},{Environment.NewLine}" +
				$"I want to confirm that I've received your request to cancel your account. I'll go ahead and cancel your account.  I was hoping to get more detail on why you are cancelling. Was there a problem with the service, or is it a price issue? In any case, it may benefit us both if we could talk about it. We'd love the chance to correct any issues we have and we don't mind negotiating on price.{Environment.NewLine}" +
		$"We appreciate your business. Feel free to contact me if there is anything you think I can help you with.{Environment.NewLine}" +
	$"Sincerely,{Environment.NewLine}" +
 $"Darla";
		}

		public override string GetSubject()
		{
			return $"Cancellation Request";
		}
	}
}
