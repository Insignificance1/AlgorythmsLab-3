using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Drawing.Chart.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AlgorythmsLab_3.Utilities
{
    public class ExcelWriter
    {
        public static void WriteToExcel(List<Tuple<int, double>> results, string filePath, string chartName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            FileInfo excelFile = new FileInfo(filePath);

            using (var package = new ExcelPackage(excelFile))
            {
                var worksheet = package.Workbook.Worksheets.Add("Results");

                worksheet.Cells[1, 1].Value = "Количество операций";
                worksheet.Cells[1, 2].Value = "Время (миллисекунды)";

                for (int i = 0; i < results.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = results[i].Item1;
                    worksheet.Cells[i + 2, 2].Value = results[i].Item2;
                }

                AddChart(worksheet, chartName, "Количество операций", "Время (миллисекунды)", results.Count + 1);

                package.Save();
                try
                {
                    if (File.Exists(filePath))
                    {
                        Console.WriteLine($"Файл: {chartName}.excel - успешно создан");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при проверке или создании файла: {ex.Message}");
                }
                Console.WriteLine();
            }
        }

        private static void AddChart(ExcelWorksheet worksheet, string chartName, string titleX, string titleY, int rowCount)
        {
            var chart = worksheet.Drawings.AddChart(chartName, eChartType.LineMarkers);
            chart.Title.Text = chartName;
            chart.SetPosition(2, 0, 4, 0);
            chart.SetSize(1200, 600);

            var rangeX = worksheet.Cells[$"A2:A{rowCount}"];
            var rangeY = worksheet.Cells[$"B2:B{rowCount}"];

            var series = chart.Series.Add(rangeY, rangeX);
            series.Header = "График выполнения операций";

            chart.XAxis.AddTitle(titleX);
            chart.YAxis.AddTitle(titleY);
        }
    }
}
