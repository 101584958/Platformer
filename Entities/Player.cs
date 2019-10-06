using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace Template.Entities
{
    class Player : Actor
    {
        public Player(Bitmap bitmap) : base(bitmap)
        {
        }

        public override void OnUpdate(EntityManager entityManager)
        {
            if (SwinGame.KeyTyped(KeyCode.vk_r))
            {
                Position.Y -= 32;
            }

            if (SwinGame.KeyDown(KeyCode.vk_RIGHT))
            {
                Velocity.X += 12;
            }
            
           if (SwinGame.KeyDown(KeyCode.vk_LEFT))
            {
                Velocity.X -= 12;
            }
           
               if (SwinGame.KeyDown(KeyCode.vk_UP)&& OnGround)
            {
                Velocity.Y -= 32;
            }


            base.OnUpdate(entityManager);
        }
    }
}
