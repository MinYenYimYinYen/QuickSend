using QuickSend.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.GlobalObjects
{
	public class Inserts : AbstractAttachmentCollection<Insert>
	{
		public override string FolderPath
		{
			get => Settings.Default.InsertFolder;
			set
			{
				Settings.Default.InsertFolder = value;
				Settings.Default.Save();
				Refresh(SearchString);
			}
		}

		protected override Insert GetNew(FileInfo file)
		{
			return new Insert { FileInfo = file };
		}
	}
}
