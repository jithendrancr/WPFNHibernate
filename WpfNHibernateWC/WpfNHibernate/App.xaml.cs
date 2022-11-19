using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Web.UI.WebControls;

namespace WpfNHibernate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly WindsorContainer container = new WindsorContainer();
        public App()
        {
            ConfigureContainer();
        }
        private void ConfigureContainer()
        {
            container.Register(
                Component.For<IEmployee>().ImplementedBy<EmployeeDAO>()
                //AllTypes.FromThisAssembly().BasedOn<View>().WithService.FromInterface().Configure(c => c.LifeStyle.Is(LifestyleType.Transient)),
                //AllTypes.FromThisAssembly().BasedOn<IViewModel>().Configure(c => c.LifeStyle.Is(LifestyleType.Transient))
                );
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var factory = container.Resolve<IEmployee>();
            //var main = factory.
            //main.ShowDialog();
        }
    }
}
