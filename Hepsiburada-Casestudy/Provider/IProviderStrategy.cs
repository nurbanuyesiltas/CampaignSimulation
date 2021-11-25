using Hepsiburada_Casestudy.Models;

namespace Hepsiburada_Casestudy.Provider
{
    public interface IProviderStrategy
    {
        CommandModel Execute(string row);
    }
}
