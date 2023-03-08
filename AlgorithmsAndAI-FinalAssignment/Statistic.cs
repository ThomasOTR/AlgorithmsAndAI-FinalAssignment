namespace AlgorithmsAndAI_FinalAssignment
{
    public class Statistic
    {
        public double value;
        public double max;
        public Statistic(double max = 0)
        {
            this.max = max;
        }
        public void Increase(double value)
        {
            this.value += value;
            if (this.value > max)
            {
                this.value = max;
            }
        }
        public void Decrease(double value)
        {
            this.value -= value;
            if (this.value < 0)
            {
                this.value = 0;
            }
        }
    }
}
