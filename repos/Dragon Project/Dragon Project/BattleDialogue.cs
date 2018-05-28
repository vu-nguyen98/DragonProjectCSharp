using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Project
{
    class BattleDialogue
    {
        internal static void DamageBehavior(Dragon player1, Dragon player2, int damageDealt)
        {
            Random random = new Random();
            if (damageDealt >= 0.5*player2.HP)
            {
                HeavyHitDialogue(random.Next(0, 1), player1, player2);
            } else if (damageDealt >= 0.3*player2.HP)
            {
                MediumHitDialogue(random.Next(0, 1), player1, player2);
            } else if (damageDealt == -1)
            {
                MissedDialogue(random.Next(0, 1), player1, player2);
            } else { 
                LightHitDialogue(random.Next(0, 1), player1, player2);
            }
        }

        private static void LightHitDialogue(int random, Dragon player1, Dragon player2)
        {
            switch (random)
            {
                case 0:
                    Console.WriteLine("\n{0}: Take this!\n{1}: You call that a hit?", player1.Name, player2.Name);
                    break;
                case 1:
                    Console.WriteLine("\n{0}: How do you like this?\n{1}: I almost felt something!", player1.Name, player2.Name);
                    break;
                case 2:
                    Console.WriteLine("\n{0}: Take this!\n{1}: You call that a hit?", player1.Name, player2.Name);
                    break;
                case 3:
                    Console.WriteLine("\n{0}: Take this!\n{1}: You call that a hit?", player1.Name, player2.Name);
                    break;
            }

        }

        private static void MediumHitDialogue(int random, Dragon player1, Dragon player2)
        {
            switch (random)
            {
                case 0:
                    Console.WriteLine("\n{0}: Take this!\n{1}: That's quite impressive, but not enough!", player1.Name, player2.Name);
                    break;
                case 1:
                    Console.WriteLine("\n{0}: Taste the pain!\n{1}: You finally did something to me?", player1.Name, player2.Name);
                    break;
                case 2:
                    Console.WriteLine("\n{0}: Take this!\n{1}: You call that a hit?", player1.Name, player2.Name);
                    break;
                case 3:
                    Console.WriteLine("\n{0}: Take this!\n{1}: You call that a hit?", player1.Name, player2.Name);
                    break;
            }
        }

        private static void HeavyHitDialogue(int random, Dragon player1, Dragon player2)
        {
            switch (random)
            {
                case 0:
                    Console.WriteLine("\n{0}: Take this!\n{1}: What is this power??", player1.Name, player2.Name);
                    break;
                case 1:
                    Console.WriteLine("\n{0}: Uryahhh!\n{1}: Impossible!", player1.Name, player2.Name);
                    break;
                case 2:
                    Console.WriteLine("\n{0}: Take this!\n{1}: You call that a hit?", player1.Name, player2.Name);
                    break;
                case 3:
                    Console.WriteLine("\n{0}: Take this!\n{1}: You call that a hit?", player1.Name, player2.Name);
                    break;
            }
        }

        internal static void MissedDialogue(int random, Dragon player1, Dragon player2)
        {
            switch (random)
            {
                case 0:
                    Console.WriteLine("\n{0}: I can't believe this!\n{1}: Ha! You suck!", player1.Name, player2.Name);
                    break;
                case 1:
                    Console.WriteLine("\n{0}: You're pretty good!\n{1}: No, you're just terrible!", player1.Name, player2.Name);
                    break;
                case 2:
                    Console.WriteLine("\n{0}: Take this!\n{1}: You call that a hit?", player1.Name, player2.Name);
                    break;
                case 3:
                    Console.WriteLine("\n{0}: Take this!\n{1}: You call that a hit?", player1.Name, player2.Name);
                    break;
            }
        }

        internal static void EnemyAction(Dragon player, Dragon enemy, int sel)
        {
            if (sel == 1)
            {
                Console.WriteLine("\n{0} jumps at you and strikes!", enemy.Name);
            }
            if (sel == 2)
            {
                Console.WriteLine("\n{0} charges at you and launched a savage attack!", enemy.Name);
            }
        }
    }
}
