using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UrMoneyMine
{
    public class Withdrawal : IWithdrawal
    {
        public static bool RunWithdraw = true;
        UserInput input = new UserInput();

        public void WithdrawMenu()
        {
            while (RunWithdraw)
            {
                Console.Clear();
                Console.WriteLine("Do you want to make a withdrawal? Y or N");
                string x = Console.ReadLine().ToUpper();
                RunWithdraw = (x == "Y") ? RunWithdraw = true : RunWithdraw = false;
                if (RunWithdraw) { WithdrawMoney(); }
            }

        }
        // In the next episode, stream writer/reader for poor man's database
        public void WithdrawMoney()
        {
            Console.WriteLine($"Type the amount in increments of {Display.AtmDenom} you want to withdraw.");
            var x = Int32.TryParse(Console.ReadLine(), out var y);
            if (input.ValidateIntByAtmDenom(y))
            {
                Console.WriteLine($"You withdrew {y} from your account.");
                Console.Read();
            }
            else
            {
                Console.WriteLine($"You can't withdraw {y} because it is not in an increment of {Display.AtmDenom}.");
                Console.Read();
            }
            RunWithdraw = false;
        }
    }
}
