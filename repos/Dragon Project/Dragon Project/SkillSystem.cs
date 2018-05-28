using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Project
{ 
    class SkillSystem
        //0. normal strike: (str*2 - res), stm cost 0, no additional effect
        //1. reckless charge: (str*3 - res*1.5), stm cost 10, no additional effect
        //2. double slash: (str*1.5 - res*0.75), stm cost 15, acc - 10%, cooldown 1
        //3. pommel: (str*3 - res*1.5), stm cost 20, enemy res-2 for 3 turns, cooldown 5
        //4. guard: res*2 this turn only, stm cost 0, always move first
        //5. overwhelming attack: (str* 4 - res*2), stm cost 40, self str-3 for 3 turns, cooldown 3
        //6. guardian: stm cost 25, dmg reduction + 35% for 3 turns, cooldown 4
        //7. first strike: (str*2.2 - res*1.1), stm cost 20, spd + 99 for this attack, cooldown 1
        //8. rest: restore 15% HP and SP, stm cost 0, cooldown 4 
    {

        internal static void InitialImplement(Dragon newDragon)
        {
            if (newDragon.Type == "All Rounder")
            {
                newDragon.Skills.Add(0);
                newDragon.Skills.Add(4);
                newDragon.Skills.Add(1);
                newDragon.Skills.Add(2);
                newDragon.Skills.Add(3);
            }

            if (newDragon.Type == "Vanguard")
            {
                newDragon.Skills.Add(0);
                newDragon.Skills.Add(1);
            }

            if (newDragon.Type == "Guardian")
            {
                newDragon.Skills.Add(0);
                newDragon.Skills.Add(1);
            }

            if (newDragon.Type == "Assassin")
            {
                newDragon.Skills.Add(0);
                newDragon.Skills.Add(1);
            }

            if (newDragon.Type == "Late Bloomer")
            {
                newDragon.Skills.Add(0);
                newDragon.Skills.Add(1);
            }


            if (newDragon.Type == "Noob")
            {
                newDragon.Skills.Add(0);
                newDragon.Skills.Add(1);
            }
        }

        internal static void SkillListInterface(int skill, int index)
        {
            switch (skill)
            {
                case 0:
                    Console.WriteLine("{0}. Normal Strike", index);
                    break;
                case 1:
                    Console.WriteLine("{0}. Reckless Charge", index);
                    break;
                case 2:
                    Console.WriteLine("{0}. Double Strike", index);
                    break;
                case 3:
                    Console.WriteLine("{0}. Pommel", index);
                    break;
                case 4:
                    Console.WriteLine("{0}. Defend", index);
                    break;
                default:
                    Util.WriteInRed("Invalid input!");
                    break;
            }
        }


        internal static void BuffAnnounce(Dragon player1, Dragon player2)
        {
            for (int i = 0; i < player1.BuffDuration.GetLength(0); i++)
            {
                switch (i)
                {
                    case 0: break;
                    case 1: break;
                    case 2: break;
                    case 3:
                        if (player1.BuffDuration[3] > 0)
                        {

                            //if it's the first turn that the buff was applied
                            if (player1.BuffDuration[3] < 4)
                            {
                                Util.WriteInRed("==Pommel Debuff==");
                                Util.WriteInRed(player2.Name + " restored 1 resilience!");
                            }

                            player1.BuffDuration[3]--;
                            player2.Resilience++;

                            if (player1.BuffDuration[3] == 0)
                            {
                                Util.WriteInRed("The debuff wore off completely!");
                            }
                        }
                        break;
                    case 4:
                        if (player1.BuffDuration[4] > 0)
                        {
                            player1.BuffDuration[4]--;
                            player1.Resilience /= 2;
                        }
                        break;
                }
            }
        }

        internal static bool SkillActivationConfirm(int selection, List<int> skills, Dragon player)
        {
            bool confirm;
            switch (skills[selection-1])
            {
                case 0:
                    Console.WriteLine("Normal Strike: Just a regular attack onto your enemy");
                    Console.WriteLine("Costs nothing.");
                    Console.WriteLine("Has no cooldown.");
                    confirm = ConfirmSkillUse();
                    if (!confirm)
                    {
                        goto default;
                    }
                    return true;
                case 1:
                    Console.WriteLine("\nReckless Charge: An attack that deals much " +
                        "more damage at the cost of having lower accuracy.");
                    Console.WriteLine("Costs 25 stamina.");
                    Console.WriteLine("Has a cooldown of 1 turn.");
                    confirm = ConfirmSkillUse();
                    if (player.SkillCooldown[1] > 0)
                    {
                        Util.WriteInRed("This skill is currently on cooldown!");
                        Util.WriteInRed("Turn(s) remaining: " + player.SkillCooldown[1]);
                        goto default;
                    }
                    if (player.SP<25)
                    {
                        Util.WriteInRed("You do not have enough stamina to execute this skill!");
                        goto default;
                    }
                    if (!confirm) goto default;
                    return true;
                case 2:
                    Console.WriteLine("\nDouble Up: Perform two consecutive normal strikes.");
                    Console.WriteLine("Costs 30 stamina.");
                    Console.WriteLine("Has a cooldown of 2 turns.");
                    confirm = ConfirmSkillUse();
                    if (player.SkillCooldown[2] > 0)
                    {
                        Util.WriteInRed("This skill is currently on cooldown!");
                        Util.WriteInRed("Turn(s) remaining: " + player.SkillCooldown[2]);
                        goto default;
                    }
                    if (player.SP < 30)
                    {
                        Util.WriteInRed("You do not have enough stamina to execute this skill!");
                        goto default;
                    }
                    if (!confirm) goto default;
                    return true;
                case 3:
                    Console.WriteLine("\nPommel: A weak attack that targets the " +
                        "enemy's defenses. Reduces enemy's resilience by 3 for 3 turns.");
                    Console.WriteLine("Costs 20 stamina.");
                    Console.WriteLine("Has a cooldown of 5 turns.");
                    confirm = ConfirmSkillUse();
                    if (player.SkillCooldown[3] > 0)
                    {
                        Util.WriteInRed("This skill is currently on cooldown!");
                        Util.WriteInRed("Turn(s) remaining: " + player.SkillCooldown[3]);
                        goto default;
                    }
                    if (player.SP < 20)
                    {
                        Util.WriteInRed("You do not have enough stamina to execute this skill!");
                        goto default;
                    }
                    if (!confirm) goto default;
                    return true;
                case 4:
                    Console.WriteLine("\nDefend: Assumes a defensive stance. " +
                        "Doubles your resilience during this turn only.");
                    Console.WriteLine("This skill will always be performed first.");
                    Console.WriteLine("Costs nothing.");
                    Console.WriteLine("Has no cooldown.");
                    confirm = ConfirmSkillUse();
                    if (!confirm)
                    {
                        goto default;
                    }
                    return true;
                default:
                    return false;
            }
        }

        private static bool ConfirmSkillUse()
        {
            Console.Write("Use the skill? Y/N: ");
            if (Console.ReadLine().ToUpper() != "Y")
            {
                Console.WriteLine("Alright, let's select again then.\n");
                return false;

            }
            return true;
        }

    }
}
