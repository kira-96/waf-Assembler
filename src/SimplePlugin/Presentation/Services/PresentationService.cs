using System.ComponentModel.Composition;
using Common.Applications.Services;

namespace SimplePlugin.Presentation.Services
{
    [Export(typeof(IPresentationService))]
    internal class PresentationService : IPresentationService
    {
        public void Initialize()
        {
        }
    }
}
