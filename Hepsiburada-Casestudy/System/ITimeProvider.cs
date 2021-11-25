using Hepsiburada_Casestudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada_Casestudy.System
{
    public interface ITimeProvider
    {
        void IncreaseTime(int hour);
        TimeModel GetTimeModel();
    }
}
