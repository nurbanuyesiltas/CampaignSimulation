using System;
using System.Linq;

namespace Hepsiburada_Casestudy.Validator
{
    public class CommandValidator : ICommandValidator
    {
        public void CheckCommand(string command)
        {
            var columns = command.Split(" ");
            if (columns.Length<2)
            {
                Console.WriteLine($"Invalid command {command}");
                throw new Exception($"Invalid command {command}");
            }
        }
    }
}
