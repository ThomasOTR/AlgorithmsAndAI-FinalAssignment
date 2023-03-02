namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzySets
{
    /// <summary>
    /// A right shoulder fuzzy set used for the Fuzzy Inference Process
    /// </summary>
    public class FuzzySet_RightShoulder : FuzzySet
    {
        public FuzzySet_RightShoulder(double peak, double left, double right) : base((peak + right) / 2)
        {
            this.peak = peak;
            this.left = left;
            this.right = right;
        }
        public override double CalculateDOM(double val)
        {
            /* A check if offset is 0.0 to prevent dividing by zero*/
            if (right == 0.0 && peak == val || left == 0.0 && peak == val) return 1.0;

            /* Check the left side */
            if (val <= peak && val > peak - left)
            {
                double grad = 1.0 / left;
                return grad * (val - (peak - left));
            }
            /* Check the right side */
            else if (val > peak && val <= peak + right) return 1.0;

            else return 0;
        }
    }
}
