using System.ComponentModel.Composition;
using System.Waf.Applications;
using SimplePlugin.Applications.ViewModels;

namespace SimplePlugin.Applications.Controllers
{
    [Export(typeof(IModuleController))]
    internal class PluginController : IModuleController
    {
        private readonly PluginViewModel pluginViewModel;

        [ImportingConstructor]
        public PluginController(PluginViewModel pluginViewModel)
        {
            this.pluginViewModel = pluginViewModel;
        }

        public void Initialize()
        {
        }

        public void Run()
        {
            pluginViewModel.Show();
        }

        public void Shutdown()
        {
            pluginViewModel.Close();
        }
    }
}
