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

            /* The straight part of the shoulder */
            if (val >= peak && val <= right) return 1.0;

            /* The diagonal part of the shoulder */

            if (val < peak && val > left) return (val - left) / (peak - left);

            /* Outside the shoulder */
            return 0.0;

        }
    }
}
