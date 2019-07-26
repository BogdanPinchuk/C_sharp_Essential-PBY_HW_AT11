using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Class2<Y> : IInt<Y>, IInt
    {
        /// <summary>
        /// Абстрактна властивість
        /// </summary>
        public Y AbstractProperty { get; set; }

        /// <summary>
        /// Відобразити тип класу
        /// </summary>
        public void ShowClassType()
        {
            Console.WriteLine($"\n\tТип класу: {this.GetType().Name}");
        }

        /// <summary>
        /// Відобразити тип властивості
        /// </summary>
        public void ShowProptype()
        {
            Console.WriteLine($"\n\tТип властивостей: {this.AbstractProperty.GetType().Name}");
        }

    }
}
