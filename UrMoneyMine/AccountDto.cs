using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrMoneyMine
{
    internal class AccountDto
    {
        string fileName = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
    "/MyAccount");
        StreamWriter sw = new StreamWriter("D://MyFile.txt");
    }
}
