using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace FinalAssignment_Tests
{
    public class Vector2DTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [TestCase(10, 40)]
        [TestCase(503, 1000)]
        [TestCase(-40, 1040)]
        public void ConstructorTest(double x, double y)
        {
            Vector2D v = new(x, y);

            Assert.That(x, Is.EqualTo(v.x));
            Assert.That(y, Is.EqualTo(v.y));
        }

        [TestCase(10, 40)]
        [TestCase(503, 1000)]
        [TestCase(-40, 1040)]
        public void NegativeTest(double x, double y)
        {
            Vector2D v = new Vector2D(x, y).Negative();

            Assert.That(v, Is.EqualTo(new Vector2D(-x, -y)));


        }

        [TestCase(10, 40)]
        [TestCase(503, 1000)]
        [TestCase(-40, 1040)]
        public void LengthTest(double x, double y)
        {
            Vector2D v = new(x, y);

            double length = v.Length();

            double value = x * x + y * y;

            Assert.That(length, Is.EqualTo(Math.Sqrt(value)));
        }

        [TestCase(10, 40)]
        [TestCase(503, 1000)]
        [TestCase(-40, 1040)]
        public void LengthSquaredTest(double x, double y)
        {
            Vector2D v = new(x, y);

            double length = v.LengthSquared();

            double value = x * x + y * y;

            Assert.That(length, Is.EqualTo(value));
        }

        [TestCase(10, 40)]
        [TestCase(503, 1000)]
        [TestCase(-40, 1040)]
        [TestCase(0, 0)]
        public void NormalizeTest(double x, double y)
        {
            Vector2D normalized = new Vector2D(x, y).Normalize();

            if (x != 0 || y != 0)
            {
                double LengthSquared = x * x + y * y;
                double length = Math.Sqrt(LengthSquared);

                double tempX = x / length;
                double tempY = y / length;
                Vector2D CalculatedNormalizedVector = new Vector2D(tempX, tempY);
                Assert.Multiple(() =>
                {
                    Assert.That(normalized.x, Is.EqualTo(CalculatedNormalizedVector.x));
                    Assert.That(normalized.y, Is.EqualTo(CalculatedNormalizedVector.y));
                });
            }
            else Assert.That(new Vector2D(x, y), Is.EqualTo(normalized));
        }

        [TestCase(10, 40)]
        [TestCase(503, 1000)]
        [TestCase(-40, 1040)]
        public void PerpTest(double x, double y)
        {
            Vector2D perped = new Vector2D(x, y).Perp();

            Assert.Multiple(() =>
            {
                Assert.That(perped.x, Is.EqualTo(-y));
                Assert.That(perped.y, Is.EqualTo(x));
            });

        }
        [TestCase(100, 300, 50, 20)]
        public void DistanceTest(double x, double y, double x2, double y2)
        {
            double tempX = x - x2;
            double tempy = y - y2;
            double value = tempX * tempX + tempy * tempy;

            double distance = new Vector2D(x, y).Distance(new Vector2D(x2, y2));
            Assert.That(distance, Is.EqualTo(Math.Sqrt(value)));
        }

        [TestCase(100, 300, 50, 20)]
        public void DistanceSquaredTest(double x, double y, double x2, double y2)
        {
            double tempX = x - x2;
            double tempy = y - y2;
            double value = tempX * tempX + tempy * tempy;

            double distance = new Vector2D(x, y).DistanceSquared(new Vector2D(x2, y2));
            Assert.That(distance, Is.EqualTo((value)));

        }
        [TestCase(10, 10, 200)]
        public void Truncate_BelowLimit_Test(double x, double y, double max)
        {
            double value = x * x + y * y;
            double length = Math.Sqrt(value);

            Assert.That(length, Is.LessThanOrEqualTo(max));

            Vector2D Truncated = new Vector2D(x, y).Truncate(max);

            Assert.That(new Vector2D(x, y), Is.EqualTo(Truncated));

        }
        [TestCase(700, 700, 50)]
        [TestCase(400, 400, 30)]
        [TestCase(1000, 1000, 100)]
        public void Truncate_Test(double x, double y, double max)
        {
            Vector2D v = new Vector2D(x, y).Truncate(max);

            double value = x * x + y * y;
            double length = Math.Sqrt(value);

            Assert.That(length, Is.GreaterThan(max));

            double calculatedX = x / length;
            double calculatedY = y / length;

            calculatedX *= max;
            calculatedY *= max;

            Vector2D Calculated = new(calculatedX, calculatedY);

            Assert.That(v, Is.EqualTo(Calculated));
        }

        [TestCase(10, 40)]
        [TestCase(503, 1000)]
        [TestCase(-40, 1040)]
        public void CloneTest(double x, double y)
        {
            Vector2D cloned = new Vector2D(x, y).Clone();

            Assert.That(new Vector2D(x, y), Is.EqualTo(cloned));
        }

        [TestCase(15, 20, 5, 5)]
        [TestCase(500, 4, 40, 50)]
        [TestCase(30, 20, 20, 50)]
        [TestCase(100, 150, 1, 1)]
        public void Vector2D_Add_Test(double initX, double initY, double addX, double addY)
        {
            double owncalculatedX = initX + addX;
            double owncalculatedY = initY + addY;
            Vector2D calculatedVector = new Vector2D(owncalculatedX, owncalculatedY);

            Vector2D init = new(initX, initY);
            Vector2D addition = new(addX, addY);

            Vector2D v1 = init.Clone().Add(addition);
            Vector2D v2 = init.Clone() + addition;
            Assert.Multiple(() =>
            {
                Assert.That(v1, Is.EqualTo(calculatedVector));
                Assert.That(v2, Is.EqualTo(calculatedVector));
            });
        }

        [TestCase(10, 30, 4, 4)]
        [TestCase(400, 30, 100, 20)]
        [TestCase(10, 30, 4, 3)]
        [TestCase(10, 30, 3, 5)]
        public void Vector2D_Sub_Test(double initX, double initY, double subX, double subY)
        {
            double owncalculatedX = initX - subX;
            double owncalculatedY = initY - subY;
            Vector2D calculatedVector = new Vector2D(owncalculatedX, owncalculatedY);

            Vector2D init = new(initX, initY);
            Vector2D sub = new(subX, subY);

            Vector2D v1 = init.Clone().Subtract(sub);
            Vector2D v2 = init.Clone() - sub;
            Assert.Multiple(() =>
            {
                Assert.That(v1, Is.EqualTo(calculatedVector));
                Assert.That(v2, Is.EqualTo(calculatedVector));
            });
        }
        [TestCase(5, 6, 5)]
        [TestCase(4, 30, 4)]
        [TestCase(15, 60, 3)]
        [TestCase(60, 40, 6)]
        public void Vector2D_Multiply_Test(double initX, double initY, double multiplyValue)
        {
            double owncalculatedX = initX * multiplyValue;
            double owncalculatedY = initY * multiplyValue;
            Vector2D calculatedVector = new Vector2D(owncalculatedX, owncalculatedY);

            Vector2D init = new(initX, initY);

            Vector2D v1 = init.Clone().Multiply(multiplyValue);
            Vector2D v2 = init.Clone() * multiplyValue;
            Assert.Multiple(() =>
            {
                Assert.That(v1, Is.EqualTo(calculatedVector));
                Assert.That(v2, Is.EqualTo(calculatedVector));
            });
        }

        [TestCase(25, 125, 5)]
        [TestCase(16, 48, 4)]
        [TestCase(39, 60, 3)]
        [TestCase(60, 240, 6)]
        public void Vector2D_Divide_Test(double initX, double initY, double divideValue)
        {
            double owncalculatedX = initX / divideValue;
            double owncalculatedY = initY / divideValue;
            Vector2D calculatedVector = new Vector2D(owncalculatedX, owncalculatedY);

            Vector2D init = new(initX, initY);

            Vector2D v1 = init.Clone().Divide(divideValue);
            Vector2D v2 = init.Clone() / divideValue;
            Assert.Multiple(() =>
            {
                Assert.That(v1, Is.EqualTo(calculatedVector));
                Assert.That(v2, Is.EqualTo(calculatedVector));
            });
        }
    }
}
