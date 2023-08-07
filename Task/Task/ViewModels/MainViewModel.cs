using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Task.Model;
using Task.Services;
using Task.Services.Interfaces;
using Task.ViewModels.Interface;
using Task.Views;
using Xamarin.Forms;

namespace Task.ViewModels
{
    public  class MainViewModel : IMainViewModel
    {
        public MainViewModel(IOfferParser parser, IDialogService dialogService)
        {
            this.parser = parser;
            this.dialogService = dialogService;

        }

       

        private IDialogService dialogService;
        private IOfferParser parser;

      

        private List<Offer> offers;

        public List<Offer> Offers
        {
            get
            {
                return offers;
            }
            set
            {
                if(value.Count == 0) 
                {
                    dialogService.ShowAlertAsync("Server Error","Error");
                }
                else if  (offers != value)
                {
                    offers = value;
                    OnPropertyChanged(nameof(Offers));
                }
            }
        }

       

       public ICommand OpenInfo
        {
            get
            {
                return new Command<Offer>(async (offer) =>
                {
                    await dialogService.ShowAlertAsync(offer.Properties, "Info");
                });
            }
        }

        public ICommand Parse
        {
            get
            {
                return new Command(async() =>
                {
                 
                    if(NetworkCheck.IsInternet())
                        Offers = await parser.Parse();
                    else
                        await dialogService.ShowAlertAsync("Lost internet connection", "Error");

                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}
