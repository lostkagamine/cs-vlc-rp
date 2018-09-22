using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLCRP
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] splash =
            {
                "**** VLC RICH PRESENCE ****",
                "(C) ry00001 2018"
            };
            foreach (String m in splash) {
                Console.WriteLine(m);
            }
            new MainLoop().Execute();
        }
    }
}
