using JointBudgetAPI.JointBudgetModels;

namespace JointBudgetAPI.Data;

public static class DbInitializer
{
    /// <summary>
    /// Инициализирует передаваемый котекст значениями по умолчанию при отсутствии в нём данных
    /// (базовые сущности в справочниках категорий и производителей)
    /// </summary>
    /// <param name="context">Контекст базы данных</param>
    /// <returns></returns>
    public static async Task Initialize(JointBudgetContext context)
    {
        try
        {
            context.Database.EnsureCreated();
            if (!context.ExpenseImages.Any())
            {
                var expensesImages = new ExpenseImage[]
                {
                    new ExpenseImage
                    {
                        Id = "CarDefault",
                        HexColor = "#112A60",
                        Image = await File.ReadAllBytesAsync("C:\\Users\\ne0l\\YandexDisk\\Education\\Diploma\\Icons\\car.png")
                    },
                    new ExpenseImage
                    {
                        Id = "ClothesDefault",
                        HexColor = "#855DFF",
                        Image = await File.ReadAllBytesAsync("C:\\Users\\ne0l\\YandexDisk\\Education\\Diploma\\Icons\\clothes.png")
                    },
                    new ExpenseImage
                    {
                        Id = "HomeDefault",
                        HexColor = "#5DDDFF",
                        Image = await File.ReadAllBytesAsync("C:\\Users\\ne0l\\YandexDisk\\Education\\Diploma\\Icons\\home.png")
                    },
                    new ExpenseImage
                    {
                        Id = "HygieneDefault",
                        HexColor = "#112A60",
                        Image = await File.ReadAllBytesAsync("C:\\Users\\ne0l\\YandexDisk\\Education\\Diploma\\Icons\\hygiene.png")
                    }
                };
                foreach (var ei in expensesImages)
                {
                    context.ExpenseImages.Add(ei);
                }
                await context.SaveChangesAsync();
            }
            if (!context.IncomeImages.Any())
            {
                var incomeImages = new IncomeImage[]
                {
                    new IncomeImage
                    {
                        Id = "DepositDefault",
                        HexColor = "#09CA01",
                        Image = await File.ReadAllBytesAsync("C:\\Users\\ne0l\\YandexDisk\\Education\\Diploma\\Icons\\deposit.png")
                    },
                    new IncomeImage
                    {
                        Id = "SalaryDefault",
                        HexColor = "#09CA01",
                        Image = await File.ReadAllBytesAsync("C:\\Users\\ne0l\\YandexDisk\\Education\\Diploma\\Icons\\salary.png")
                    }
                };
                foreach (var ei in incomeImages)
                {
                    context.IncomeImages.Add(ei);
                }
                await context.SaveChangesAsync();
            }
            if (!context.FamilyGroups.Any())
            {
                context.FamilyGroups.Add(new FamilyGroup()
                {
                    Id = "DefaultFamilyGroup"
                });
                await context.SaveChangesAsync();
            }
        }
        catch
        {
        }
    }
}