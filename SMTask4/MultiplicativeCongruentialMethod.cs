namespace SMTask4
{
    class MultiplicativeCongruentialMethod
    {
        private readonly long M;
        private readonly long beta;
        private long prev;
        private long next;

        public MultiplicativeCongruentialMethod(long M, long beta)
        {
            this.M = M;
            this.beta = beta;
            prev = beta;
        }

        public double GetElement()
        {
            next = (prev * beta) % M;
            prev = next;

            return (double)next / M;
        }
    }
}
