using AlgorythmsLab_3.Utilities;
using OfficeOpenXml;

class Program
{
    public static void Main()
    {
        ExcelPackage.LicenseContext = LicenseContext.Commercial;

        MenuManager.ShowMainMenu();

        string fileName = "input.txt";
        try
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при проверке или создании файла: {ex.Message}");
        }
        string fileName2 = "inputStack.txt";
        try
        {
            if (!File.Exists(fileName2))
            {
                File.Create(fileName2).Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при проверке или создании файла: {ex.Message}");
        }
        string fileName3 = "inputQueueDifferent.txt";
        try
        {
            if (!File.Exists(fileName3))
            {
                File.Create(fileName3).Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при проверке или создании файла: {ex.Message}");
        }
        string fileName4 = "inputQueue.txt";
        try
        {
            if (!File.Exists(fileName4))
            {
                File.Create(fileName4).Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при проверке или создании файла: {ex.Message}");
        }


        while (true)
        {
            int choice = MenuManager.GetMenuChoice();

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Tasks.RunStackTasks();
                    break;
                case 2:
                    Console.Clear();
                    Tasks.RunQueueTasks();
                    break;
                case 3:
                    Console.Clear();
                    Tasks.RunDynamicStructuresTasks();
                    break;
                case 4:
                    Console.Clear();
                    Tasks.RunListTasks();
                    break;
                default:
                    Console.WriteLine("Error: Введите номер от 1 до 4!");
                    break;
            }
        }
       
    }
}
