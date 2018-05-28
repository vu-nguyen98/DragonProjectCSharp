using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Project
{
    class LevelSystem
    {
        internal static void InitialImplement(Dragon player)
        {
            player.CurrentLevel = 1;
            player.CurrentEXP = 0;
            player.MaximumEXP = 40;
        }

        internal static void AddExperience(int xp, Dragon player)
        {
            Util.SPause();
            //Console.WriteLine("Congratulations! You gained {0} experience from this fight!", xp);
            player.CurrentEXP += xp;
            if (player.CurrentEXP>=player.MaximumEXP)
            {
                LevelUp(player);
            }
        }

        private static void LevelUp(Dragon player)
        {
            Random random = new Random();

            player.CurrentEXP = player.CurrentEXP - player.MaximumEXP;
            player.CurrentLevel++;
            player.MaximumEXP = 40 * player.CurrentLevel * player.CurrentLevel;
            Console.WriteLine("\nYou have advanced to level {0}!", player.CurrentLevel);

            bool statIncr = false;

            statIncr = StatIncrease(player.Strength, player.StrGrowth, "Strength");
            if (statIncr) player.Strength++;

            statIncr = StatIncrease(player.Endurance, player.EndGrowth, "Endurance");
            if (statIncr) player.Endurance++;

            statIncr = StatIncrease(player.Resilience, player.ResGrowth, "Resilience");
            if (statIncr) player.Resilience++;

            statIncr = StatIncrease(player.Speed, player.SpdGrowth, "Speed");
            if (statIncr) player.Speed++;

            statIncr = StatIncrease(player.Agility, player.AgiGrowth, "Agility");
            if (statIncr) player.Agility++;

            statIncr = StatIncrease(player.Luck, player.LukGrowth, "Luck");
            if (statIncr) player.Luck++;

            if (player.CurrentEXP >= player.MaximumEXP)
            {
                LevelUp(player);
            }
        }

        private static bool StatIncrease(int stat, int statGrowth, String statname)
        {
            Random random = new Random();
            int rng = random.Next(0, 100);
            if (statGrowth >= rng)
            {
                Console.WriteLine("{0} increased by 1! Your {0} is now {1}!", statname, (stat+1));
                return true;
            }
            return false;
        }
    }
}
