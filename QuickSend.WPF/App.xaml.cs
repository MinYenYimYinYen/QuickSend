using QuickSend.WPF.AppLayer.TemplateObjects;
using QuickSend.WPF.AppLayer.TemplateObjects.VariableSets;
using QuickSend.WPF.AppLayer.Templates.CancelSave.WhyResponse;
using QuickSend.WPF.AppLayer.Templates.VariableSets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace QuickSend.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// https://www.wpftutorial.net/referencearchitecture.html
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			IUnityContainer container = new UnityContainer();

			container.RegisterType<IGreeting, Greeting>();

			container.RegisterType<ITemplate<Why>, WhyTemplate>();
			container.RegisterType<ISubjectBuilder<Why>, WhySubject>();
			container.RegisterType<IBodyBuilder<Why>, WhyBody>();

			MainWindow mainWindow = container.Resolve<MainWindow>();
			mainWindow.Show();
		}
	}
}
