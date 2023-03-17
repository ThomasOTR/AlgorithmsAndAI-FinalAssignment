using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzyTerms;

namespace FinalAssignment_Tests
{
    public class FuzzyLogicTests
    {
        private FuzzyModule fm;
        [SetUp]
        public void Setup()
        {
            FuzzyModule FM = new FuzzyModule();
            /* Create Variables */
            FuzzyVariable energy = FM.CreateFLV("energy");
            FuzzyTerm_SET lowenergy = energy.AddLeftShoulderSet("LOW", 0, 0, 5);
            FuzzyTerm_SET averageenergy = energy.AddTriangle("AVERAGE", 0, 5, 10);
            FuzzyTerm_SET highenergy = energy.AddRightShoulderSet("HIGH", 5, 10, 10);

            FuzzyVariable strength = FM.CreateFLV("strength");
            FuzzyTerm_SET weak = strength.AddLeftShoulderSet("weak", 0, 5, 15);
            FuzzyTerm_SET strong = strength.AddRightShoulderSet("strong", 5, 15, 20);

            FuzzyVariable runningspeed = FM.CreateFLV("runningspeed");
            FuzzyTerm_SET slow = runningspeed.AddLeftShoulderSet("slow", 10, 15, 20);
            FuzzyTerm_SET average = runningspeed.AddTriangle("average", 15, 20, 25);
            FuzzyTerm_SET fast = runningspeed.AddRightShoulderSet("fast", 20, 25, 30);

            /* Undesirable Rules*/
            FM.AddRule(new FuzzyTerm_AND(lowenergy, strong), slow);
            FM.AddRule(new FuzzyTerm_AND(lowenergy, weak), average);
            FM.AddRule(new FuzzyTerm_AND(averageenergy, strong), fast);
            FM.AddRule(new FuzzyTerm_AND(averageenergy, weak), average);
            FM.AddRule(new FuzzyTerm_AND(highenergy, strong), fast);
            FM.AddRule(new FuzzyTerm_AND(highenergy, weak), average);
            fm = FM;
        }

        [TestCase(2, 10)]
        public void CompareCodeVersusCalculated(double energy, double strength)
        {
            fm.Fuzzify("energy", energy);
            fm.Fuzzify("strength", strength);

            double DefuzzifiedValue = fm.Defuzzify("runningspeed");
            Assert.That(Math.Round(DefuzzifiedValue, 2), Is.EqualTo(19.46));
        }
    }
}
