using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada_Casestudy.Validator
{
    public interface ICommandValidator
    {
        void CheckCommand(string command);
    }
}
