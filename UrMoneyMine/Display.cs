using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UrMoneyMine
{
    public class Display
    {
        //Menu https://stackoverflow.com/questions/60767909/c-sharp-console-app-how-do-i-make-an-interactive-menu
        // Below can be considered fields of the display class
        public static List<Option> options;
        public const string BrandName = "UrMoneyMine";
        public const int AtmDenom = 20;
        public static bool _runApp = true;
        private readonly IWithdrawal _withdrawal;
        private readonly IDeposit _deposit;

        public Display(IWithdrawal withdrawal, IDeposit deposit)
        {
            _withdrawal = withdrawal;
            _deposit = deposit;
        }

    public void RunApp()
    {
            while(_runApp) 
            { 
                //Interactive main menu
                CreateMenu(); 
            }
    }
    public void CreateMenu()
        {
            // Create options that you want your menu to have
            options = new List<Option>
            {
                new Option("Withdraw Money", () => StartWithdrawal()),
                new Option("Deposit Cash", () =>  StartDeposit()),
                new Option("Check Balance", () =>  WriteTemporaryMessage("Try next time.")),
                new Option("Exit", () => Environment.Exit(0)),
            };

            // Set the default index of the selected item to be the first
            int index = 0;

            // Write the menu out
            WriteMenu(options, options[index]);

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();

        }


        // Default action of all the options. You can create more methods
        static void WriteTemporaryMessage(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Thread.Sleep(3000);
        WriteMenu(options, options.First());
    }



    static void WriteMenu(List<Option> options, Option selectedOption)
    {
        Console.Clear();

        foreach (Option option in options)
        {
            if (option == selectedOption)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(option.Name);
        }
    }
    void StartWithdrawal()
        {
            Withdrawal.RunWithdraw = true;
            _withdrawal.WithdrawMenu();
            WriteMenu(options, options.First());
        }
        void StartDeposit()
        {
            Deposit.RunDeposit = true;
            _deposit.DepositMenu();
            WriteMenu(options, options.First());
        }
    }

public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }
}
