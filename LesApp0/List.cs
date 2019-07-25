using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Простіше наближення реазілації базового List
    /// </summary>
    class List<T> : IList<T>
    {
        /// <summary>
        /// Масив елементів
        /// </summary>
        private T[] array = new T[4];

        /// <summary>
        /// Доступ до масиву по індексу
        /// </summary>
        /// <param name="index">індекс</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (0 <= index && index < Count)
                {
                    return array[index];
                }
                else
                {
                    Error();
                    return default;
                }
            }
            set
            {
                if (0 <= index && index < Count)
                {
                    array[index] = value;
                }
                else
                {
                    Error();
                }
            }
        }

        /// <summary>
        /// Кількість елементів в масиві
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Ємність масиву
        /// </summary>
        public int Capacity => array.Length;

        /// <summary>
        /// Додавання одного елемента
        /// </summary>
        public void Add(T item)
        {
            AddRange(item);
        }

        /// <summary>
        /// Додавання масиву елеменів
        /// </summary>
        public void AddRange(params T[] items)
        {
            // перевірка чи не пусті вхідні параметри
            if (items.Length < 1)
            {
                return;
            }

            #region вибір розміру масиву
            // в даному випадку для керування об'ємом масиву необхідно
            // розв'язати рівняння: capacity = 2^n > count
            // 2^n > count
            // log_2(2^n) > log_2(count)
            // n > log_2(count)
            // n = ln(count) / ln(2)
            // а так як передається певна кількість елементів length,
            // які необхідно доадти в масив, то рівняння прийме вигляд
            // n = ln(count + length) / ln(2)
            // якщо count + length >= capacity то міняємо розмір
            #endregion

            // розрахунок степіня двійки, який визначатиме ємність автопарку
            int power = (int)Math.Ceiling(
                Math.Log(Count + items.Length) / Math.Log(2));

            if (Count + items.Length >= Capacity)
            {
                Resize((int)Math.Pow(2, power));
            }

            // додавання нових авто
            for (int i = 0; i < items.Length; i++)
            {
                array[Count++] = items[i];
            }
        }

        /// <summary>
        /// Видалення всіх елементів
        /// </summary>
        public void Clear()
        {
            array = new T[4];
            Count = 0;
        }

        /// <summary>
        /// Перевірка наявності елемента в колекції
        /// </summary>
        /// <param name="item">значення</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Пошук індекса елемента по значенню
        /// </summary>
        /// <param name="item">значення</param>
        /// <returns>індекс елемента, якщо нічого не знайдено то -1</returns>
        public int IndexOf(T item)
        {
            // перебір по елементам
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(array[i]))
                {
                    return i;
                }
            }

            // помилка, такий елемент не знайдено
            return -1;
        }

        /// <summary>
        /// Видалення тільки першого елемента по вказаному значенню
        /// </summary>
        /// <param name="item">значення</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            // знаходимо індекс першого елемента масиву з відповідним значенням
            int index = IndexOf(item);
            // перевірка чи найдений елемент
            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Видалення елемента по індексу
        /// </summary>
        /// <param name="index">індекс</param>
        public void RemoveAt(int index)
        {
            // якщо  іде звернення поза діапазоном
            if (!(0 <= index && index < Count))
            {
                Error();
                return;
            }

            // видаляємо елемнт простим зміщенням вліво
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            // Зменшуємо лічильник кількості елемнтів
            Count--;

            // для економії пам'яті перевіряємо величину масиву
            if (Count == Capacity / 2)
            {
                Resize(Capacity / 2);
            }
        }

        /// <summary>
        /// Зміна розміру масиву
        /// </summary>
        /// <param name="capacity">нова ємність</param>
        public void Resize(int capacity)
        {
            // створення нового масиву
            T[] temp = new T[capacity];
            // копіювання елементів
            for (int i = 0; i < Count; i++)
            {
                temp[i] = array[i];
            }
            // змінна ссилки на новий масив
            array = temp;
        }

        /// <summary>
        /// Конвертування даних в масив
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            // створення нового масиву
            T[] temp = new T[Count];
            // копіювання елементів
            for (int i = 0; i < Count; i++)
            {
                temp[i] = array[i];
            }

            return temp;
        }

        /// <summary>
        /// Виведення значень
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var s = new StringBuilder();
            // заповнюємо значеннями
            for (int i = 0; i < Count; i++)
            {
                s.Append(array[i].ToString() + " ");
            }

            return s.ToString();
        }

        /// <summary>
        /// Помилка, вихід за межі масиву
        /// </summary>
        private void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tСпроба виходу за межі колекції/масиву.");
            Console.ResetColor();
        }

        /// <summary>
        /// Виведення інформації про колекцію
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"\n\tКількість елемнтів в колекції: {Count}");
            Console.WriteLine($"\tЄмність колекції: {Capacity}");
            Console.WriteLine($"\tТип даних: {typeof(T).Name}");
        }
    }
}
