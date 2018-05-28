using System;

namespace Dragon_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            

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

            BattleInterface.StartTheBattle(player, player);
            DragonCreation.CreateDragon(player, player.Type);
            SkillSystem.InitialImplement(player);
            LevelSystem.InitialImplement(player);

            Console.Clear();

            var enemy = new Dragon();
            Console.WriteLine("Let's save the pleasantries for later, though.");
            Console.WriteLine("Looks like someone has a bone to pick with you.");
            Console.WriteLine("Let's quickly dispatch of this ruffian!");
            Util.LPause();
            enemy.Name = "Local Bandit";
            enemy.Type = "Noob";
            enemy.AIBehaviorID = 0;
            enemy.CurrentLevel = 1;

            DragonCreation.CreateDragon(enemy, enemy.Type);
            SkillSystem.InitialImplement(enemy);
            Console.WriteLine("\nHere he comes! Battle time!\n\n");

            BattleInterface.StartTheBattle(player, enemy);
            BattleInterface.DisplayStats(player);
            Util.MPause();
            BattleInterface.DisplayStats(enemy);

            Util.PressAnyKey();
            Console.Clear();

            int round = 1;

            do
            {
                BattleInterface.AllCooldownDrop(player, enemy);
                SkillSystem.BuffAnnounce(player, enemy);
                SkillSystem.BuffAnnounce(enemy, player);
                BattleInterface.VersusTime(player, enemy);

                if (player.HP > 0 && enemy.HP > 0)
                {
                    BattleInterface.RoundAnnounce(player, enemy, round);
                    round++;
                }

            } while (player.HP > 0 && enemy.HP > 0);

            if (player.HP < 0)
            {
                Util.LPause();
                Console.Clear();
                Util.WriteInRed("You have been defeated!");
                Util.WriteInRed("Your adventure ends here!");
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

            Console.WriteLine("Welcome to Viaderfore!");
            Console.WriteLine("Here, you will have a chance to rest up, buy items" +
                " and prepare yourselves before you head to your next location.");
            Util.SPause();
            Console.WriteLine("You also have the choice to talk to locals and maybe" +
                " learn some more about this area.");
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
                        Util.WriteInRed("Such an option does not exist!");
                    }

                    if (navigation == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Seems like there's a number of people here");
                        Console.WriteLine("1. The elderly man.");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Util.WriteInRed("Error making selection!");
                }
            } while (!Viaderfore);
            

            Console.WriteLine("\nFor now, your journey comes to an end");
            Console.WriteLine("Look forward for more updates in the near future!");
            Util.PressAnyKey();
        }
        
    }

}
