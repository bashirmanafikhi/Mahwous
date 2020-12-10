using System;

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
