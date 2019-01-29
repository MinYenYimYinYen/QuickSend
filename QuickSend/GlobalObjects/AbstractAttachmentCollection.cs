using QuickSend.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.GlobalObjects
{
	public abstract class AbstractAttachmentCollection<T> : ObservableCollection<T> where T : AbstractAttachment
	{
		public AbstractAttachmentCollection()
		{
			Refresh(string.Empty);
		}

		protected void Refresh(string search)
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
					Add(GetNew( file));
				}
			}
		}

		protected abstract T GetNew(FileInfo file);

		public abstract string FolderPath { get; set; }

		private string searchString = "";
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
