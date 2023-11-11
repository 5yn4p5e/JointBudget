using JointBudgetClient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JointBudgetClient.ViewModels
{
    class HeaderProfileViewModel : BaseViewModel
    {
        public Command GoBack { get; }

        public HeaderProfileViewModel()
        {
            GoBack = new Command(OnGoBack);
        }

        private async void OnGoBack()
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
