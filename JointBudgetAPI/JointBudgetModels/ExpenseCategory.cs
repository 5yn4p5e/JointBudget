using System.ComponentModel.DataAnnotations;

namespace JointBudgetAPI.JointBudgetModels;

public partial class ExpenseCategory
{
    [Key]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string ImageId { get; set; } = null!;

    // Если класс - содержит ключ от сущности ниже
    public virtual User User { get; set; } = null!;

    // Если класс - содержит ключ от сущности ниже
    public virtual ExpenseImage ExpenseImage { get; set; } = null!;

    // Если класс - первичный ключ для сущности ниже
    public virtual ICollection<Expense> Expenses { get; } = new List<Expense>();
}