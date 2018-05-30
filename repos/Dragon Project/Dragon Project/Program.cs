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

            Console.WriteLine("Hello and welcome to the Dragon World!");
            Util.SPause();
            Console.WriteLine("You are a traveller from another continent, seeking an exciting adventure");
            Console.WriteLine("However, this journey might be harder than you think...");

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
                Util.WriteLineInRed("You have been defeated!");
                Util.WriteLineInRed("Your adventure ends here!");
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
            int navigation;
            bool Viaderfore = false;

            Console.Clear();
            Console.WriteLine("Amazing, you're quite the fighter!");
            Console.WriteLine("Bandits have been appearing in these parts.");
            Console.WriteLine("Really terrorizing the locals here, I tell you.");

            Util.SPause();
            Console.WriteLine("\nSay, why don't you follow me to the nearest town?");
            Console.WriteLine("I think you would need a short break after all that!\n");

            Util.PressAnyKey();

            Console.Clear();
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
                    Console.WriteLine("3. Head out.");
                    Console.WriteLine("\nWhat do you wish to do?");
                    Console.Write("Your choice: ");
                    navigation = int.Parse(Console.ReadLine());
                    if (navigation < 1 || navigation > 3)
                    {
                        Console.Clear();
                        Util.WriteLineInRed("Such an option does not exist!");
                    }

                    if (navigation == 1)
                    {
                        bool ViaderforeTalk = false;
                        int ViaderforeTalkChoice;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Seems like there's a number of people here");
                            Console.WriteLine("1. The elderly man.");
                            Console.WriteLine("2. The armorclad fellow");
                            Console.WriteLine("3. The arrogant young man.");
                            Console.WriteLine("\nWho do you wish to talk to?");
                            Console.Write("Your choice: ");
                            ViaderforeTalkChoice = int.Parse(Console.ReadLine());
                            if (ViaderforeTalkChoice == 1)
                            {
                                Console.Clear();
                                ViaderForeOldMan();

                                Console.Write("\nTalk to another person? Y/N ");
                                if (Console.ReadLine().ToUpper() != "Y")
                                {
                                    ViaderforeTalk = true;
                                } else ViaderforeTalk = false;

                            }
                            if (ViaderforeTalkChoice == 2)
                            {
                                Console.Clear();
                                ViaderforeArmorcladFellow(player);

                                Console.Write("Accept Jeremy's challenge? Y/N ");
                                if (Console.ReadLine().ToUpper() == "Y")
                                {
                                    Console.WriteLine("this happened");
                                    enemy.Name = "Jeremy Evert";
                                    enemy.Type = "Fledgling Knight";
                                    enemy.AIBehaviorID = 1;
                                    enemy.CurrentLevel = 2;

                                    EnemyInitializationAndBattleStart(player, enemy);

                                    BattleInterface.BattleCycle(player, enemy);

                                }

                            }
                        } while (!ViaderforeTalk);


                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Util.WriteLineInRed("Error making selection! Did you input a letter?");
                }
            } while (!Viaderfore);
            

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

        private static void ViaderForeOldMan()
        {
            Console.WriteLine("You approached the old man sitting near a tree.");
            Util.WriteInGreen("\nOld Man: ");
            Console.WriteLine("A new face? I haven't seen that in a while.");
            Util.WriteInGreen("Old Man: ");
            Console.WriteLine("Well, here's a piece of advice...");
            Util.WriteInGreen("Old Man: ");
            Console.WriteLine("Capable newcomers will " +
                "eventually be recruited by the High King and sent " +
                "to face the Dragon King.");
            Util.WriteInGreen("Old Man: ");
            Console.WriteLine("The Dragon King has been an issue " +
                "for ages, and the High King wants him gone.");
            Util.WriteInGreen("Old Man: ");
            Console.WriteLine("If you value your life, do not dare face the" +
                " Dragon King");
            Util.WriteInGreen("Old Man: ");
            Console.WriteLine("Too many brave warriors have fallen... What a waste.");
        }

        private static void ViaderforeArmorcladFellow(Dragon player)
        {
            Console.WriteLine("You approached the armor-clad warrior smoking a " +
                "cigarette near the inn");

            Util.WriteInGreen("\nArmored Fellow: ");
            Console.WriteLine("Hey there!");

            Util.WriteInGreen("Armored Fellow: ");
            Console.WriteLine("Never seen your face before. You new here?");

            Console.WriteLine("\nYou introduced yourself to the fellow\n");

            Util.WriteInGreen("Armored Fellow: ");
            Console.WriteLine("I see, an adventurer, eh?");

            Util.WriteInGreen("Armored Fellow: ");
            Console.WriteLine("Nice to meet you, {0}! My name's Jeremy. " +
                "Jeremy Evert.", player.Name);

            Util.WriteInGreen("Jeremy: ");
            Console.WriteLine("Well, truth be told, there isn't much to do here." +
                " Just a good inn, couple shops to buy weapons and armors.");

            Util.WriteInGreen("Jeremy: ");
            Console.WriteLine("I'll personally just rest up and head out the very " +
                "next morning. This town has begun to bore me out already...");

            Util.WriteInGreen("Jeremy: ");
            Console.WriteLine("Anyways, you seem pretty powerful. I want to test " +
                "my skills before I join the High King's Legion.");

            Util.WriteInGreen("Jeremy: ");
            Console.WriteLine("Do you want to spar with me?\n");
        }

    }

}
