using System;
using System.Text;

namespace LesApp5
{
    /// <summary>
    /// Складний словник
    /// </summary>
    /// <typeparam name="TKey">Ключ</typeparam>
    /// <typeparam name="TValue1">Значення 1</typeparam>
    /// <typeparam name="TValue2">Значення 2</typeparam>
    class Dictionary<TKey, TValue1, TValue2>
    {
        /// <summary>
        /// Краще застосувати перерахунок, 
        /// що обмежить користувача введення невідповідних значень
        /// </summary>
        public enum Values
        {
            /// <summary>
            /// Перше значення словника
            /// </summary>
            value_1,
            /// <summary>
            /// Друге значення словника
            /// </summary>
            value_2
        }

        /// <summary>
        /// Масив ключів
        /// </summary>
        private TKey[] keys = new TKey[4];
        /// <summary>
        /// 1-й масив значень
        /// </summary>
        private TValue1[] values1 = new TValue1[4];
        /// <summary>
        /// 2-й масив значень
        /// </summary>
        private TValue2[] values2 = new TValue2[4];

        /// <summary>
        /// Кількість елементів в словнику
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Ємність словника
        /// </summary>
        public int Capacity { get { return keys.Length; } }

        /// <summary>
        /// Пошук індекса елемента по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int IndexOf(TKey key)
        {
            for (int i = 0; i < Count; i++)
            {
                if (key.Equals(keys[i]))
                {
                    return i;
                }
            }

            // помилка, такий елемент не знайдено
            return -1;
        }

        /// <summary>
        /// Доступ до елемнтів по індексу, якщо не вказано додатково тип, 
        /// то за замовчуванням виводимо лише перше значення
        /// </summary>
        /// <param name="index">індекс</param>
        /// <returns></returns>
        public TValue1 this[int index]
        {
            get
            {
                if (0 <= index && index < Count)
                {
                    return values1[index];
                }
                else
                {
                    Error("Спроба виходу за межі словника.");
                    return default;
                }
            }
            set
            {
                if (0 <= index && index < Count)
                {
                    values1[index] = value;
                }
                else
                {
                    Error("Спроба виходу за межі словника.");
                }
            }
        }
        /// <summary>
        /// Доступ до елемнтів по ключу, якщо не вказано додатково тип, 
        /// то за замовчуванням виводимо лише перше значення
        /// </summary>
        /// <param name="key">ключ</param>
        /// <returns></returns>
        public TValue1 this[TKey key]
        {
            get
            {
                // знаходження індекса елемента
                int index = IndexOf(key);
                // виведення сповіщення
                if (index != -1)
                {
                    return values1[index];
                }
                else
                {
                    // якщо нічого не знайдено
                    Error("Вказаний ключ відсутній.");
                    return default;
                }
            }
            set
            {
                // знаходження індекса елемента
                int index = IndexOf(key);
                // виведення сповіщення
                if (index != -1)
                {
                    values1[index] = value;
                }
                else
                {
                    // якщо нічого не знайдено
                    Error("Вказаний ключ відсутній.");
                }
            }
        }

        /// <summary>
        /// Індексатор доступу по індексу з вибором вихідного типу
        /// </summary>
        /// <param name="index">індекс</param>
        /// <param name="types">тип вихідного значення</param>
        /// <returns></returns>
        //https://metanit.com/sharp/tutorial/9.1.php
        public dynamic this[int index, Values types]
        {
            get
            {
                if (0 <= index && index < Count)
                {
                    dynamic dyn = default;
                    switch (types)
                    {
                        case Values.value_1:
                            dyn = values1[index];
                            break;
                        case Values.value_2:
                            dyn = values2[index];
                            break;
                    }
                    return dyn;
                }
                else
                {
                    Error("Спроба виходу за межі словника.");
                    return default;
                }
            }
            set
            {
                if (0 <= index && index < Count)
                {
                    switch (types)
                    {
                        case Values.value_1:
                            values1[index] = value;
                            break;
                        case Values.value_2:
                            values2[index] = value;
                            break;
                    }
                }
                else
                {
                    Error("Спроба виходу за межі словника.");
                }
            }
        }
        /// <summary>
        /// Доступ до елемнтів по ключу
        /// </summary>
        /// <param name="key">ключ</param>
        /// <returns></returns>
        public dynamic this[TKey key, Values types]
        {
            get
            {
                // знаходження індекса елемента
                int index = IndexOf(key);
                // виведення сповіщення
                if (index != -1)
                {
                    dynamic dyn = default;
                    switch (types)
                    {
                        case Values.value_1:
                            dyn = values1[index];
                            break;
                        case Values.value_2:
                            dyn = values2[index];
                            break;
                    }
                    return dyn;
                }
                else
                {
                    // якщо нічого не знайдено
                    Error("Вказаний ключ відсутній.");
                    return default;
                }
            }
            set
            {
                // знаходження індекса елемента
                int index = IndexOf(key);
                // виведення сповіщення
                if (index != -1)
                {
                    switch (types)
                    {
                        case Values.value_1:
                            values1[index] = value;
                            break;
                        case Values.value_2:
                            values2[index] = value;
                            break;
                    }
                }
                else
                {
                    // якщо нічого не знайдено
                    Error("Вказаний ключ відсутній.");
                }
            }
        }

