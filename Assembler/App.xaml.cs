using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Waf.Applications;
using System.Waf.Foundation;
using System.Windows;
using Common.Applications.Services;

namespace Assembler
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private readonly IList<string> ModuleAssemblies = new List<string>()
        {
            "Shell.dll",
            "SimplePlugin.dll",
        };

        private AggregateCatalog catalog;
        private CompositionContainer container;
        private IEnumerable<IModuleController> controllers;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            catalog = new AggregateCatalog();
            // Add the WpfApplicationFramework assembly to the catalog
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Model).Assembly));
            // Add the WafApplication assembly to the catalog
            // catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            // Load module assemblies as well. See App.config file.
            foreach (string moduleAssembly in ModuleAssemblies)
            {
                catalog.Catalogs.Add(new AssemblyCatalog(moduleAssembly));
            }

            container = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection);
            CompositionBatch batch = new CompositionBatch();
            batch.AddExportedValue(container);
            container.Compose(batch);

            IEnumerable<IPresentationService> presentationServices = container.GetExportedValues<IPresentationService>();
            foreach (IPresentationService service in presentationServices) { service.Initialize(); }

            controllers = container.GetExportedValues<IModuleController>();
            foreach (IModuleController controller in controllers) { controller.Initialize(); }
            foreach (IModuleController controller in controllers) { controller.Run(); }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            foreach (IModuleController controller in controllers.Reverse()) { controller.Shutdown(); }

            container.Dispose();
            catalog.Dispose();

            base.OnExit(e);
        }
    }
}
