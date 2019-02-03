namespace QuickSend.Templates
{
	public interface IProgramQuote
	{
		int AppCount { get; set; }
		int FreeAppCount { get; set; }
		double PPYPercent { get; set; }
		string PricePerApp { get; set; }
		double TaxPercent { get; set; }
	}
}