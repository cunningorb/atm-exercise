using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UrMoneyMine
{
    public class Deposit : IDeposit
    {
        public static bool RunDeposit = true;
        UserInput input = new UserInput();

        public void DepositMenu()
        {
            while (RunDeposit)
            {
                Console.Clear();
                Console.WriteLine("Do you want to make a deposit? Y or N");
                string x = Console.ReadLine().ToUpper();
                RunDeposit = (x == "Y") ? RunDeposit = true : RunDeposit = false;
                if (RunDeposit) { DepositCash(); }
            }

        }
        public void DepositCash()
        {
            Console.WriteLine($"Type the amount you are depositing.");
            var x = Int32.TryParse(Console.ReadLine(), out var y);
            if (x)
            {
                Console.WriteLine($"You deposited {y} to your account.");
                Console.Read();
            }
            else
            {
                Console.WriteLine("You typed an incorrect value.");
                Console.Read();
            }
            RunDeposit = false;
        }
    }
}
