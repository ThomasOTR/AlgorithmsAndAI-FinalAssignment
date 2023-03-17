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

            if (val == peak) return 1;

            if (val < peak && val > left) return (val - left) / (peak - left);
            if (val > peak && val < right) return (right - val) / (right - peak);
            else return 0;

        }
    }
}
