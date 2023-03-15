using AlgorithmsAndAI_FinalAssignment.Common.CargoSystem;
using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Goal;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using AlgorithmsAndAI_FinalAssignment.Source.Goals.Evaluators;

namespace AlgorithmsAndAI_FinalAssignment.Source.MovingEntities
{
    /// <summary>
    /// The main entity that will be perform goals by steering and logic.
    /// </summary>
    public class CargoShuttle : MovingEntity
    {
        public CargoShuttle(World world, Vector2D Position) : base(world, Position)
        {
            Brain.AddEvaluators(new List<GoalEvaluator>
            {
                new WanderEvaluator(),
                new DeliverCargoEvaluator(),
                new GoRefuelEvaluator(),
                new GoRepairEvaluator(),
                new ReceiveNewCargoEvaluator(),
            }
            );
        }

        /// <summary>
        /// Method to load the ship with cargo.
        /// </summary>
        /// <param name="cargo"></param>
        public void AddCargo(Cargo cargo)
        {
            this.cargo = cargo;
        }
        public override void Update(float deltaTime)
        {
            /* This will prevent fuel and wear decrease while standing still. */
            if (Velocity.Length() > 0)
            {
                Fuel.Decrease(0.05);
                Wear.Decrease(0.1);
            }
            base.Update(deltaTime);

        }
        public override void Render(Graphics g)
        {
            /* Render the Shuttle*/
            Pen p = new(Color.Black, 1);
            Rectangle r = new Rectangle((int)(Position.x - 20), (int)(Position.y - 20), 20, 20);
            g.DrawRectangle(p, r);

            /* Render the force */
            p = new(Color.Red, 1);
            g.DrawLine(p,
                (int)Position.x, (int)Position.y,
                (int)(Position.x + (Velocity.x * 20)),
                (int)(Position.y + (Velocity.y * 20))
                );


            //Bitmap bmp = Resources.arrow;
            //float angle = calculateAngle(Heading);

            //g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            ////rotate
            //g.RotateTransform(angle);
            ////move image back
            //g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);

            //g.DrawImage(b, (int)(Position.x - 20), (int)(Position.y - 20));

            //g.ResetTransform();
            //float moveX = (float)(bmp.Width / 2f + Position.x);
            //float moveY = (float)(bmp.Height / 2f + Position.y);
            //g.TranslateTransform(moveX, moveY);
            //g.RotateTransform(angle);
            //g.TranslateTransform(-moveX, -moveY);
            //g.DrawImage(bmp, (int)Position.x, (int)Position.y, 100, 100);
            //g.ResetTransform();

            //g.DrawString("Angle:" + angle, new Font("Arial", 6), Brushes.Black, (int)Position.x, (int)Position.y + 25);


        }
        //private float calculateAngle(Vector2D v)
        //{
        //    var angle = Math.Atan2(v.y, v.x);   //radians
        //                                        // you need to devide by PI, and MULTIPLY by 180:
        //    var degrees = 180 * angle / Math.PI;  //degrees
        //    return (float)((360 + Math.Round(degrees)) % 360); //round number, avoid decimal fragments
        //}
        //private Bitmap RotateImage(Bitmap bmp, float angle)
        //{
        //    Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
        //    rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

        //    using (Graphics g = Graphics.FromImage(rotatedImage))
        //    {
        //        // Set the rotation point to the center in the matrix
        //        g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
        //        // Rotate
        //        g.RotateTransform(angle);
        //        // Restore rotation point in the matrix
        //        g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
        //        // Draw the image on the bitmap
        //        g.DrawImage(bmp, new Point(0, 0));
        //    }

        //    return rotatedImage;
        //}
    }
}
