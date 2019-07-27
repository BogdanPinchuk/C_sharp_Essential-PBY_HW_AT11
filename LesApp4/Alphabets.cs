using System.Collections.Generic;

namespace LesApp4
{
    partial class Program
    {
        /// <summary>
        /// Алфавіти
        /// </summary>
        static class Alphabets
        {
            /// <summary>
            /// Колекція алфавітів
            /// </summary>
            private static List<string> aplphabet = new List<string>()
            {
                "abcdefghijklmnopqrsyuvwxyz",            // 26, Англійський алфавіт
                "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя'",   // 33, Український алфавіт
                "абвгдеёжзийклмнопрстуфхцчшъыьэюя"      // 21, Російський алфавіт
            };
            /// <summary>
            /// колеція назв мов
            /// </summary>
            private static List<string> language = new List<string>()
            {
                "Англійська мова",
                "Українська мова",
                "Російська мова"
            };

            /// <summary>
            /// Доступ до алфавітів
            /// </summary>
            public static List<string> Alphabet
            {
                get { return aplphabet; }
            }
            /// <summary>
            /// Доступ до відповідних назв мов цих алфавітів
            /// </summary>
            public static List<string> Language
            {
                get { return language; }
            }
        }

    }
}
