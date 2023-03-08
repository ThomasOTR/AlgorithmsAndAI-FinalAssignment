using AlgorithmsAndAI_FinalAssignment.Common.Entities;
using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Source.MovingEntities
{
    public class NormalShuttle : MovingEntity
    {
        public NormalShuttle(World world, Vector2D position, Vector2D TargetPosition) : base(world, position, TargetPosition) { }
        public override void Render(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
