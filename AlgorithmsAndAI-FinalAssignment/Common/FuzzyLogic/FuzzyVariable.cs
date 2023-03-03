using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzySets;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzyTerms;
using System.Collections.Generic;

namespace AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic
{
    /// <summary>
    /// A class for making a Fuzzy Variable
    /// </summary>
    public class FuzzyVariable
    {
        /// <summary>
        /// A dictionary that can be filled with FuzzySets like LeftShoulder, RightShoulder, Triangle.
        /// </summary>
        public Dictionary<string, FuzzySet> MemberSets;

        /// <summary>
        /// The minimum of the values in the FuzzySets
        /// </summary>
        public double MinRange = 0;

        /// <summary>
        /// The maximum of the values in the FuzzySets
        /// </summary>
        public double MaxRange = 100;

        public FuzzyVariable()
        {
            MemberSets = new Dictionary<string, FuzzySet>();
        }

        /// <summary>
        /// A method to adjust the range.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        private void AdjustRangeToFit(double min, double max)
        {
            if (MinRange > min) MinRange = min;
            if (MaxRange < max) MaxRange = max;
        }

        /// <summary>
        /// A method to fuzzify a value 
        /// </summary>
        /// <param name="val"></param>
        public void Fuzzify(double val)
        {
            if (val >= MinRange && val <= MaxRange)
            {
                foreach (KeyValuePair<string, FuzzySet> kvp in MemberSets)
                {
                    kvp.Value.Dom = kvp.Value.CalculateDOM(val);
                }
            }
        }

        /// <summary>
        /// A method to Defuzzify by the Max AV method
        /// </summary>
        /// <returns></returns>
        public double DefuzzifyAV()
        {
            double bot = 0.0;
            double top = 0.0;
            foreach (KeyValuePair<string, FuzzySet> kvp in MemberSets)
            {
                bot += kvp.Value.GetDom();
                top += kvp.Value.RepresentativeValue * kvp.Value.GetDom();
            }
            if (bot != 0.0) return top / bot;
            else return 0.0;
        }
        //public double DefuzzifyCentroid(int num)
        //{
        //    //TODO 
        //    return num;
        //}

        /// <summary>
        /// A method to add a LeftShoulderSet to this variable.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="minbound"></param>
        /// <param name="peak"></param>
        /// <param name="maxbound"></param>
        /// <returns></returns>
        public FuzzyTerm_SET AddLeftShoulderSet(string name, double minbound, double peak, double maxbound)
        {
            FuzzySet_LeftShoulder leftShoulder = new FuzzySet_LeftShoulder(peak, minbound, maxbound);
            MemberSets.Add(name, leftShoulder);
            AdjustRangeToFit(minbound, maxbound);
            return new FuzzyTerm_SET(leftShoulder);
        }

        /// <summary>
        /// A method to add a RightShoulderSet to this variable.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="minbound"></param>
        /// <param name="peak"></param>
        /// <param name="maxbound"></param>
        /// <returns></returns>
        public FuzzyTerm_SET AddRightShoulderSet(string name, double minbound, double peak, double maxbound)
        {
            FuzzySet_RightShoulder rightShoulder = new FuzzySet_RightShoulder(peak, minbound, maxbound);
            MemberSets.Add(name, rightShoulder);
            AdjustRangeToFit(minbound, maxbound);
            return new FuzzyTerm_SET(rightShoulder);
        }

        /// <summary>
        /// A method to add a TriangleSet to this variable.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="minbound"></param>
        /// <param name="peak"></param>
        /// <param name="maxbound"></param>
        /// <returns></returns>
        public FuzzyTerm_SET AddTriangle(string name, double minbound, double peak, double maxbound)
        {
            FuzzySet_Triangle triangle = new FuzzySet_Triangle(peak, minbound, maxbound);
            MemberSets.Add(name, triangle);
            AdjustRangeToFit(minbound, maxbound);
            return new FuzzyTerm_SET(triangle);
        }
        public void ClearAllDOMValues()
        {
            foreach (KeyValuePair<string, FuzzySet> entry in _memberSets)
                entry.Value.ClearDOM();
        }
    }
}
