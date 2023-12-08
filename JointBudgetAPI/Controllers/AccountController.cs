﻿using JointBudgetAPI.JointBudgetModels;
using JointBudgetAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JointBudgetAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[EnableCors]
public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        User user = new() { Email = model.Email, UserName = model.Email };
        // Добавление нового пользователя
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            // Установка роли User
            await _userManager.AddToRoleAsync(user, "user");
            // Установка куки
            await _signInManager.SignInAsync(user, false);
            return Ok(new { message = "Добавлен новый пользователь: " + user.UserName });
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        var errorMsg = new
        {
            message = "Пользователь не добавлен",
            error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
        };
        return Created("", errorMsg);
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        var result =
        await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            IList<string>? roles = await _userManager.GetRolesAsync(user);
            string? userRole = roles.FirstOrDefault();
            return Ok(new { message = "Выполнен вход", userName = model.Email, userRole });
        }
        else
        {
            ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            var errorMsg = new
            {
                message = "Вход не выполнен",
                error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
            };
            return Created("", errorMsg);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logoff()
    {
        User usr = await GetCurrentUserAsync();
        if (usr == null)
        {
            return Unauthorized(new { message = "Сначала выполните вход" });
        }
        // Удаление куки
        await _signInManager.SignOutAsync();
        return Ok(new { message = "Выполнен выход", userName = usr.UserName });
    }

    [HttpGet]
    public async Task<IActionResult> IsAuthenticated()
    {
        User usr = await GetCurrentUserAsync();
        if (usr == null)
        {
            return Unauthorized(new { message = "Вы Гость. Пожалуйста, выполните вход" });
        }
        IList<string> roles = await _userManager.GetRolesAsync(usr);
        string? userRole = roles.FirstOrDefault();
        return Ok(new { message = "Сессия активна", userName = usr.UserName, userRole });
    }

    private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
}