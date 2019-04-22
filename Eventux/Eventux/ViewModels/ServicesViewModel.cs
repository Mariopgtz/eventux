namespace Eventux.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Eventux.Common.Models;
    using Eventux.Services;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class ServicesViewModel : BaseViewModel
    {
        private Apiservices apiService;

        private bool isRefreshing;

        private ObservableCollection<Servicios> services;

        public ObservableCollection<Servicios> Services
        {
            get { return this.services; }
            set { this.SetValue(ref this.services, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public ServicesViewModel()
        {
            this.apiService = new Apiservices();
            this.LoadServices();
        }


        private async void LoadServices()
        {
            this.IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();
            if(!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                return;
            }

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlServicesController"].ToString();
            var response = await this.apiService.GetList<Servicios>(url,prefix,controller);
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;

                await Application.Current.MainPage.DisplayAlert("Error", "response.Message", "Accept");
                return;
            }

            var list = (List < Servicios >) response.Result;
            this.Services = new ObservableCollection<Servicios>(list);
            this.IsRefreshing = false;

        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadServices);
            }
        }
    }
}
