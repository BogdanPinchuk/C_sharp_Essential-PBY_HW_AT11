using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp4
{
    partial class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення колекції
            List<string> list = new List<string>();

            // заповнення колекції
            Console.WriteLine("\n\tВведіть слова:");

            #region ручний ввід
#if false
            // занесення слів у список
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"\n\tВведіть {i + 1} слово: ");
                // занесення в список слів
                list.Add(Console.ReadLine().ToLower());
            }  
#endif
            #endregion

            #region підлаштовані дані
#if true
            list.AddRange(new string[]{
                "Apple", "Sun", "God",
                "Ґанок", "Їжачок", "Інформація",
                "Дыра", "Дуэль", "Ёлка"});
#endif
            #endregion

            // Послівний і аналіз з виведенням найбільш імовірної мови до якої воно належить
            for (int i = 0; i < list.Count; i++)
            {
                AnaliseLangWithMaxProb(list[i]);
            }

            // Вивід аналізу
            for (int i = 0; i < list.Count; i++)
            {
                AnaliseWithDetail(list[i]);
            }

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Ймовірнісний аналіз букв слова, тобто до якої мови воно належить
        /// </summary>
        /// <param name="word">вхідне слово для аналізу</param>
        /// <returns></returns>
        private static Analisys ProbabilityAnalysis(string word)
        {
            // переводимо в нижній регістр, на випадок якщо цього не зроблено раніше
            word = word.ToLower();

            // створення інформаційної-структури про наявні мови і імовірність належання слова до них
            Analisys info = new Analisys()
            {
                Count = Alphabets.Language.Count,
                Language = Alphabets.Language.ToArray()
            };

            // створюємо масив із кількості наявних мов
            // для підрахунку кількості вхідних букв
            int[] letters = new int[Alphabets.Language.Count];

            // запускаємо цикл перевірки, скільки букв належать тій чи іншій абетці
            for (int i = 0; i < letters.Length; i++)
            {
                // аналіз слова по буквах
                for (int j = 0; j < word.Length; j++)
                {
                    // якщо певна буква входить в якийсь із алфавітів, то +1
                    if (Alphabets.Alphabet[i].Contains(word[j]))
                    {
                        letters[i]++;
                    }
                }
            }

            // на виході матимемо перерахунок скільки букв і до якого алфавіту відносяться
            // виводимо імовірність до кожної з мов
            for (int i = 0; i < info.Count; i++)
            {
                info.Probability[i] = (double)letters[i] / word.Length;
            }

            return info;
        }

        /// <summary>
        /// Детальний імовірнісний аналіз, з виведенням про це інформації
        /// </summary>
        /// <param name="word">вхідне слово для аналізу</param>
        private static void AnaliseWithDetail(string word)
        {
            // заносимо дані для аналізу
            Analisys info = ProbabilityAnalysis(word);

            // виводимо свовіщення
            Console.WriteLine($"\n\tСлово: {word}:");
            for (int i = 0; i < info.Count; i++)
            {
                Console.WriteLine($"\t- з імовірністю {info.Probability[i] * 100:N2}% це - {info.Language[i]};");
            }
        }

        /// <summary>
        /// Виведення інформації про те до якої мови з найбільшою імовірністю належить слово
        /// </summary>
        /// <param name="word">слово для аналізу</param>
        private static void AnaliseLangWithMaxProb(string word)
        {
            // заносимо дані для аналізу
            Analisys info = ProbabilityAnalysis(word);

            // виносимо значення імовірностей
            List<double> probability = info.Probability.ToList();

            // находимо індекс першого максимального значення
            int max = probability.IndexOf(probability.Max());

            // виводимо свовіщення
            Console.WriteLine($"\n\tСлово: {word} - {info.Language[max]};");
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
