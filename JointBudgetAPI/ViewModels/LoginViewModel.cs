﻿using System.ComponentModel.DataAnnotations;

namespace JointBudgetAPI.ViewModels;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "Запомнить?")]
    public bool RememberMe { get; set; }
}