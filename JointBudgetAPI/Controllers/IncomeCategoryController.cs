using JointBudgetAPI.JointBudgetModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JointBudgetAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors]
public class IncomeCategoryController : ControllerBase
{
    private readonly JointBudgetContext _jointBudgetContext;

    /// <summary>
    /// Подключает контроллер к контексту базы данных
    /// </summary>
    /// <param name="context">Контекст базы данных</param>
    public IncomeCategoryController(JointBudgetContext context)
    {
        _jointBudgetContext = context;
    }

    /// <summary>
    /// Получение категорий расходов
    /// </summary>
    /// <param name="UserId">Id пользователя</param>
    /// <returns>Список категорий расходов для определённого пользователя</returns>
    [HttpGet]
    [Authorize(Roles = "admin, user")]
    public async Task<ActionResult<List<IncomeCategory>>> Get([FromRoute] string UserId)
    {
        List<IncomeCategory> categories = new();
        await foreach (var c in _jointBudgetContext.IncomeCategories)
        {
            IncomeCategory categ = new();
            if (c.UserId == UserId || c.UserId == "DefaultUser")
                categories.Add(categ);
        }

        return categories;
    }

    /// <summary>
    /// Получения конкретной категории расходов из базы данных
    /// </summary>
    /// <param name="id">Идентификатор категории расходов</param>
    /// <returns>Класс категории расходов</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "admin, user")]
    public async Task<ActionResult<IncomeCategory>> GetOne([FromRoute] string id)
    {
        var category = await _jointBudgetContext.IncomeCategories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    /// <summary>
    /// Создание нового товара в базе данных (только администратор)
    /// </summary>
    /// <param name="prDTO">DTO нового товара (без id, разрешается без имён категории и производителя,
    /// ссылки на изображение)</param>
    /// <returns>DTO передаваемого товара с заполненными id,
    /// categoryName, manufacturerName</returns>
    [HttpPost]
    [Authorize(Roles = "admin, user")]
    public async Task<ActionResult<IncomeCategory>> Post([FromBody] IncomeCategory categ)
    {
        categ.Id = Guid.NewGuid().ToString();
        _jointBudgetContext.IncomeCategories.Add(categ);
        await _jointBudgetContext.SaveChangesAsync();
        return CreatedAtAction("Get", new { id = categ.Id }, categ);
    }

    /// <summary>
    /// Изменение товара в базе данных (только администратор)
    /// </summary>
    /// <param name="prDTO">DTO товара с параметром Id. Изменятся все поля</param>
    /// <returns></returns>
    [HttpPut]
    [Authorize(Roles = "admin, user")]
    public async Task<ActionResult<IncomeCategory>> Put([FromBody] IncomeCategory categ)
    {
        var c = await _jointBudgetContext.IncomeCategories.FindAsync(categ.Id);
        if (c == null || c.UserId == "DefaultUser")
        {
            return NotFound();
        }

        _jointBudgetContext.IncomeCategories.Update(c);
        await _jointBudgetContext.SaveChangesAsync();
        return Ok("Сущность успешно обновлена");
    }

    /// <summary>
    /// Удаление пользовательской категории 
    /// </summary>
    /// <param name="id">id удаления</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "admin, user")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        var c = await _jointBudgetContext.IncomeCategories.FindAsync(id);
        if (c == null || c.UserId == "DefaultUser")
        {
            return NotFound();
        }

        await foreach (var exp in _jointBudgetContext.Incomes)
        {
            if (exp.CategoryId == id)
            {
                _jointBudgetContext.Incomes.Remove(exp);
            }
        }
        _jointBudgetContext.IncomeCategories.Remove(c);
        await _jointBudgetContext.SaveChangesAsync();
        return Ok("Сущность успешно удалена");
    }
}