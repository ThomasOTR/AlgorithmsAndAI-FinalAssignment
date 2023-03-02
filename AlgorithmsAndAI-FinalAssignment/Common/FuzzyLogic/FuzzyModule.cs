using System.Collections.Generic;

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
        /// A method that starts the FuzzyInference Process
        /// For this method a Node class is created to store the variables for the fuzzify calls in this method
        /// </summary>
        /// <param name="FIN1"></param>
        /// <param name="FIN2"></param>
        /// <param name="DefuzzifyVariableName"></param>
        /// <returns></returns>
        public double FuzzyInference(FuzzyInferenceNode FIN1, FuzzyInferenceNode FIN2, string DefuzzifyVariableName)
        {
            Fuzzify(FIN1.FuzzyVariableName, FIN1.FuzzyInferenceValue);
            Fuzzify(FIN2.FuzzyVariableName, FIN2.FuzzyInferenceValue);
            return Defuzzify(DefuzzifyVariableName);
        }

        /// <summary>
        /// A method to fuzzify the value in his variable.
        /// </summary>
        /// <param name="FLV_name"></param>
        /// <param name="val"></param>
        private void Fuzzify(string FLV_name, double val)
        {
            variables.TryGetValue(FLV_name, out FuzzyVariable FV);
            if (FV != null)
            {
                FV.Fuzzify(val);
            }
        }

        /// <summary>
        /// A method to defuzzify the variable with the fuzzified variables.
        /// </summary>
        /// <param name="FLV_name"></param>
        /// <returns></returns>
        private double Defuzzify(string FLV_name)
        {
            variables.TryGetValue(FLV_name, out FuzzyVariable FV);
            if (FV != null)
            {
                SetConfidencesOfConsequentsToZero();
                foreach (FuzzyRule FR in rules)
                {
                    FR.Calculate();
                }
                return FV.DefuzzifyAV();
            }
            return 0;
        }

        /// <summary>
        /// A method to easily reset the DOM of the Consequence of all rules.
        /// </summary>
        private void SetConfidencesOfConsequentsToZero()
        {
            foreach (FuzzyRule FR in rules)
            {
                FR.SetConfidenceOfConsequentToZero();
            }
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
