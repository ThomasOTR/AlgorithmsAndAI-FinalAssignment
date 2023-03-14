namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic
{
    /// <summary>
    /// A module for the Fuzzy Inference process
    /// </summary>
    public class FuzzyModule
    {
        private Dictionary<string, FuzzyVariable> variables;
        private List<FuzzyRule> rules;

        public FuzzyModule()
        {
            variables = new Dictionary<string, FuzzyVariable>();
            rules = new List<FuzzyRule>();
        }

        /// <summary>
        /// A method to create a Fuzzy Variable 
        /// </summary>
        /// <param name="FLV_name">The name for the new variable</param>
        /// <returns></returns>
        public FuzzyVariable CreateFLV(string FLV_name)
        {
            variables.Add(FLV_name, new FuzzyVariable());
            return variables[FLV_name];
        }

        /// <summary>
        /// A method to add a new rule based on the added antecedent and consequence.
        /// </summary>
        /// <param name="antecedent"></param>
        /// <param name="consequence"></param>
        public void AddRule(FuzzyTerm antecedent, FuzzyTerm consequence)
        {
            rules.Add(new FuzzyRule(antecedent, consequence));
        }

        /// <summary>
        /// A method to fuzzify the value in his variable.
        /// </summary>
        /// <param name="FLV_name"></param>
        /// <param name="val"></param>
        public void Fuzzify(string FLV_name, double val)
        {
            variables[FLV_name].Fuzzify(val);
        }

        /// <summary>
        /// A method to defuzzify the variable with the fuzzified variables.
        /// </summary>
        /// <param name="FLV_name"></param>
        /// <returns></returns>
        public double Defuzzify(string FLV_name)
        {
            if (variables.ContainsKey(FLV_name))
            {
                FuzzyVariable FV = variables[FLV_name];

                FV.ClearAllDOMValues();

                foreach (FuzzyRule FR in rules)
                {
                    FR.Calculate();
                }

                return FV.DefuzzifyAV();
            }
            return 0.0;
        }


        /// <summary>
        /// A method to return the rules stored in the module
        /// </summary>
        /// <returns></returns>
        public List<FuzzyRule> GetRules() { return rules; }

        /// <summary>
        /// A method to return the variables stored in the module
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, FuzzyVariable> GetVariables() { return variables; }

    }


}
