namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic
{
    /// <summary>
    /// A class to easily store the necessary variables for the fuzzify method called in FuzzyInference
    /// </summary>
    public class FuzzyInferenceNode
    {
        public string FuzzyVariableName;
        public double FuzzyInferenceValue;
        public FuzzyInferenceNode(string FVN, double FIV)
        {
            FuzzyVariableName = FVN;
            FuzzyInferenceValue = FIV;
        }
    }
}
