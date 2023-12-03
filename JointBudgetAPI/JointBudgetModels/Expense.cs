using System.ComponentModel.DataAnnotations;

namespace JointBudgetAPI.JointBudgetModels;

public partial class Expense
{
    [Key]
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string CategoryId { get; set; } = null!;

    public bool IsPeriodical { get; set; }

    public double Sum { get; set; }

    public DateTime Time { get; set; }

    // Если класс - содержит ключ от сущности ниже
    public virtual User User { get; set; } = null!;

    // Если класс - содержит ключ от сущности ниже
    public virtual ExpenseCategory ExpenseCategory { get; set; } = null!;
}