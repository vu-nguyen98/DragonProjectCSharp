using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Project
{
    class EnemyAI
    {

        internal static int EnemyTurn(Dragon enemy)
        {
            int selection = 0;
            if (enemy.AIBehaviorID == 0)
            {
                selection = BanditBehavior(enemy);
                return selection;
            }
            return selection;
        }

        internal static int BanditBehavior(Dragon enemy)
        {
            Random random = new Random();
            if (enemy.SP > 25 && enemy.SkillCooldown[1] == 0)
            {
                return (1 + 1);
            } else
            {
                return (0 + 1);
            }
        }
    }
}
