using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    interface IInt
    {
        void ShowCurrentData();
    }

    interface IInt<Y>
    {
        Y PropertyA { get; }
        Y PropertyB { get; }

        void SetPropsData(Y a, Y b);
    }

    interface IInt3<DateTime>
    {
        DateTime PropertyDate { get; }

        void SetCurrentDateTime();
    }
}
