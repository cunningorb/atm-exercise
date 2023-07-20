using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UrMoneyMine
{
    internal class UserInput
    {
        //public int DebitPin;
        //public bool ValidUser;
        //public bool ValidSession;
        //public string UserName;
        
        public void ValidateUser()
        {
            //UserName = "fluffy";
            //Console.WriteLine($"Please Enter PIN for Account {UserName}");

        }
        /*public double ValidateInputDouble()
        {
            double ValidAmount;
            Console.WriteLine("Please enter the desired amount in this format: 1234.56");
            double.TryParse(Console.ReadLine(), out ValidAmount);
            return ValidAmount;
        }*/
        public bool ValidateIntByAtmDenom(int num)
        {
            return (num % Display.AtmDenom) == 0;
        }


    }


}