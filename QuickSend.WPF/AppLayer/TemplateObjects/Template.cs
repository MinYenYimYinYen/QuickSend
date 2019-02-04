using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.WPF.AppLayer.TemplateObjects
{
	public interface ITemplate
	{
		IMessage Message { get; set; }

	}
}
