using System.ComponentModel.DataAnnotations;

namespace JointBudgetAPI.JointBudgetModels;

public partial class FamilyGroup
{
    [Key]
    public string Id { get; set; } = null!;

    public ICollection<User> Users { get; } = new List<User>();
}