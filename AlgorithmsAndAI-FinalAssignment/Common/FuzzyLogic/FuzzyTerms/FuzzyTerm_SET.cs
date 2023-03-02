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

        public override FuzzyTerm Clone()
        {
            return new FuzzyTerm_SET(fs);
        }

        public override double GetDom()
        {
            return fs.Dom;
        }

        public override void OrWithDom(double val)
        {
            fs.OrWithDom(val);
        }
    }
}
