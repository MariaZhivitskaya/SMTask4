using System;

namespace SMTask4
{
    class EvenDistribution
    {
        private double a;
        private double b;

        private MultiplicativeCongruentialMethod MCM;

        public EvenDistribution(double a, double b)
        {
            this.a = a;
            this.b = b;

            int m = 24;
            long M = 2147483648;
            long beta = Beta(m);

            MCM = new MultiplicativeCongruentialMethod(2147483648, beta);
        }

        public double GetElement()
        {
            double elem = GetDoubleElement();
            return (b - a) * elem + a;
        }


        public double GetLeft()
        {
            return a;
        }

        public double GetRight()
        {
            return b;
        }

        private double GetDoubleElement()
        {
            return MCM.GetElement();
        }

        private long Beta(int m)
        {
            return (long)(Math.Pow(2, m) + 3);
        }
    }
}
