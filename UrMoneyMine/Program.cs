using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;

namespace UrMoneyMine
{
    public class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddSingleton<IWithdrawal, Withdrawal>();
                services.AddSingleton<IDeposit, Deposit>();
            }).Build();
            // Dependency injection resource: https://www.linkedin.com/learning/asp-dot-net-core-in-dot-net-6-dependency-injection/continue-your-asp-dot-net-core-journey?autoplay=true&u=91969802

            Display display = new Display(withdrawal, deposit);
            display.RunApp();
            // Abstract runapp one level up by creating an application class to kick things off.
        }
    }
}
