using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 55);
            ProgramUI ERoom = new ProgramUI();
            ERoom.Run();
        }
    }
}