        /// <summary>
        /// Помилка, вихід за межі масиву
        /// </summary>
        private void Error(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t" + s);
            Console.ResetColor();
        }

        /// <summary>
        /// Виведення інформації про колекцію
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"\n\tКількість елемнтів в колекції: {Count}");
            Console.WriteLine($"\tЄмність колекції: {Capacity}");
            Console.WriteLine($"\tТип даних ключа: {typeof(TKey).Name}");
            Console.WriteLine($"\tТип даних 1 значення: {typeof(TValue1).Name}");
            Console.WriteLine($"\tТип даних 2 значення: {typeof(TValue2).Name}");
        }

        /// <summary>
        /// Зміна розміну масивів
        /// </summary>
        /// <param name="newSize"></param>
        private void Resize(int newSize)
        {
            // створюємо нові масиви
            TKey[] keys = new TKey[newSize];
            TValue1[] values1 = new TValue1[newSize];
            TValue2[] values2 = new TValue2[newSize];
            // копіюємо значення
            for (int i = 0; i < Count; i++)
            {
                keys[i] = this.keys[i];
                values1[i] = this.values1[i];
                values2[i] = this.values2[i];
            }
            // змінюємо ссилки
            this.keys = keys;
            this.values1 = values1;
            this.values2 = values2;
        }

        /// <summary>
        /// Додавання елемнтів в словник
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value1">Значення</param>
        public void Add(TKey key, TValue1 value1, TValue2 value2)
        {
            // спочатку необхідно перевірити ключ на унікальність
            int index = IndexOf(key);

            // якщо такий ключ вже є то виходимо
            if (index != -1)
            {
                Error("Даний ключ не є унікальним.");
                return;
            }

            // перевірка жопустимої ємності масиву
            if (Count == Capacity)
            {
                Resize(Capacity * 2);
            }

            // додаємо елемент
            keys[Count] = key;
            values1[Count] = value1;
            values2[Count++] = value2;
        }
        /// <summary>
        /// Очищення даних
        /// </summary>
        public void Clear()
        {
            // задання нових масивів
            keys = new TKey[4];
            values1 = new TValue1[4];
            values2 = new TValue2[4];
            // вказуємо, що елемнти відсутні
            Count = 0;
        }

        /// <summary>
        /// Вивід даних словника
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var s = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                s.Append($"\tkey: {keys[i]}, value 1: {values1[i]}, value 2: {values2[i]};\n");
            }

            return s.ToString();
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
                Error("Спроба виходу за межі словника.");
                return;
            }

            // видаляємо елемнт простим зміщенням вліво
            for (int i = index; i < Count - 1; i++)
            {
                keys[i] = keys[i + 1];
                values1[i] = values1[i + 1];
                values2[i] = values2[i + 1];
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
        /// Видалення тільки першого елемента по вказаному ключу
        /// </summary>
        /// <param name="key">ключ</param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            // знаходимо індекс першого елемента масиву з відповідним значенням
            int index = IndexOf(key);
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

        // повернення значень назад було реалізовано за допомогою індексаторів
        // але так як в умові сказано реалізувати і метод, то зробимо додатково
        /// <summary>
        /// Метод повернення значення по індексу в залежност від вибраного типу
        /// </summary>
        /// <typeparam name="TValue">тип вихідного значення</typeparam>
        /// <param name="index">індекс</param>
        /// <param name="values">тип значення для повернення</param>
        /// <returns></returns>
        public TValue ReturnValue<TValue>(int index, Values types)
            where TValue : TValue1, TValue2
        {
            // якщо  іде звернення поза діапазоном
            if (!(0 <= index && index < Count))
            {
                Error("Спроба виходу за межі словника.");
                return default;
            }

            // тип який об'єднуватиме два типи
            TValue value;

            switch (types)
            {
                case Values.value_1:
                    value = (TValue)values1[index];
                    break;
                case Values.value_2:
                    value = (TValue)values2[index];
                    break;
                default:
                    // іде як заглушка, а в реальності сюди дійти не зможе
                    value = default;
                    break;
            }

            return value;
        }
        /// <summary>
        /// Метод повернення значення по ключу в залежност від вибраного типу
        /// </summary>
        /// <typeparam name="TValue">тип вихідного значення</typeparam>
        /// <param name="key">ключ</param>
        /// <param name="types">тип значення для повернення</param>
        /// <returns></returns>
        public TValue ReturnValue<TValue>(TKey key, Values types)
             where TValue : TValue1, TValue2
        {
            // знаходження індекса елемента
            int index = IndexOf(key);

            // тип який об'єднуватиме два типи
            TValue value = default;

            // виведення сповіщення
            if (index != -1)
            {
                switch (types)
                {
                    case Values.value_1:
                        value = (TValue)values1[index];
                        break;
                    case Values.value_2:
                        value = (TValue)values2[index];
                        break;
                }
                return value;
            }
            else
            {
                // якщо нічого не знайдено
                Error("Вказаний ключ відсутній.");
                return default;
            }
        }
    }
}
