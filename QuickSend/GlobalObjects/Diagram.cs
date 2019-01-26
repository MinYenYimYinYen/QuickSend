using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.GlobalObjects
{
	public class Diagram : AbstractAttachment
	{

		public override bool CanAttach()
		{
			return true;
		}

	}
}
