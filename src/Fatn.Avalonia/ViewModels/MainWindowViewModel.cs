using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;

namespace Fatn.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            if (Authenticated)
            {
                CurrentRootPage = new HomeViewModel();
            }
            else
            {
                CurrentRootPage = new LoginViewModel();
            }
        }

        /// TODO: Authentication
        public bool Authenticated => true;

        public ViewModelBase CurrentRootPage { get; set; }
    }
}