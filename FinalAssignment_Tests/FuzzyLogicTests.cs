using AlgorithmsAndAI_FinalAssignment;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic;
using AlgorithmsAndAI_FinalAssignment.Common.FuzzyLogic.FuzzyTerms;

namespace FinalAssignment_Tests
{
    public class FuzzyLogicTests
    {
        private World world;

        [SetUp]
        public void Setup()
        {
            world = new World(1400, 1200);
        }

        [TestCase(2, 10, 19.46)]
        public void FuzzyLogicPracticeExamTest(double energy, double strength, double result)
        {
            FuzzyModule FM = new();
            /* Create Variables */
            FuzzyVariable energyvariable = FM.CreateFLV("energy");
            FuzzyTerm_SET lowenergy = energyvariable.AddLeftShoulderSet("LOW", 0, 0, 5);
            FuzzyTerm_SET averageenergy = energyvariable.AddTriangle("AVERAGE", 0, 5, 10);
            FuzzyTerm_SET highenergy = energyvariable.AddRightShoulderSet("HIGH", 5, 10, 10);

            FuzzyVariable strengthvariable = FM.CreateFLV("strength");
            FuzzyTerm_SET weak = strengthvariable.AddLeftShoulderSet("weak", 0, 5, 15);
            FuzzyTerm_SET strong = strengthvariable.AddRightShoulderSet("strong", 5, 15, 20);

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

            FM.Fuzzify("energy", energy);
            FM.Fuzzify("strength", strength);

            double DefuzzifiedValue = FM.Defuzzify("runningspeed");
            Assert.That(Math.Round(DefuzzifiedValue, 2), Is.EqualTo(result));
        }

    }
}
