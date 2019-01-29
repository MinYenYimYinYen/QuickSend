using QuickSend.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.GlobalObjects
{
	public class Diagrams : ObservableCollection<Diagram>, INotifyPropertyChanged
	{
		public Diagrams()
		{
			Refresh(string.Empty);
		}

		private void Refresh(string search)
		{
			Clear();
			if (string.IsNullOrWhiteSpace(search))
			{
				search = "";
			}

			if (!string.IsNullOrWhiteSpace(FolderPath))
			{
				DirectoryInfo dir = new DirectoryInfo(FolderPath);
				FileInfo[] files = dir.GetFiles("*.pdf");

				foreach (FileInfo file in files
					.Where(f => f.Name.ToLower().Trim()
					.Contains(SearchString.ToLower().Trim())))
				{
					Add(new Diagram
					{
						FileInfo = file
					});
				}
			}
		}

		public string FolderPath
		{
			get => Settings.Default.DiagramFolder;
			set
			{
				Settings.Default.DiagramFolder = value;
				Settings.Default.Save();
				Refresh(SearchString);
			}
		}

		private  string searchString="";
		public string SearchString
		{
			get => searchString;
			set
			{
				searchString = value;
				Refresh(value);
			}
		}


	}
}
