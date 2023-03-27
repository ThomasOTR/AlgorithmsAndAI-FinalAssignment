namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic
{
    /// <summary>
    /// An abstract class where fuzzysets can derive from 
    /// </summary>
    public abstract class FuzzySet
    {
        /// <summary>
        /// Degree of Membership
        /// </summary>
        private double Dom;

        public double peak, left, right;

        /// <summary>
        /// The maximum of a fuzzy set (the place where the membership is 1)
        /// </summary>
        public double RepresentativeValue;
        public FuzzySet(double value)
        {
            Dom = 0.0;
            RepresentativeValue = value;
        }

        /// <summary>
        /// A method to calculate the Degree of Membership
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public abstract double CalculateDOM(double val);

        /// <summary>
        /// A method that its called in one of the terms of a Fuzzy Rule
        /// It sets the Degree of Membership to the highest value between the value or the current Degree of Membership.
        /// </summary>
        /// <param name="val"></param>
        public void SetDom(double val) => Dom = val;

        /// <summary>
        /// A method to easily set the dom to zero;
        /// </summary>
        public void ClearDom() { Dom = 0.0; }

        /// <summary>
        /// A method to get the Degree of Membership
        /// </summary>
        /// <returns></returns>
        public double GetDom() => Dom;
    }
}
