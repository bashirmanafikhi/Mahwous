using System;
using System.Collections.Generic;
using System.Text;

namespace MahwousConsoleCore
{
    class Test
    {
        void Proccess()
        {
            Predicate<Test> predicate = new Predicate<Test>(Method);
            

        }

        bool Method(Test test) { return true; }
    }
}
