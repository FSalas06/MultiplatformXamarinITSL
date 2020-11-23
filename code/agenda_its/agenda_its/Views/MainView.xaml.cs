using System;
using System.Collections.Generic;
using agenda_its.ViewModels;
using Xamarin.Forms;

namespace agenda_its.Views
{
    public partial class MainView : ContentPage
    {
        private MainViewModel _viewmodel;

        public MainView()
        {
            InitializeComponent();
            BindingContext = _viewmodel = new MainViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewmodel?.OnAppearing();
        }
    }
}
