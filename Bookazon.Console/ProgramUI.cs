using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Console
{
    public class ProgramUI
    {
        private BookazonModels _repo = new ();
        public void Run()
        {
            SeedContentList();
            Menu();
        }
    }
}
