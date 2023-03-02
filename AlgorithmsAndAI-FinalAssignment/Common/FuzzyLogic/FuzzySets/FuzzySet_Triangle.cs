namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzySets
{
    /// <summary>
    /// A triangle fuzzy set used for the Fuzzy Inference Process
    /// </summary>
    public class FuzzySet_Triangle : FuzzySet
    {
        public FuzzySet_Triangle(double peak, double left, double right) : base(peak)
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
            if (val <= peak && val >= peak - left)
            {
                double grad = 1.0 / left;
                return grad * (val - (peak - left));
            }

            /* Check the right side */
            else if (val > peak && val < peak + left)
            {
                double grad = 1.0 / -right;
                return grad * (val - peak) + 1;
            }
            else return 0.0;
        }
    }
}
