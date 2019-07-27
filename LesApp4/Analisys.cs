namespace LesApp4
{
    /// <summary>
    /// Структура для збереження даних аналізу
    /// </summary>
    struct Analisys
    {
        /// <summary>
        /// Кількість мов які аналізуються
        /// </summary>
        private int count;
        /// <summary>
        /// Ймовірність для кожної мови
        /// </summary>
        private double[] probability;
        private string[] language;

        /// <summary>
        /// Кількість мов які аналізуються
        /// </summary>
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                probability = new double[count];
                language = new string[count];
            }
        }
        /// <summary>
        /// Мови які аналізуються
        /// </summary>
        public string[] Language
        {
            get { return language; }
            set { language = value; }
        }
        /// <summary>
        /// Імовірність належання слова кожної мови
        /// </summary>
        public double[] Probability
        {
            get { return probability; }
            set { probability = value; }
        }

    }
}
