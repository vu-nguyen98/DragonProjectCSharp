using System;

namespace Dragon_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("...");
            Util.SPause();
            Console.Write("..");
            Util.SPause();
            Console.Write("..");
            Util.SPause();

            Console.WriteLine("\n\nIt has been quite a long journey from your hometown...");
            Console.WriteLine("Seeking an exciting adventure, you hopped on a ship to another continent.");
            Console.WriteLine("What new fate awaits you...?");

            Console.WriteLine("\n===========DRAGON PROJECT===========\n");

            Console.WriteLine("It's high noon in Ocuraho, the Dragon Continent.");
            Console.WriteLine("You are not aware of why they call it that.");
            Console.WriteLine("");

            var player = new Dragon();
            Console.WriteLine("But first of all, please tell me your name...");
            Console.Write("Your name: ");
            player.Name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("It's a pleasure to meet you, {0}!", player.Name);
            DragonCreation.SelectType(player);
            DragonCreation.CreateDragon(player, player.Type);
            SkillSystem.InitialImplement(player);
            LevelSystem.InitialImplement(player);

            Console.Clear();

            var enemy = new Dragon();
            Console.WriteLine("Let's save the pleasantries for later, though.");
            Console.WriteLine("Looks like someone has a bone to pick with you.");
            Console.WriteLine("Let's quickly dispatch of this ruffian!");
            Console.WriteLine("\nHere he comes! Battle time!\n\n");

            Util.LPause();
            enemy.Name = "Local Bandit";
            enemy.Type = "Bandit";
            enemy.AIBehaviorID = 0;
            enemy.CurrentLevel = 1;

            DragonCreation.CreateDragon(enemy, enemy.Type);
            SkillSystem.InitialImplement(enemy);

            BattleInterface.StartTheBattle(player, enemy);
            BattleInterface.DisplayStats(player);
            Util.MPause();
            BattleInterface.DisplayStats(enemy);

            Util.PressAnyKey();
            Console.Clear();

            BattleInterface.BattleCycle(player, enemy);

            if (player.HP < 0)
            {
                Util.LPause();
                Console.Clear();
                Util.WriteLineInRed("The bandit ended your life, moments after " +
                    "you set foot on the continent.");
                Util.WriteLineInRed("What a truly foolish end...");
                Util.PressAnyKey();
                Environment.Exit(0);
            }
            if (player.HP > 0)
            {
                Util.LPause();
                Console.Clear();
                Console.WriteLine("{0}'s health dropped to 0!", enemy.Name);
                Console.WriteLine("Victory!\n");
                Util.SPause();
                LevelSystem.AddExperience(40, player);
            }

            Util.LPause();
            Console.WriteLine();
            Util.PressAnyKey();

            ////////////////////////////////////////////////////////////////
            Console.Clear();
            Console.WriteLine("Amazing, you're quite the fighter!");
            Console.WriteLine("Bandits have been appearing in these parts.");
            Console.WriteLine("Really terrorizing the locals here, I tell you.");

            Util.SPause();
            Console.WriteLine("\nSay, why don't you follow me to the nearest town?");
            Console.WriteLine("I think you would need a short break after all that!\n");

            Util.PressAnyKey();
            Console.Clear();

            Town Vdrfr = new Town();

            Console.WriteLine("Welcome to Viaderfore!");
            Console.WriteLine("Here, you will have a chance to rest up, buy items" +
                " and prepare yourself before you head to your next location.");
            Util.SPause();
            Console.WriteLine("You also have the choice to talk to locals and maybe" +
                " learn some more about this area.\n");
            Util.SPause();
            Util.PressAnyKey();
            Console.Clear();

            do
            {
                try
                {
                    Console.WriteLine("Here are the things you can do at this moment in time");
                    Console.WriteLine("1. Talk to someone.");
                    Console.WriteLine("2. Rest up at an inn.");
                    Console.WriteLine("3. Visit the weapon store.");
                    Console.WriteLine("4. Visit the item store.");
                    Console.WriteLine("5. Head out.");
                    Console.WriteLine("\nWhat do you wish to do?");
                    Console.Write("Your choice: ");
                    Vdrfr.Navigation = int.Parse(Console.ReadLine());

                    if (Vdrfr.Navigation < 1 || Vdrfr.Navigation > 5)
                    {
                        Console.Clear();
                        Util.WriteLineInRed("Such an option does not exist!");
                    }

                    if (Vdrfr.Navigation == 1)
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Seems like there's a number of people here");
                            Console.WriteLine("1. The elderly man.");
                            Console.WriteLine("2. The armorclad fellow");
                            Console.WriteLine("3. The arrogant young man.");
                            Console.WriteLine("\nWho do you wish to talk to?");
                            Console.Write("Your choice: ");
                            Vdrfr.TalkChoice = int.Parse(Console.ReadLine());
                            if (Vdrfr.TalkChoice == 1)
                            {
                                Console.Clear();
                                Town.Vdrfr.OldMan();

                                Console.Write("\nTalk to another person? Y/N ");
                                if (Console.ReadLine().ToUpper() != "Y")
                                {
                                    Vdrfr.InTalk = true;
                                }
                                else Vdrfr.InTalk = false;

                            }
                            if (Vdrfr.TalkChoice == 2)
                            {
                                Console.Clear();
                                Town.Vdrfr.ArmorcladFellow(player);

                                Console.Write("Accept Jeremy's challenge? Y/N ");
                                if (Console.ReadLine().ToUpper() == "Y")
                                {
                                    if (player.HP < player.MaxHP)
                                    {
                                        Console.Clear();
                                        Town.Vdrfr.ChallengeNotMaxHP();

                                        Console.Write("\nTalk to another person? Y/N ");
                                        if (Console.ReadLine().ToUpper() != "Y")
                                        {
                                            Vdrfr.InTalk = true;
                                        }
                                        else Vdrfr.InTalk = false;

                                    }
                                    else
                                    {
                                        enemy.Name = "Jeremy Evert";
                                        enemy.Type = "Fledgling Knight";
                                        enemy.AIBehaviorID = 1;
                                        enemy.CurrentLevel = 2;

                                        EnemyInitializationAndBattleStart(player, enemy);
                                        BattleInterface.BattleCycle(player, enemy);

                                        if (player.HP > 0)
                                        {
                                            Town.Vdrfr.ChallengeWin();
                                        }
                                        if (player.HP < 0)
                                            Town.Vdrfr.ChallengeLost(player);
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Town.Vdrfr.ChallengeReject();
                                    Console.Write("\nTalk to another person? Y/N ");
                                    if (Console.ReadLine().ToUpper() != "Y")
                                    {
                                        Vdrfr.InTalk = true;
                                    }
                                    else Vdrfr.InTalk = false;
                                }

                            }
                            if (Vdrfr.TalkChoice == 3)
                            {
                                Console.Clear();
                            }
                        } while (!Vdrfr.InTalk);


                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Util.WriteLineInRed("Error making selection! Did you input a letter?");
                }
            } while (!Vdrfr.InTown);


            Console.WriteLine("\nFor now, your journey comes to an end");
            Console.WriteLine("Look forward for more updates in the near future!");
            Util.PressAnyKey();
        }

        private static void EnemyInitializationAndBattleStart(Dragon player, Dragon enemy)
        {
            DragonCreation.CreateDragon(enemy, enemy.Type);
            SkillSystem.InitialImplement(enemy);
            BattleInterface.StartTheBattle(player, enemy);
            BattleInterface.DisplayStats(player);
            Util.MPause();
            BattleInterface.DisplayStats(enemy);
            Util.PressAnyKey();
            Console.Clear();
        }





    }

}
