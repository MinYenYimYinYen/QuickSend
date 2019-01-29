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
	public class AgroSheets : AbstractAttachmentCollection<AgroSheet>, INotifyPropertyChanged
	{
		public override string FolderPath
		{
			get => Settings.Default.AgroSheetFolder;
			set
			{
				Settings.Default.AgroSheetFolder = value;
				Settings.Default.Save();
				Refresh(SearchString);
			}
		}

		protected override AgroSheet GetNew(FileInfo file)
		{
			return new AgroSheet { FileInfo = file };
		}
	}
}
