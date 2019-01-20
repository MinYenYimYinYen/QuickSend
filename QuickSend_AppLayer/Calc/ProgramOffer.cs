using System;

namespace QuickSend.Models
{
	public class ProgramOffer
	{
		public double PricePerApp { get; set; }
		public double PricePerAppPPY => Math.Round(PricePerApp * (1 - PrePayPerc),2);
		public int FreeAppCount { get; set; }

		public int AppCount { get; set; }
		public int PaidAppCount => AppCount - FreeAppCount;

		public double GrossPrice => PaidAppCount * PricePerApp;
		public double GrossPricePPY => GrossPrice * (1 - PrePayPerc);
		public double PrePaySavings => PaidAppCount * (PricePerApp - PricePerAppPPY);

		public double PrePayPerc { get; set; }		

		public double TaxPercent { get; set; }
		public double TaxDollars
		{
			get
			{
				double tax = 0;
				for(int i = 0; i < PaidAppCount; i++)
				{
					tax += Math.Round(TaxPercent * PricePerApp, 2);
				}
				return tax;
			}
		}
		public double TaxDollarsPPY
		{
			get
			{
				double tax = 0;
				for (int i = 0; i < PaidAppCount; i++)
				{
					tax += Math.Round(TaxPercent * PricePerAppPPY, 2);
				}
				return tax;
			}
		}

		public double Total => GrossPrice + TaxDollars;
		public double TotalPPY => GrossPricePPY - PrePaySavings + TaxDollarsPPY;


	}
}
