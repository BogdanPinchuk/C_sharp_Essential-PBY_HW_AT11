using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    interface IInt
    {
        /// <summary>
        /// Відобразити тип класа
        /// </summary>
        void ShowClassType();

    }

    interface IInt<Y>
    {
        /// <summary>
        /// Абстрактна властивість
        /// </summary>
        Y AbstractProperty { get; set; }

        /// <summary>
        /// Відобразити тип властивості
        /// </summary>
        void ShowProptype();

    }
}
