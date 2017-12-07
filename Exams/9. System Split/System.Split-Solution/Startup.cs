namespace TheSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Engine;

    public class Startup
    {
        static void Main(string[] args)
        {
            var engine = new SystemEngine();
            engine.Run();
        }
    }
}
