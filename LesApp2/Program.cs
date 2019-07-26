using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення класу
            Class1<string> class1 = new Class1<string>();

            // утсановка значень
            class1.SetCurrentDateTime();
            class1.SetPropsData(DateTime.Now.DayOfWeek.ToString(),
                DateTime.Now.ToString(new string('M', 10)));

            // Вивід значень
            class1.ShowCurrentData();
            Console.WriteLine($"День тижня: {class1.PropertyA}");
            Console.WriteLine($"Місяць: {class1.PropertyB}");
             
            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Зміна кольору сповіщення
        /// </summary>
        private static void Show(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
