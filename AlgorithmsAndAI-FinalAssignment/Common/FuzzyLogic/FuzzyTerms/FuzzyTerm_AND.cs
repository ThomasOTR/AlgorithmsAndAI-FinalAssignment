namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzyTerms
{
    /// <summary>
    /// A fuzzy term between 2 or 3 terms where the smallest value will be the result
    /// </summary>
    public class FuzzyTerm_AND : FuzzyTerm
    {
        public FuzzyTerm_AND(FuzzyTerm ft1, FuzzyTerm ft2)
        {
            terms = new List<FuzzyTerm>() { ft1, ft2 };
        }
        public FuzzyTerm_AND(FuzzyTerm ft1, FuzzyTerm ft2, FuzzyTerm ft3)
        {
            terms = new List<FuzzyTerm>() { ft1, ft2, ft3 };
        }
        public override void ClearDom()
        {
            foreach (FuzzyTerm ft in terms)
            {
                ft.ClearDom();
            }
        }

        public override double GetDom()
        {
            double smallest = double.MaxValue;
            foreach (FuzzyTerm ft in terms)
            {
                if (ft.GetDom() < smallest) smallest = ft.GetDom();
            }
            return smallest;
        }

        public override void SetDom(double val)
        {
        }
    }
}
