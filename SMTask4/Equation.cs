using System;
using System.IO;

namespace SMTask4
{
    public class Equation
    {
        public void SolveEquation()
        {
            double[][] A =
            {
                new[] {-0.3, 0.2},
                new[] {-0.2, 0.3}
            };

            double[][] p =
            {
                new[] {0.5, 0.5},
                new[] {0.5, 0.5}

            };

            double[] f = {2, -1};
            double[] pi = {0.5, 0.5};
            const int N = 1000;
            int[] I = new int[N + 1];
            double[] Q = new double[N + 1];
            double[] x = {0, 0};

            int n = 1000;
            double[] ksi = new double[n];

            int m = 24;
            long M = 2147483648;
            long beta = Beta(m);

            MultiplicativeCongruentialMethod dt = new MultiplicativeCongruentialMethod(M, beta);

            double alpha;
            double result = 0;
            string fileEquation = "Equation.txt";

            using (StreamWriter streamWriter = new StreamWriter(fileEquation))
            {
                for (int comp = 0; comp <= 1; comp++)
                {
                    double[] h = {0, 0};
                    h[comp] = 1;

                    for (int j = 0; j < n; j++)
                    {
                        alpha = dt.GetElement();
                        I[0] = (alpha < pi[0] ? 0 : 1);

                        for (int k = 1; k <= N; k++)
                        {
                            alpha = dt.GetElement();
                            I[k] = (alpha < 0.5 ? 0 : 1);
                        }

                        Q[0] = (pi[I[0]] > 0 ? h[I[0]]/pi[I[0]] : 0);

                        for (int k = 1; k <= N; k++)
                        {
                            Q[k] = (p[I[k - 1]][I[k]] > 0 ? Q[k - 1]*A[I[k - 1]][I[k]]/p[I[k - 1]][I[k]] : 0);
                        }

                        for (int k = 0; k <= N; k++)
                        {
                            ksi[j] = 0;
                        }

                        for (int k = 0; k <= N; k++)
                        {
                            ksi[j] += Q[k]*f[I[k]];
                        }
                    }

                    result = 0;
                    for (int k = 0; k < N; k++)
                    {
                        result += ksi[k];
                    }
                    result /= N;

                    x[comp] = result;
                    
                    streamWriter.WriteLine("x" + comp + " = " + x[comp]);
                }
            }
        }

        private long Beta(int m)
        {
            return (long)(Math.Pow(2, m) + 3);
        }
    }
}