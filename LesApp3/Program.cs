using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Створення словника
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            // Заголовок
            Console.WriteLine("\n\tСловник: En-Ua або En-Ru:");
            Console.WriteLine("\n\tУвага, спочатку вводиться слово на англійській мові, а тоді на українській або російській.");

            #region Введення даних
#if false
            // кількість слів, які повинен ввести користувач
            int wordCount = 3;

            // занесення слів в словник вручну
            for (int i = 0; i < wordCount; i++)
            {
                Console.Write($"\n\tВведіть {i + 1} слова\n\ten: ");
                string s1 = Console.ReadLine().ToLower();
                Console.Write($"\tua/ru: ");
                string s2 = Console.ReadLine().ToLower();
                // заповнення словника
                dictionaty.Add(s1, s2);
            } 
#endif
#if true
            // для швидкого тестування - автоматичне занесення даних в словник
            dictionary.Add("sun", "сонце");
            dictionary.Add("pen", "ручка");
            dictionary.Add("money", "гроші");
#endif 
            #endregion

            // вивід результату
            Console.Clear();

            Console.WriteLine("Словник:");
            Console.WriteLine(dictionary.ToString());

            // пошук слова по введених даних
            FindWord(dictionary);

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Пошук слова по введениному ключу
        /// </summary>
        /// <param name="dictionary">Словник</param>
        private static void FindWord(Dictionary<string, string> dictionary)
        {
            Console.Write($"\n\tВведіть слово, яке необхідно перекласти\n\ten: ");
            string s = Console.ReadLine();
            #region перший варіант реалізації
            // пошук по індекса
#if false
            int index = dictionary.IndexOf(s.ToLower());
            if (index == -1)
            {
                Console.Write($"\n\tТакого слова не знайдено.");
            }
            else
            {
                Console.Write($"\n\tПереклад слова: " + dictionary[index]);
            } 
#endif
            #endregion
            #region другий варіант реалізації
            // менш красивий вивід
            Console.WriteLine(dictionary[s]);
            #endregion
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
