namespace AlgorithmsAndAI_FinalAssignment
{
    /// <summary>
    /// This class will be used to give entities statistics.
    /// </summary>
    public class Statistic
    {
        /* The current value that will be updated a lot.*/
        public double currentValue;

        /* The max value of the stat */
        public double max;
        public Statistic(double max = 0)
        {
            this.max = max;
            currentValue = max;
        }

        /// <summary>
        /// This method will increase the current value.
        /// </summary>
        /// <param name="value"></param>
        public void Increase(double value)
        {
            currentValue += value;

            /* Stop increasing when value is bigger than the maximum value. */
            if (currentValue > max)
            {
                currentValue = max;
            }
        }
        /// <summary>
        /// This method will decrease the current value.
        /// </summary>
        /// <param name="value"></param>
        public void Decrease(double value)
        {
            /* Stop decreasing when value is below 1. */
            if (currentValue > 1) currentValue -= value;
            else currentValue = 1;

        }
    }
}
