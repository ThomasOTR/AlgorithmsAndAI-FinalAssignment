using System.Collections.Generic;

namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzyTerms
{
    /// <summary>
    /// A fuzzy term between 2 or 3 terms where the highest of the terms will be the result.
    /// </summary>
    public class FuzzyTerm_OR : FuzzyTerm
    {
        public FuzzyTerm_OR(FuzzyTerm ft)
        {
            terms = new List<FuzzyTerm> { ft };
        }
        public FuzzyTerm_OR(FuzzyTerm ft1, FuzzyTerm ft2)
        {
            terms = new List<FuzzyTerm> { ft1, ft2 };
        }
        public FuzzyTerm_OR(FuzzyTerm ft1, FuzzyTerm ft2, FuzzyTerm ft3)
        {
            terms = new List<FuzzyTerm> { ft1, ft2, ft3 };
        }

        public override void ClearDom()
        {
            foreach (FuzzyTerm term in terms)
            {
                term.ClearDom();
            }
        }

        public override FuzzyTerm Clone()
        {
            return new FuzzyTerm_OR(this);
        }

        public override double GetDom()
        {
            double largest = double.MinValue;
            foreach (FuzzyTerm t in terms)
            {
                if (t.GetDom() > largest) largest = t.GetDom();
            }
            return largest;
        }

        public override void SetDom(double val)
        {

        }
    }
}
