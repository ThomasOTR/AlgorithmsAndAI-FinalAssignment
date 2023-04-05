namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzySets
{
    /// <summary>
    /// A left shoulder fuzzy set used for the Fuzzy Inference process
    /// </summary>
    public class FuzzySet_LeftShoulder : FuzzySet
    {
        public FuzzySet_LeftShoulder(double peak, double left, double right) : base((peak + left) / 2)
        {
            this.peak = peak;
            this.right = right;
            this.left = left;
        }
        public override double CalculateDOM(double val)
        {
            /* The straight part of the shoulder */
            if (val >= left && val <= peak) return 1.0;

            /* The diagonal part of the shoulder */
            else if (val > peak && val < right) return (right - val) / (right - peak);

            /* Outside of the shoulder */
            else return 0.0;
        }

    }
}
