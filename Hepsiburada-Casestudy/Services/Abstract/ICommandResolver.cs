using Hepsiburada_Casestudy.Enum;
using Hepsiburada_Casestudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada_Casestudy.Services.Abstract
{
    public interface ICommandResolver
    {
        void Execute(CommandModel commandModel);
        ProviderType GetType();
    }
}
