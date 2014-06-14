using System;

namespace AssertionsDemo
{
    public static class Calculator
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            throw new NotSupportedException("Not yet implemented");
        }
    }
}