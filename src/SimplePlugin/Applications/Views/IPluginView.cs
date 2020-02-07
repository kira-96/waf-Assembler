using System.Waf.Applications;

namespace SimplePlugin.Applications.Views
{
    internal interface IPluginView : IView
    {
        void Show();

        void Close();
    }
}
