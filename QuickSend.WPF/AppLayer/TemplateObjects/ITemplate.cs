using QuickSend.WPF.AppLayer.TemplateObjects.VariableSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.WPF.AppLayer.TemplateObjects
{
	public interface ITemplate { }
	public interface ITemplate<T>:ITemplate
	{
		ISubjectBuilder<T> SubjectBuilder { get; }
		IBodyBuilder<T> BodyBuilder { get; }
	}
}
