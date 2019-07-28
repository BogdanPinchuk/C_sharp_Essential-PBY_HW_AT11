using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp5
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Створення словника
            Dictionary<string, string, string> dictionary = 
                new Dictionary<string, string, string>();

            // Заголовок 
            //Console.WriteLine("\n\tУвага, порядок введення слів: англійська мова, українська мова і російська мова.\n");
            Show("\n\tСловник En-Ua-Ru:\n");

            // для швидкого тестування - автоматичне занесення даних в словник
            #region Data
            dictionary.Add("sun", "сонце", "солнце");
            dictionary.Add("pen", "ручка", "ручка");
            dictionary.Add("money", "гроші", "деньги");
            dictionary.Add("book", "книжна", "книга");
            dictionary.Add("apple", "яблуко", "яблоко");
            dictionary.Add("table", "стіл", "стол");
            dictionary.Add("moneys", "гроші", "деньги");
            dictionary.Add("san", "сонце", "солнце"); 
            #endregion

            // виведення інформації
            Info();

            // видалення по індексу
            Show("\n\tВидалення помилкового слова по індексу \"6\":\n");
            dictionary.RemoveAt(6);

            // виведення інформації
            Info();

            // видалення по ключу
            Show("\n\tВидалення помилкового слова по ключу \"san\":\n");
            dictionary.Remove("san");

            // виведення інформації
            Info();

            // звернення по індексатору
            Show("\n\tЗвернення через звичайний індексатор по номеру \"3\":\n");
            Console.WriteLine("\t" + dictionary[3]);

            Show("\n\tЗвернення через перегружений індексатор по номеру \"3\":\n");
            Console.WriteLine("\t" + dictionary[3, 
                Dictionary<string, string, string>.Values.value_2]);

            Show("\n\tЗвернення через звичайний індексатор по ключу \"table\":\n");
            Console.WriteLine("\t" + dictionary["table"]);

            Show("\n\tЗвернення через перегружений індексатор по номеру \"table\":\n");
            Console.WriteLine("\t" + dictionary["table", 
                Dictionary<string, string, string>.Values.value_2]);

            // звернення по методу
            Show("\n\tЗвернення через методу по номеру \"2\":\n");
            Console.WriteLine("\t" + dictionary.ReturnValue<string>(2, 
                Dictionary<string, string, string>.Values.value_1));

            Show("\n\tЗвернення через методу по ключу \"money\":\n");
            Console.WriteLine("\t" + dictionary.ReturnValue<string>("money", 
                Dictionary<string, string, string>.Values.value_2));

            // спроба вийти за діапазон
            Show("\n\tСпроба звернутися по неіснуючому індексу \"-1\":");
            Console.WriteLine((string)dictionary[-1, 
                Dictionary<string, string, string>.Values.value_1]);

            Show("\n\tСпроба звернутися по невірному ключу \"san\":");
            Console.WriteLine((string)dictionary["san", 
                Dictionary<string, string, string>.Values.value_2]);

            // repeat
            DoExitOrRepeat();

            // локальна функція
            void Info()
            {
                // вивід результату
                Console.WriteLine(dictionary.ToString());
                // виведення інформації
                dictionary.ShowInfo();
            }
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

        /// <summary>
        /// Зміна кольору сповіщення
        /// </summary>
        private static void Show(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
