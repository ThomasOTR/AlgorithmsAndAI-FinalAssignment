using System.Diagnostics;

namespace AlgorithmsAndAI_FinalAssignment
{
    public class Statistic
    {
        public double currentValue;
        public double max;
        public Statistic(double max = 0)
        {
            this.max = max;
            currentValue = max;
        }
        public void Increase(double value)
        {
            currentValue += value;
            if (currentValue > max)
            {
                currentValue = max;
            }
        }
        public void Decrease(double value)
        {
            if (currentValue > 0) currentValue -= value;
            else currentValue = 0;
            Debug.WriteLine(currentValue);

        }
    }
}
