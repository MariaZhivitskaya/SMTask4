using System;

namespace SMTask4
{
    class NormalDistribution
    {
        private double a;
        private double b;
        private double m;
        private double d2;

        private MultiplicativeCongruentialMethod MCM;


        public NormalDistribution(double m, double d2)
        {
            this.a = -8;
            this.b = -this.a;
            this.m = m;
            this.d2 = d2;

            int _m = 24;
            long M = 2147483648;
            long beta = Beta(_m);

            MCM = new MultiplicativeCongruentialMethod(2147483648, beta);
        }

        public double GetElement()
        {
            double a1 = GetDoubleElement();
            double a2 = GetDoubleElement();
            double res = Math.Sqrt(-2 * Math.Log(a1)) * Math.Cos(2 * Math.PI * a2);
            return m + res * Math.Sqrt(d2);
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
