﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ClientConvertisseurV2.ViewModels;
using ClientConvertisseurV2.Views;
using Microsoft.Extensions.DependencyInjection;
using FrameworkElement = Microsoft.UI.Xaml.FrameworkElement;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV2
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            ServiceCollection services = new ServiceCollection();

            services.AddTransient<ConvertisseurEuroViewModel>();
            services.AddTransient<ConvertisseurDeviseViewModel>();
            Services = services.BuildServiceProvider();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();

            this.UnhandledException += async (sender, eventArgs) => await ShowErrorAsync(eventArgs);
        }

      

        private Window m_window;

        private async Task ShowErrorAsync(Microsoft.UI.Xaml.UnhandledExceptionEventArgs eventArgs)
        {
            ContentDialog errorDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = eventArgs.Message,
                CloseButtonText = "OK"
            };
            eventArgs.Handled = true;
            errorDialog.XamlRoot = this.m_window.Content.XamlRoot;
            ContentDialogResult result = await errorDialog.ShowAsync();
        }
        public static FrameworkElement MainRoot { get; private set; }

        public static ServiceProvider Services { get; set; }
    }
}
