using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Class1 : IInt
    {
        /// <summary>
        /// Відобразити тип класу
        /// </summary>
        public void ShowClassType()
        {
            Console.WriteLine($"\n\tТип класу: {this.GetType().Name}");
        }
    }
}
