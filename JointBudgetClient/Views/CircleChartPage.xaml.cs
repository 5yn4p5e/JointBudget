using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JointBudgetClient.ViewModels;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Color = System.Drawing.Color;

namespace JointBudgetClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CircleChartPage : StackLayout
	{
        public CircleChartPage()
        {
            InitializeComponent();

            var ExpesneCategories = new ExpenseCategoryViewModel[]
            {
                new ExpenseCategoryViewModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Авто"
                },

                new ExpenseCategoryViewModel()
                {
                    Id = Guid.Empty.ToString(),
                    Name = "Дом"
                }
            };

            var Expenses = new ExpenseViewModel[]
            {
                new ExpenseViewModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Ремонт авто",
                    CategoryId = ExpesneCategories[0].Id,
                    Sum = 15000
                },

                new ExpenseViewModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Заправка",
                    CategoryId = ExpesneCategories[0].Id,
                    Sum = 2000
                },

                new ExpenseViewModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Коммуналка",
                    CategoryId = ExpesneCategories[1].Id,
                    Sum = 8000
                },

                new ExpenseViewModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Ремонт раковины",
                    CategoryId = ExpesneCategories[1].Id,
                    Sum = 900
                }
            };

            double[] sums = new double[ExpesneCategories.Length];

            for (int i = 0; i < sums.Length; i++)
            {
                foreach (var a in Expenses)
                {
                    if (a.CategoryId == ExpesneCategories[i].Id)
                    {
                        sums[i] += a.Sum;
                    }
                }
            }

            // Создаем данные для круговой диаграммы
            var entries = new[]
            {
                new ChartEntry((float)sums[0])
                {
                    Label = ExpesneCategories[0].Name,
                    ValueLabel = sums[0].ToString(),
                    Color = SKColor.Parse("#2c3e50"),
                    ValueLabelColor = SKColor.Parse("#2c3e50")
                },
                new ChartEntry((float)sums[1])
                {
                    Label = ExpesneCategories[1].Name,
                    ValueLabel = sums[1].ToString(),
                    Color = SKColor.Parse("#77d065"),
                    ValueLabelColor = SKColor.Parse("#77d065")
                },
                new ChartEntry((float)sums[0])
                {
                    Label = ExpesneCategories[0].Name,
                    ValueLabel = sums[0].ToString(),
                    Color = SKColor.Parse("#2c3e50"),
                    ValueLabelColor = SKColor.Parse("#2c3e50")
                },
                new ChartEntry((float)sums[1])
                {
                    Label = ExpesneCategories[1].Name,
                    ValueLabel = sums[1].ToString(),
                    Color = SKColor.Parse("#77d065"),
                    ValueLabelColor = SKColor.Parse("#77d065")
                }
            };

            // Создаем круговую диаграмму
            var chart = new DonutChart
            {
                Entries = entries,
                LabelTextSize = 30,
                HoleRadius = 0.7f,
                BackgroundColor = SKColor.Empty
            };

            // Создаем контейнер для отображения диаграммы
            var chartViews = new Microcharts.Forms.ChartView[]
            {
                new Microcharts.Forms.ChartView
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Chart = chart
                },
                new Microcharts.Forms.ChartView
                {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Chart = chart
                }
            };

            // Добавляем диаграмму на страницу
            Diagram.Children.Add(chartViews[0]);
            Diagram.Children.Add(chartViews[1]);
        }
    }
}