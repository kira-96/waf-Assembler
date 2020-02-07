using System.ComponentModel.Composition;
using System.Waf.Applications;
using Shell.Applications.ViewModels;

namespace Shell.Applications.Controllers
{
    [Export(typeof(IModuleController))]
    internal class ApplicationController : IModuleController
    {
        private readonly ShellViewModel shellViewModel;

        [ImportingConstructor]
        public ApplicationController(ShellViewModel shellViewModel)
        {
            this.shellViewModel = shellViewModel;
        }

        public void Initialize()
        {
        }

        public void Run()
        {
            shellViewModel.Show();
        }

        public void Shutdown()
        {
        }
    }
}
