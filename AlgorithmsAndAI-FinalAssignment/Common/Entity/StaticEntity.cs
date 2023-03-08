using AlgorithmsAndAI_FinalAssignment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Common.Entities
{
    public abstract class StaticEntity : BaseGameEntity
    {

        public StaticEntity(World world, Vector2D position) : base(world, position){ }


        public override void Update(float delta)
        {

        }
        public abstract void Render(Graphics g);
    }
}
