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
	public class WebLeadTemplate : AbstractTemplate
	{
		public string PricePerApp { get; set; }
		public string Name { get; set; }

		public override string GetSubject()
		{
			return $"{Name}, Thanks for your interest in our company";
		}

		public override string GetBody()
		{
			ProgramCalc calc = new ProgramCalc
			{
				PricePerApp = Convert.ToDouble(PricePerApp),
				PrePayPerc = .05,
				TaxPercent = .07,
				AppCount = 6,
				FreeAppCount = 1
			};

			StringBuilder str = new StringBuilder();
			str.Append($"Dear {Name}," + Environment.NewLine +
				$"Thank you for showing interest in our company.  Based on the information you provided, I've prepared an estimate for your 2019 program." + Environment.NewLine +
				$"Throughout the season, we do 6 services.  Your price per application is {calc.PricePerApp.ToString("$#.00")}.  As a new customer we offer the last application FREE!  We offer a 5% discount on the entire season if you choose to prepay.  If you take us up on this deal, your total cost on the season would be {calc.TotalPPY.ToString("$#.00")}." + Environment.NewLine +
				$"I'd like to answer any questions you have about our service.  I plan to give you a call as well, but I wanted to get you this email in case we don't get a chance to talk." + Environment.NewLine +
				$"Thanks Again!" + Environment.NewLine +
				$" -Darla");
			return str.ToString();
		}

		public override string Title => "WebLead: Initial Response";

		public override ObservableCollection<Input> RequiredInputs => 
			new ObservableCollection<Input>
			{
				new Input
				{
					Instance =this,
					Property =GetType().GetProperty(nameof(PricePerApp)),
					Label ="AppPrice"
				},
				new Input
				{
					Instance =this,
					Property =GetType().GetProperty(nameof(Name)),
					Label ="Name"
				},
			};

		public override bool CanBuildTemplate()
		{
			try
			{
				Convert.ToDouble(PricePerApp);
			}
			catch (Exception)
			{ return false; }

			if
			(
				Convert.ToDouble(PricePerApp) > 0 &&
				!string.IsNullOrWhiteSpace(Name)
			)
			{ return true; }
			else { return false; }
		}
	}
}
