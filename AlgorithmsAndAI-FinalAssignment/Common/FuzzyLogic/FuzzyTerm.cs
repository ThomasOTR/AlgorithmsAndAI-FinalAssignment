using System.Collections.Generic;

namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic
{
    /// <summary>
    /// A abstract class where all Terms will derive from.
    /// </summary>
    public abstract class FuzzyTerm
    {
        /// <summary>
        /// A list of terms used in the AND and OR Terms.
        /// </summary>
        public List<FuzzyTerm> terms;

        public FuzzyTerm()
        {
            terms = new List<FuzzyTerm>();
        }

        /// <summary>
        ///  A method to receive the Degree of Membership
        /// </summary>
        /// <returns></returns>
        public abstract double GetDom();

        /// <summary>
        /// A method to reset the Degree of Membership.
        /// </summary>
        public abstract void ClearDom();

        /// <summary>
        ///  A method that sets the Degree of Membership to the highest value between the value or the current Degree of Membership.
        /// </summary>
        /// <param name="val"></param>
        public abstract void SetDom(double val);
    }
}
