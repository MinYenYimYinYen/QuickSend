using QuickSend_AppLayer.Templates;
using System;
using System.Windows.Input;


//https://www.loginworks.com/blogs/create-vsto-add-outlook-2013-2016/

namespace QuickSend
{
	public partial class ThisAddIn
	{
		private void ThisAddIn_Startup(object sender, System.EventArgs e)
		{

		}




		private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
		{
			// Note: Outlook no longer raises this event. If you have code that 
			//    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
		}

		protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
		{
			return new Ribbon();
		}

		public static ICommand AssignSubject => new Command((param) =>
		{//Code to run

			string subject = param.ToString();

		}, (param) =>
		{//Code to check if button is active
			throw new NotImplementedException();
		});


		#region VSTO generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(ThisAddIn_Startup);
			this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
		}

		#endregion
	}
}
