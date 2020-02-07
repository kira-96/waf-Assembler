using System.ComponentModel.Composition;
using System.Waf.Presentation;
using Common.Applications.Services;

namespace Shell.Presentation.Services
{
    [Export(typeof(IPresentationService))]
    internal class PresentationService : IPresentationService
    {
        public void Initialize()
        {
            ResourceHelper.AddToApplicationResources(typeof(PresentationService).Assembly, "Presentation/Resources/ImageResources.xaml");
        }
    }
}
