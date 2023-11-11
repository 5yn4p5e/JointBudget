using JointBudgetClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JointBudgetClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeaderProfile : Grid
	{
        private HeaderProfileViewModel _viewModel;

        public HeaderProfile()
        {
            InitializeComponent();

            BindingContext = _viewModel = new HeaderProfileViewModel();
        }
    }
}