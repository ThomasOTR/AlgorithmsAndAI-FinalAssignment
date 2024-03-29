﻿using AlgorithmsAndAI_FinalAssignment.Common.Utilities;

namespace AlgorithmsAndAI_FinalAssignment.Common.Entities
{
    public abstract class StaticEntity : BaseGameEntity
    {
        /* The radius of the Entity. This will be used in the render and the check if a node is in range of the Static Entity */
        public int radius = 40;
        public StaticEntity(World world, Vector2D position) : base(world, position) { }

        public override void Update(float delta)
        {

        }
        public abstract void Render(Graphics g);
    }
}
