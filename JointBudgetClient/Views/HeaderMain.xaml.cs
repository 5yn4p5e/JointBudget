using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JointBudgetClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JointBudgetClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeaderMain : Grid
	{
		private HeaderMainViewModel _viewModel;

		public HeaderMain()
		{
			InitializeComponent();

			BindingContext = _viewModel = new HeaderMainViewModel();
		}
    }
}