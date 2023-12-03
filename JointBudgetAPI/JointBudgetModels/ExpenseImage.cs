using System.ComponentModel.DataAnnotations;

namespace JointBudgetAPI.JointBudgetModels;

public partial class ExpenseImage
{
    [Key]
    public string Id { get; set; } = null!;

    public byte[] Image { get; set; } = null!;

    public string HexColor { get; set; } = null!;

    // Если класс - первичный ключ для сущности ниже
    public virtual ICollection<ExpenseCategory> ExpenseCategories { get; } = new List<ExpenseCategory>();

}