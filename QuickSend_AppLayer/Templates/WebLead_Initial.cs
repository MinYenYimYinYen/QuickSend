using QuickSend_AppLayer.Calc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend_AppLayer.Templates
{
	public class WebLead_Initial : IEmailTemplate
	{
		public double PricePerApp { get; }
		public string Name { get; }


		public WebLead_Initial(double pricePerApp, string name)
		{
			PricePerApp = pricePerApp;
			Name = name;
		}

		public WebLead_Initial() { }

		public string GetSubject()
		{
			return $"{Name}, Thanks for your interest in Spring-Green!";
		}

		public string GetBody()
		{
			ProgramCalc calc = new ProgramCalc
			{
				PricePerApp = PricePerApp,
				PrePayPerc = .05,
				TaxPercent = .07,
				AppCount = 6,
				FreeAppCount = 1
			};

			StringBuilder str = new StringBuilder();
			str.Append($"Dear {Name}," + Environment.NewLine +
				$"Thank you for showing interest in our company.  Based on the information you provided, I've prepared an estimate for your 2019 lawn care program." + Environment.NewLine +
				$"Throughout the season, we do 6 applications of fertilizer/weed control.  Your price per application is {calc.PricePerApp}.  As a new customer we offer the last application FREE!  We offer a 5% discount on the entire season if you choose to prepay.  If you take us up on this deal, your total cost on the season would be {calc.TotalPPY}." + Environment.NewLine +
				$"I'd like to answer any questions you have about our service.  I plan to give you a call as well, but I wanted to get you this email in case we don't get a chance to talk." + Environment.NewLine +
				$"Thanks Again!" + Environment.NewLine +
				$" -Darla");
			return str.ToString();
		}

		public override string ToString()
		{
			return "Web Lead: Initial Email";
		}
		public ObservableCollection<Input> RequiredInputs
		{
			get
			{
				return new ObservableCollection<Input>
				{
					new Input{Label="AppPrice"},
					new Input{Label="Name"},

				};
			}
		}
	}
}
