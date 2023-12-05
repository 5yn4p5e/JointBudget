using System;

namespace JointBudgetClient.ViewModels
{
    public class ExpenseViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CategoryId { get; set; }

        public double Sum { get; set; }
    }
}