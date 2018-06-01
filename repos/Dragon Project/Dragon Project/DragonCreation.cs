using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Project
{
    class DragonCreation
    {
        internal static void CreateDragon(Dragon newDragon, String type)
        {
            if (newDragon.Type == "All Rounder")
            {
                BaseStatDistribution(newDragon, 8, 5, 5, 5, 5, 5,
                                     60, 60, 60, 60, 60, 50,
                                     80, 10, 12, 7);
            }

            if (newDragon.Type == "Vanguard")
            {
                BaseStatDistribution(newDragon, 7, 6, 4, 4, 4, 5,
                                     80, 65, 55, 45, 55, 50,
                                     75, 5, 16, 5);
            }

            if (newDragon.Type == "Guardian")
            {
                BaseStatDistribution(newDragon, 5, 7, 7, 3, 3, 5,
                                     60, 75, 80, 50, 35, 50,
                                     78, 16, 8, 10);
            }

            if (newDragon.Type == "Assassin")
            {
                BaseStatDistribution(newDragon, 6, 2, 2, 7, 7, 5,
                                     75, 45, 45, 70, 75, 50,
                                     85, 15, 15, 10);
            }

            if (newDragon.Type == "Late Bloomer")
            {
                BaseStatDistribution(newDragon, 4, 2, 3, 3, 3, 3,
                                     75, 60, 60, 55, 75, 55,
                                     77, 8, 9, 4);
            }

            ///////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////

            if (newDragon.Type == "Bandit")
            {
                BaseStatDistribution(newDragon, 8, 3, 3, 3, 3, 6,
                                     45, 45, 45, 45, 45, 45,
                                     80, 4, 7, 3);
            }

            if (newDragon.Type == "Fledgling Knight")
            {
                BaseStatDistribution(newDragon, 7, 7, 9, 9, 5, 4,
                                     45, 45, 45, 45, 45, 45,
                                     85, 15, 8, 8);
            }
        }

        internal static void SelectType(Dragon newDragon)
        {
            String[] TypeSelections = new String[] { "All Rounder", "Vanguard",
                                                     "Guardian", "Assassin",
                                                     "Late Bloomer"};
            String[] TypeExplanations = new String[TypeSelections.Length];
            int index = 1;
            int selection = 0;
            PopulateTypeExplanations(TypeExplanations);

            Console.WriteLine("You seem to be capable of fighting. That skill will come in handy in this world.");
            Util.SPause();
            Console.WriteLine("Hmm... Just what type of combatant are you, though?\n\n");
            Util.MPause();
            Console.WriteLine("=======================================");
            Console.WriteLine("It's time to select your starting type!");
            Console.WriteLine("Your type will influence your stats and obtainable skills!");
            Console.WriteLine("Here are the list of types that you can choose from!\n");
            foreach (String type in TypeSelections)
            {
                Console.WriteLine("{0}. {1}", index, type);
                index++;
            }

            bool validDragonType = false;
            do
            {
                try
                {
                    Util.SPause();
                    Console.WriteLine("\nEnter the number of the type you would like.");
                    Console.WriteLine("You can also enter 0 for an explanation of each type.");
                    Console.Write("Selection: ");
                    selection = int.Parse(Console.ReadLine());
                    if (selection > 0 && selection < TypeSelections.Length + 1)
                    {
                        validDragonType = true;
                        newDragon.Type = TypeSelections[selection - 1];
                        Console.WriteLine("Type selected is {0}.", newDragon.Type);
                        Console.Write("Continue with choice? Y/N: ");
                        if (Console.ReadLine().ToUpper() != "Y")
                        {
                            validDragonType = false;
                            Console.WriteLine("Alright, let's select again then.");
                        }
                    }
                    else if (selection == 0)
                    {
                        Console.WriteLine();
                        validDragonType = false;
                        index = 0;
                        foreach (var type in TypeExplanations)
                        {
                            Console.WriteLine("{0}: {1}", TypeSelections[index], type);
                            index++;
                        }
                    }
                    else
                    {
                        validDragonType = false;
                        Util.WriteLineInRed("\nThis is an invalid dragon type!");
                        Util.SPause();
                        Util.WriteLineInRed("Please enter a valid dragon type from the list!");
                    }
                }
                catch (FormatException)
                {
                    Util.WriteLineInRed("\nError choosing dragon type!");
                }
                
            } while (!validDragonType);

        }

        private static void PopulateTypeExplanations(string[] explArr)
        {
            explArr[0] = "Jack of all trades, master of none, the versatility of this class is immensely useful.";
            explArr[1] = "A purely offensive class that employs brute strength to overpower its enemies.";
            explArr[2] = "A more defensive class with many skills that allow it to outlive its adversaries.";
            explArr[3] = "Crafty and lightning quick, this class allows for many clever ways to defeat its enemies.";
            explArr[4] = "A diamond in the rough. The potential this class holds is unknown.";
        }

        private static void BaseStatDistribution(Dragon newDragon,
                                                  int newStrength, int newEndurance,
                                                  int newResilience, int newSpeed,
                                                  int newAgility, int newLuck,

                                                  int newStrGrowth, int newEndGrowth,
                                                  int newResGrowth, int newSpdGrowth,
                                                  int newAgiGrowth, int newLukGrowth,

                                                  int newBaseHitRate, int newBaseEvdRate,
                                                  int newBaseCritRate, int newBaseCritEvdRate
                                                  )
        {
            newDragon.Strength = newStrength;
            newDragon.Endurance = newEndurance;
            newDragon.Resilience = newResilience;
            newDragon.Speed = newSpeed;
            newDragon.Agility = newAgility;
            newDragon.Luck = newLuck;

            newDragon.StrGrowth = newStrGrowth;
            newDragon.EndGrowth = newEndGrowth;
            newDragon.ResGrowth = newResGrowth;
            newDragon.SpdGrowth = newSpdGrowth;
            newDragon.AgiGrowth = newAgiGrowth;
            newDragon.LukGrowth = newLukGrowth;

            newDragon.BaseHitRate = newBaseHitRate;
            newDragon.BaseEvdRate = newBaseEvdRate;
            newDragon.BaseCritRate = newBaseCritRate;
            newDragon.BaseCritEvdRate = newBaseCritEvdRate;
            
        }

    }
}
