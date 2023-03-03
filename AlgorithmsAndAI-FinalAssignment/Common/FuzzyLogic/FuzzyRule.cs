namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic
{
    /// <summary>
    /// The class for each Fuzzy Rule
    /// </summary>
    public class FuzzyRule
    {
        private FuzzyTerm Antecedent;
        private FuzzyTerm Consequence;
        public FuzzyRule(FuzzyTerm ant, FuzzyTerm con)
        {
            Antecedent = ant;
            Consequence = con;
        }
        /// <summary>
        /// A method to calculate the crisp value
        /// </summary>
        public void Calculate() { Consequence.SetDom(Antecedent.GetDom()); }

        /// <summary>
        /// A method to set the DOM of the consequence to zero;
        /// </summary>
        public void SetConfidenceOfConsequentToZero() { Consequence.ClearDom(); }

        /// <summary>
        /// A method to get the antecedent of the rule
        /// </summary>
        /// <returns></returns>
        public FuzzyTerm GetAntecedent() { return Antecedent; }

        /// <summary>
        /// A method to get the consequence of the rule
        /// </summary>
        /// <returns></returns>
        public FuzzyTerm GetConsequence() { return Consequence; }
    }
}
