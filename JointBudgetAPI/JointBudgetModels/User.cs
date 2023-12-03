using Microsoft.AspNetCore.Identity;

namespace JointBudgetAPI.JointBudgetModels;

public partial class User : IdentityUser
{
    public string FamilyGroupId { get; set; } = null!;

    public virtual FamilyGroup FamilyGroup { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; } = new List<Expense>();

    public virtual ICollection<ExpenseCategory> ExpenseCategories { get; } = new List<ExpenseCategory>();

    public virtual ICollection<Income> Incomes { get; } = new List<Income>();

    public virtual ICollection<IncomeCategory> IncomeCategories { get; } = new List<IncomeCategory>();
}