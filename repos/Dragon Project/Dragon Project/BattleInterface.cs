using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Project
{
    class BattleInterface
    {
        internal static void DisplayStats(Dragon dragon)
        {
            Console.WriteLine("{1}'s type is {0}.", dragon.Type, dragon.Name);
            Console.WriteLine("{0}'s stats:", dragon.Name);
            Console.WriteLine("Level: {8}\n" + "HP: {0}\n" + "SP: {1}\n" + "Strength: {2} \n" +
                              "Endurance: {3} \n" + "Resilience: {4} \n" +
                              "Speed: {5} \n" + "Agility: {6} \n" + "Luck: {7} \n"
                              , dragon.HP, dragon.SP, dragon.Strength, dragon.Endurance
                              , dragon.Resilience, dragon.Speed, dragon.Agility
                              , dragon.Luck, dragon.CurrentLevel);
        }

        internal static void StartTheBattle(Dragon player1, Dragon player2)
        {
            player1.HP = player1.MaxHP;
            player1.SP = player1.MaxSP;

            player2.HP = player2.MaxHP;
            player2.SP = player2.MaxSP;
        }

        internal static void VersusTime(Dragon player, Dragon enemy)
        {
            Random random = new Random();
            int playerSelection = 0, index = 1, enemySelection = 0;
            bool validSkill = false, confirmChoice = false;
            Console.WriteLine("Time to select what you want to do!");
            Console.WriteLine("The actions you can take this turn:");
            foreach (var skill in player.Skills)
            {
                SkillSystem.SkillListInterface(skill, index);
                index++;
            }

            do
            {
                try
                {
                    Console.WriteLine("\nEnter the number of the skill you want to execute!");
                    Console.Write("Selection: ");
                    playerSelection = int.Parse(Console.ReadLine());

                    if (playerSelection <= player.Skills.Count)
                    {
                        validSkill = true;
                        confirmChoice = SkillSystem.SkillActivationConfirm(playerSelection, player.Skills, player);
                    }
                    else
                    {
                        Util.WriteInRed("Invalid input! Please select a valid skill!");
                    }
                }
                catch (Exception)
                {
                    Util.WriteInRed("Error choosing skill!");
                }
            } while (!validSkill || !confirmChoice);

            enemySelection = EnemyAI.EnemyTurn(enemy);

            bool PlayerFirst = false;
            PlayerFirst = TurnDeterminer(player, enemy, playerSelection, enemySelection);

            if (PlayerFirst)
            {
                BattleTime(playerSelection, player.Skills, player, enemy);
                Util.MPause();
                if (enemy.HP > 0)
                {
                    Console.WriteLine("\nNow, it's time for the {0} to move!", enemy.Name);
                    Util.MPause();
                    BattleDialogue.EnemyAction(player, enemy, enemySelection);
                    BattleTime(enemySelection, enemy.Skills, enemy, player);
                }
            }
            else
            {
                Console.WriteLine("\n{0} outsped you! {0} will move before you!", enemy.Name);
                Util.MPause();
                BattleDialogue.EnemyAction(player, enemy, enemySelection);
                BattleTime(enemySelection, enemy.Skills, enemy, player);

                if (player.HP > 0)
                {
                    Util.MPause();
                    Console.WriteLine("\nNow it's your time to move!");
                    BattleTime(playerSelection, player.Skills, player, enemy);
                }
            }
        }

        private static bool TurnDeterminer(Dragon player, Dragon enemy, int pSel, int eSel)
        {
            Random random = new Random();

            int moveDetermineNumber;
            int randomSeed;

            randomSeed = random.Next(0, 100);
            moveDetermineNumber = 50 + 5 * (player.Speed - enemy.Speed);

            if (player.Skills[pSel-1] == 4)
            {
                moveDetermineNumber += 1000;
            }

            if (enemy.Skills[eSel - 1] == 4)
            {
                moveDetermineNumber -= 1000;
            }

            if (moveDetermineNumber > randomSeed) return true;
            else return false;
        }

        internal static void RoundAnnounce(Dragon player, Dragon enemy, int round)
        {
            Console.WriteLine("\nRound {0} is over!", round);
            Util.MPause();
            Console.WriteLine("{0}'s current status:\nHP: {1}\nSP: {2}", player.Name, player.HP, player.SP);
            Console.WriteLine("{0}'s current status:\nHP: {1}\nSP: {2}\n", enemy.Name, enemy.HP, enemy.SP);
            Util.PressAnyKey();
            Console.Clear();
        }

        internal static void AllCooldownDrop(Dragon player, Dragon enemy)
        {
            for (int i = 0; i < player.SkillCooldown.GetLength(0); i++)
            {
                if (player.SkillCooldown[i] > 0) player.SkillCooldown[i]--;
            }
            for (int i = 0; i < enemy.SkillCooldown.GetLength(0); i++)
            {
                if (enemy.SkillCooldown[i] > 0) enemy.SkillCooldown[i]--;
            }
        }

        private static void BattleTime(int selection, List<int> skills, Dragon player1, Dragon player2)
        {
            switch (skills[selection - 1])
            {
                case 0:
                    NormalStrike(player1, player2);
                    break;
                case 1:
                    RecklessCharge(player1, player2);
                    break;
                case 2:
                    DoubleUp(player1, player2);
                    break;
                case 3:
                    Pommel(player1, player2);
                    break;
                case 4:
                    Defend(player1);
                    break;
                default:
                    break;
            }
        }

        // ______ _    _ _ _  _____       ___                    
        // / ____| |  (_) | | |_ _|       | |                    | | (_)                
        //| (___ | | ___| | |   | |  _ __ | |_ ___ _ __ __ _  ___| |_ _  ___ _ __ ___ 
        // \___ \| |/ / | | |   | | | '_ \| __/ _ \ '__/ _` |/ __| __| |/ _ \| '_ \/ __|
        // ____) |   <| | | |  _| |_| | | | ||  __/ | | (_| | (__| |_| | (_) | | | \__ \
        //|_____/|_|\_\_|_|_| |_____|_| |_|\__\___|_|  \__,_|\___|\__|_|\___/|_| |_|___/


        //Normal Strike
        internal static void NormalStrike(Dragon player1, Dragon player2)
        {
            Random random = new Random();
            double hitRateModifier = 0;
            double critRateModifier = 0;
            int damageDealt = 0;
            double variance = random.Next(85, 115) * 0.01;

            double actualHitRate = player1.HitRate + hitRateModifier - player2.EvdRate;
            double actualCritRate = player1.CritRate + critRateModifier - player2.CritEvdRate;
            int attack = player1.Strength * 3;
            int defense = player2.Resilience * 2;

            if (actualHitRate > random.Next(0, 100))
            {
                damageDealt = (int)((variance) * (attack * 3 - defense * 1.5));
                if (actualCritRate > random.Next(0, 100))
                {
                    Console.WriteLine("A critical strike! This should hurt!");
                    damageDealt *= 2;
                }
                if (damageDealt < 0) damageDealt = 0;
                player2.HP -= damageDealt;
                Console.WriteLine("That attack did {0} damage!",
                                    damageDealt);
                BattleDialogue.DamageBehavior(player1, player2, damageDealt);
            }
            else
            {
                Console.WriteLine("The attack missed!");
                damageDealt = -1;
                BattleDialogue.DamageBehavior(player1, player2, damageDealt);
            }
        }

        //Reckless Charge
        internal static void RecklessCharge(Dragon player1, Dragon player2)
        {
            Random random = new Random();
            double hitRateModifier = -15;
            double critRateModifier = 8;
            int damageDealt = 0;
            double variance = random.Next(75, 125) * 0.01;

            player1.SP -= 25;

            double actualHitRate = player1.HitRate + hitRateModifier - player2.EvdRate;
            double actualCritRate = player1.CritRate + critRateModifier - player2.CritEvdRate;
            int attack = player1.Strength * 3;
            int defense = player2.Resilience * 2;

            if (actualHitRate > random.Next(0, 100))
            {
                damageDealt = (int)((variance) * (attack * 5 - defense * 2.5));
                if (actualCritRate > random.Next(0, 100))
                {
                    Console.WriteLine("A critical strike! This should hurt!");
                    damageDealt *= 2;
                }
                if (damageDealt < 0) damageDealt = 0;
                player2.HP -= damageDealt;
                Console.WriteLine("That attack did {0} damage!",
                                    damageDealt);
                BattleDialogue.DamageBehavior(player1, player2, damageDealt);
            }
            else
            {
                Console.WriteLine("The attack missed!");
                damageDealt = -1;
                BattleDialogue.DamageBehavior(player1, player2, damageDealt);
            }
            player1.SkillCooldown[1] = 2;
        }

        //Double Strike
        internal static void DoubleUp(Dragon player1, Dragon player2)
        {
            Random random = new Random();
            double hitRateModifier = 0;
            double critRateModifier = 0;
            int damageDealt = 0;
            double variance = random.Next(80, 120) * 0.01;

            player1.SP -= 30;

            double actualHitRate = player1.HitRate + hitRateModifier - player2.EvdRate;
            double actualCritRate = player1.CritRate + critRateModifier - player2.CritEvdRate;
            int attack = player1.Strength * 3;
            int defense = player2.Resilience * 2;

            if (actualHitRate > random.Next(0, 100))
            {
                damageDealt = (int)((variance) * (attack * 5 - defense * 2.5));
                if (actualCritRate > random.Next(0, 100))
                {
                    Console.WriteLine("A critical strike! This should hurt!");
                    damageDealt *= 2;
                }
                if (damageDealt < 0) damageDealt = 0;
                player2.HP -= damageDealt;
                Console.WriteLine("The first attack did {0} damage!",
                                    damageDealt);
                BattleDialogue.DamageBehavior(player1, player2, damageDealt);
            }
            else
            {
                Console.WriteLine("The first attack missed!");
                damageDealt = -1;
                BattleDialogue.DamageBehavior(player1, player2, damageDealt);
            }

            Util.MPause();

            if (actualHitRate > random.Next(0, 100))
            {
                damageDealt = (int)((variance) * (attack * 3 - defense * 1.5));
                if (actualCritRate > random.Next(0, 100))
                {
                    Console.WriteLine("\nA critical strike! This should hurt!");
                    damageDealt *= 2;
                }
                player2.HP -= damageDealt;
                Console.WriteLine("\nThe second attack did {0} damage!",
                                    damageDealt);
                BattleDialogue.DamageBehavior(player1, player2, damageDealt);
            }
            else
            {
                Console.WriteLine("The second attack missed!");
                damageDealt = -1;
                BattleDialogue.DamageBehavior(player1, player2, damageDealt);
            }

            player1.SkillCooldown[2] = 3;
        }

        //Pommel
        internal static void Pommel(Dragon player1, Dragon player2)
        {
            Random random = new Random();
            double hitRateModifier = 200;
            double critRateModifier = -2;
            int damageDealt = 0;
            double variance = random.Next(90, 110) * 0.01;

            player1.SP -= 20;

            double actualHitRate = player1.HitRate + hitRateModifier - player2.EvdRate;
            double actualCritRate = player1.CritRate + critRateModifier - player2.CritEvdRate;
            int attack = player1.Strength * 3;
            int defense = player2.Resilience * 2;

            if (actualHitRate > random.Next(0, 100))
            {
                damageDealt = (int)((variance) * (attack * 2 - defense));
                if (actualCritRate > random.Next(0, 100))
                {
                    Console.WriteLine("A critical strike! This should hurt!");
                    damageDealt *= 2;
                }
                if (damageDealt < 0) damageDealt = 0;
                player2.HP -= damageDealt;
                Console.WriteLine("That attack did {0} damage!",
                                    damageDealt);
                BattleDialogue.DamageBehavior(player1, player2, damageDealt);

                Util.SPause();
                Console.WriteLine("\nYou also apply a debuff to the enemy!");
                Util.SPause();

                Console.WriteLine("\nThe enemy loses 3 resilience for 3 turns.");
                Console.WriteLine("They will restore 1 resilience every start of turn.");
                player1.BuffDuration[3] = 4;
                player2.Resilience -= 4;

            }
            else
            {
                Console.WriteLine("The attack missed!");
                damageDealt = -1;
                BattleDialogue.DamageBehavior(player1, player2, damageDealt);
            }

            player1.SkillCooldown[3] = 5;
        }

        //Defend
        private static void Defend(Dragon player1)
        {
            Console.WriteLine("{0} brace themselves for the enemy's attack!", player1.Name);

            player1.BuffDuration[4] = 1;
            player1.Resilience *= 2;
            Console.WriteLine("\nYour resilience is increased to {0}!\n", player1.Resilience);
        }

    }
}
