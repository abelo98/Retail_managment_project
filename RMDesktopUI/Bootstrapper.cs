using Caliburn.Micro;
using RMDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        //This is the object in charge of the dependency injection from caliburn.micro
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            //Whenever an instance of container is needed we'll provide _container
            _container.Instance(_container);

            //It Creates a life application instace for WindowManager(work with windows)
            //and for EventAggregator(used to pass messanges throw out the app). 
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();


            //Searches from all the types in the app those ended with "ViewModel"
            //and uses the container to register the class, so when an instance
            //is requested it'll bring a new one.
            //This is the way of connect Views with ViewModels through dependency injection.
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }


        protected override void OnStartup(object sender, StartupEventArgs e) => DisplayRootViewForAsync<ShellViewModel>();

        protected override object GetInstance(Type service, string key) => _container.GetInstance(service, key);
        protected override IEnumerable<object> GetAllInstances(Type service) => _container.GetAllInstances(service);
        protected override void BuildUp(object instance) => _container.BuildUp(instance);

    }
}
