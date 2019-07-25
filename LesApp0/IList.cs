namespace LesApp0
{
    /// <summary>
    /// Інтерфейс колекції
    /// </summary>
    /// <typeparam name="T">Тип елементів</typeparam>
    interface IList<T>
    {
        /// <summary>
        /// Кількість елементів в масиві
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Ємність масиву
        /// </summary>
        int Capacity { get; }
        /// <summary>
        /// Доступ до масиву по індексу
        /// </summary>
        /// <param name="index">індекс</param>
        /// <returns></returns>
        T this[int index] { get; set; }

        /// <summary>
        /// Зміна розміру масиву
        /// </summary>
        /// <param name="capacity">нова ємність</param>
        void Resize(int capacity);
        /// <summary>
        /// Додавання масиву елеменів
        /// </summary>
        void AddRange(params T[] items);
        /// <summary>
        /// Додавання одного елемента
        /// </summary>
        void Add(T item);
        /// <summary>
        /// Видалення всіх елементів
        /// </summary>
        void Clear();
        /// <summary>
        /// Пошук індекса елемента по значенню
        /// </summary>
        /// <param name="item">значення</param>
        /// <returns></returns>
        int IndexOf(T item);
        /// <summary>
        /// Видалення тільки першого елемента по вказаному значенню
        /// </summary>
        /// <param name="item">значення</param>
        /// <returns></returns>
        bool Remove(T item);
        /// <summary>
        /// Видалення елемента по індексу
        /// </summary>
        /// <param name="index">індекс</param>
        // в оригінальному на відміну від завдання також нічого не повертає
        void RemoveAt(int index);
        /// <summary>
        /// Конвертування даних в масив
        /// </summary>
        /// <returns></returns>
        T[] ToArray();
        /// <summary>
        /// Перевірка наявності елемента в колекції
        /// </summary>
        /// <param name="item">значення</param>
        /// <returns></returns>
        bool Contains(T item);

    }
}
