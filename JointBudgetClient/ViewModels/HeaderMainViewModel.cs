using JointBudgetClient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JointBudgetClient.ViewModels
{
    class HeaderMainViewModel : BaseViewModel
    {
        public Command GoToProfile { get; }

        public HeaderMainViewModel()
        {
            GoToProfile = new Command(OnGoToProfile);
        }

        private async void OnGoToProfile(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
        }
    }
}
