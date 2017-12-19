using System;
using System.IO;

namespace SMTask4
{
    internal class Integral
    {
        private string file1D = "1DIntegral.txt";
        private string file2D = "2DIntegral.txt";

        public void Count1DIntegral()
        {
            int n = 1000;
            //ExponentialDistribution dt = new ExponentialDistribution(1);
            EvenDistribution dt = new EvenDistribution(0, 1.5);
            double sum = 0;
            double m = 0;
            double m2 = 0;
            double disp = 0;
            double err = 0;
            double x;
            double p;
            double f;
            double ksi;

            for (int i = 0; i < n; i++)
            {
                x = dt.GetElement();
                p = Math.Exp(-x);
                f = Math.Exp(-x*x)*Math.Sqrt(1 + x*x);
                ksi = f/p;
                sum += ksi;

                m += ksi;
                m2 += ksi*ksi;
            }

            sum /= n;
            m /= n;
            m2 /= n;
            disp = m2 - m*m;

            using (StreamWriter streamWriter = new StreamWriter(file1D))
            {
                streamWriter.WriteLine("Integral: " + sum);
                streamWriter.WriteLine("Estimation of evaluation: " + 3*Math.Sqrt(disp/n));
                streamWriter.WriteLine("MK method estimation of evaluation: " + 0.6745*Math.Sqrt(disp/n));
            }
        }

        public void Count2DIntegral()
        {
            int n = 1000;
            NormalDistribution dt = new NormalDistribution(0, 1);
            double sum = 0;
            double m = 0;
            double m2 = 0;
            double disp = 0;
            double x;
            double y;
            double p;
            double f;
            double ksi;

            for (int i = 0; i < n; i++)
            {
                x = dt.GetElement();
                y = dt.GetElement();
                p = Math.Exp(-(x*x+y*y)/2) / (2*Math.PI);
                f = Math.Exp(-(x*x+y*y)/2) * Math.Log(1 + Math.Pow( x/y , 2));
                ksi = 2 * Math.PI * Math.Log(1 + Math.Pow(x / y, 2));
                sum += ksi;

                m += ksi;
                m2 += ksi * ksi;
            }

            sum /= n;
            m /= n;
            m2 /= n;
            disp = m2 - m * m;

            using (StreamWriter streamWriter = new StreamWriter(file2D))
            {
                streamWriter.WriteLine("Integral: " + sum);
                streamWriter.WriteLine("Estimation of evaluation: " + 3 * Math.Sqrt(disp / n));
                streamWriter.WriteLine("MK method estimation of evaluation: " + 0.6745 * Math.Sqrt(disp / n));
            }
        }
    }
}
