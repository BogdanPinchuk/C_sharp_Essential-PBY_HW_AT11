using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    /// <summary>
    /// Клас
    /// </summary>
    /// <typeparam name="Y">Ссилочний тип</typeparam>
    class Class1<Y> : IInt, IInt<Y>, IInt3<DateTime>
        where Y : class
    {
        public Y PropertyA { get; private set; }

        public Y PropertyB { get; private set; }

        public DateTime PropertyDate { get; private set; }
        

        public void SetCurrentDateTime()
        {
            PropertyDate = DateTime.Now;
        }

        public void SetPropsData(Y a, Y b)
        {
            PropertyA = a;
            PropertyB = b;
        }

        public void ShowCurrentData()
        {
            Console.WriteLine(PropertyDate.ToString());
        }
    }
}
