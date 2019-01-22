using QuickSend_AppLayer.Calc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuickSend_AppLayer.Templates
{
	public class WebLead_Initial : IEmailTemplate, INotifyPropertyChanged
	{
		public string PricePerApp { get; set; }
		public string Name { get; set; }


		public WebLead_Initial(string pricePerApp, string name)
		{
			PricePerApp = pricePerApp;
			Name = name;
		}

		public WebLead_Initial() { }

		public string GetSubject()
		{
			return $"{Name}, Thanks for your interest in our company";
		}

		public string GetBody()
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

		public override string ToString()
		{
			return "Web Lead: Initial Email";
		}
		public ObservableCollection<Input> RequiredInputs => new ObservableCollection<Input>
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

		public ICommand TemplateBuild => new Command(() =>
			{//Code to run
				Subject = GetSubject();
				Body = GetBody();
			}, () =>
			{//Code to check if button is active
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
			});

		private string subject;
		public string Subject
		{
			get => subject;
			set
			{
				subject = value;
				OnPropertyChanged(nameof(Subject));
			}
		}

		private string body;
		public string Body
		{
			get => body;
			set
			{
				body = value;
				OnPropertyChanged(nameof(Body));
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
