using System.ComponentModel.Composition;
using System.Waf.Applications;
using SimplePlugin.Applications.Views;

namespace SimplePlugin.Applications.ViewModels
{
    [Export]
    internal class PluginViewModel : ViewModel<IPluginView>
    {
        [ImportingConstructor]
        public PluginViewModel(IPluginView view) : base(view)
        {
            DisplayName = "Simple Plugin Window";
        }

        public string DisplayName { get; set; }

        public void Show()
        {
            ViewCore.Show();
        }

        public void Close()
        {
            ViewCore.Close();
        }
    }
}
