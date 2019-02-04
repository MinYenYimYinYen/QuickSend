using QuickSend.WPF.AppLayer.TemplateObjects;
using QuickSend.WPF.AppLayer.TemplateObjects.VariableSets;
using QuickSend.WPF.AppLayer.Templates.CancelSave.WhyResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSend.WPF.AppLayer.Templates.CancelSave.WhyResponse
{
	public class WhyTemplate : ITemplate<Why>
	{
		public WhyTemplate(ISubjectBuilder<Why> subjectBuilder,IBodyBuilder<Why> bodyBuilder)
		{
			SubjectBuilder = subjectBuilder;
			BodyBuilder = bodyBuilder;
		}
		public ISubjectBuilder<Why> SubjectBuilder { get; private set; }
		public IBodyBuilder<Why> BodyBuilder { get; private set; }
		
	}
}
