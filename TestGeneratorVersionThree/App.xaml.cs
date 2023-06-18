using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TestGeneratorVersionThree.Core;
using TestGeneratorVersionThree.MVVM.ViewModel;
using TestGeneratorVersionThree.Services;

namespace TestGeneratorVersionThree
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<QuestionViewModel>();
            services.AddSingleton<GenerateViewModel>();
            services.AddSingleton<CategoryViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();
            
            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider =>
                viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));
            _serviceProvider = services.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}