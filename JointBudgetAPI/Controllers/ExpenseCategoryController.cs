using JointBudgetAPI.JointBudgetModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JointBudgetAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors]
public class ExpenseCategoryController : ControllerBase
{
    private readonly JointBudgetContext _jointBudgetContext;

    /// <summary>
    /// Подключает контроллер к контексту базы данных
    /// </summary>
    /// <param name="context">Контекст базы данных</param>
    public ExpenseCategoryController(JointBudgetContext context)
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
    public async Task<ActionResult<List<ExpenseCategory>>> Get([FromRoute] string UserId)
    {
        List<ExpenseCategory> categories = new();
        await foreach (var c in _jointBudgetContext.ExpenseCategories)
        {
            ExpenseCategory categ = new();
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
    public async Task<ActionResult<ExpenseCategory>> GetOne([FromRoute] string id)
    {
        var category = await _jointBudgetContext.ExpenseCategories.FindAsync(id);
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
    public async Task<ActionResult<ExpenseCategory>> Post([FromBody] ExpenseCategory categ)
    {
        categ.Id = Guid.NewGuid().ToString();
        _jointBudgetContext.ExpenseCategories.Add(categ);
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
    public async Task<ActionResult<ExpenseCategory>> Put([FromBody] ExpenseCategory categ)
    {
        var c = await _jointBudgetContext.ExpenseCategories.FindAsync(categ.Id);
        if (c == null || c.UserId == "DefaultUser")
        {
            return NotFound();
        }

        _jointBudgetContext.ExpenseCategories.Update(c);
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
        var c = await _jointBudgetContext.ExpenseCategories.FindAsync(id);
        if (c == null || c.UserId == "DefaultUser")
        {
            return NotFound();
        }

        await foreach (var exp in _jointBudgetContext.Expenses)
        {
            if (exp.CategoryId == id)
            {
                _jointBudgetContext.Expenses.Remove(exp);
            }
        }
        _jointBudgetContext.ExpenseCategories.Remove(c);
        await _jointBudgetContext.SaveChangesAsync();
        return Ok("Сущность успешно удалена");
    }
}