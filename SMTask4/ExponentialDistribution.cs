using System;

namespace SMTask4
{
    class ExponentialDistribution
    {
        private double a;
        private double b;
        private double l;

        private MultiplicativeCongruentialMethod MCM;

        public ExponentialDistribution(double l)
        {
            this.l = l;
            a = 0;
            b = 1.5;

            int m = 24;
            long M = 2147483648;
            long beta = Beta(m);

            MCM = new MultiplicativeCongruentialMethod(2147483648, beta);
        }


        public double GetElement()
        {
            double bsvDouble = GetDoubleElement();
            return -Math.Log(bsvDouble) / l;
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
