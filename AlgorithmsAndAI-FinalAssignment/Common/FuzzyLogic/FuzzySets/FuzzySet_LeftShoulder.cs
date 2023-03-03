namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzySets
{
    /// <summary>
    /// A left shoulder fuzzy set used for the Fuzzy Inference process
    /// </summary>
    public class FuzzySet_LeftShoulder : FuzzySet
    {
        public FuzzySet_LeftShoulder(double peak, double left, double right) : base((peak - left) / 2)
        {
            this.peak = peak;
            this.right = right;
            this.left = left;
        }
        public override double CalculateDOM(double val)
        {
            /* A check if offset is 0.0 to prevent dividing by zero*/
            if (right == 0.0 && peak == val || left == 0.0 && peak == val) return 1.0;

            else if (val >= peak && val < peak + right)
            {
                double grad = 1.0 / -right;

                return grad * (val - peak) + 1.0;
            }

            //find DOM if left of center
            else if (val < peak)
            {
                return 1.0;
            }

            else return 0.0;

            //if (val >= LeftOffset && val <= PeakPoint)
            //    return 1.0;
            //if (val > PeakPoint && val < RightOffset)
            //    return (1.0 / (RightOffset - PeakPoint)) * (RightOffset - val);
            //else
            //    return 0.0;
        }

    }
}
