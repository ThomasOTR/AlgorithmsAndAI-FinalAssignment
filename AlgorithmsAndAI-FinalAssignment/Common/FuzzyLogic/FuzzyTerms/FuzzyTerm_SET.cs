namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzyTerms
{
    /// <summary>
    /// A fuzzy term where a fuzzy set is stored.
    /// </summary>
    public class FuzzyTerm_SET : FuzzyTerm
    {
        private FuzzySet fs;
        public FuzzyTerm_SET(FuzzySet fs)
        {
            this.fs = fs;
        }
        public override void ClearDom()
        {
            fs.ClearDom();
        }

        public override double GetDom()
        {
            return fs.GetDom();
        }

        public override void SetDom(double val)
        {
            if (fs.GetDom() < val)
            {
                fs.SetDom(val);
            }
        }
    }
}
