using System;
using System.Collections.Generic;
using System.Text;
using Task.Services.Interfaces;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace Task.Services
{
    public class DialogService : IDialogService
    {
        public async System.Threading.Tasks.Task ShowAlertAsync(string message, string title)
        {
            
            await UserDialogs.Instance.AlertAsync(message, title, "OK");
            
        }
    }
}
