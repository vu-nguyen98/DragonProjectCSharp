using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Project
{
    class Town
    {
        private String townName;

        private bool inTown;
        private bool inTalk;
        private bool inWeaponStore;
        private bool inArmorStore;
        private bool inItemStore;
        private int navigation;
        private int talkChoice;

        public string TownName { get => townName; set => townName = value; }

        public bool InTown { get => inTown; set => inTown = value; }
        public bool InTalk { get => inTalk; set => inTalk = value; }
        public bool InWeaponStore { get => inWeaponStore; set => inWeaponStore = value; }
        public bool InArmorStore { get => inArmorStore; set => inArmorStore = value; }
        public bool InItemStore { get => inItemStore; set => inItemStore = value; }
        public int Navigation { get => navigation; set => navigation = value; }
        public int TalkChoice { get => talkChoice; set => talkChoice = value; }

        private static void InsertName(String name)
        {
            Util.WriteInGreen(name);
            Util.WriteInGreen(": ");
        }

        //contains all the dialogue for Viaderfore
        public class Vdrfr 
        {

            internal static void OldMan()
            {
                String name = "Old Man";
                Console.WriteLine("You approached the old man sitting near a tree.\n");

                InsertName(name);
                Console.WriteLine("A new face? I haven't seen that in a while.");

                InsertName(name);
                Console.WriteLine("Well, here's a piece of advice from this old man...");

                InsertName(name);
                Console.WriteLine("Know that capable people from all around will " +
                    "eventually be recruited by the High King and sent " +
                    "to face the Dragon King.");

                InsertName(name);
                Console.WriteLine("The Dragon King has been a nuisance " +
                    "for ages, and the High King wants him gone.");

                InsertName(name);
                Console.WriteLine("If you value your life, do not dare face the" +
                    " Dragon King");

                InsertName(name);
                Console.WriteLine("Too many brave warriors have fallen... What a waste.");
            }

            internal static void ArmorcladFellow(Dragon player)
            {
                String name = "Armored Fellow";
                Console.WriteLine("You approached the armor-clad warrior smoking a " +
                    "cigarette near the inn.\n");

                InsertName(name);
                Console.WriteLine("Oh, howdy.");

                InsertName(name);
                Console.WriteLine("Never seen your face before. You new here?");

                Console.WriteLine("\nYou introduced yourself to the fellow.\n");

                InsertName(name);
                Console.WriteLine("I see, an adventurer, eh?");

                InsertName(name);
                Console.WriteLine("It is a pleasure to meet you, {0}. I am Jeremy of " +
                    "House Evert.", player.Name);

                name = "Jeremy";

                InsertName(name);
                Console.WriteLine("An adventurer has got to visit exotic places " +
                    "and enjoy a new culture, correct?");

                InsertName(name);
                Console.WriteLine("But, truth be told, there is not much to do here." +
                    " Just a good inn, couple shops to buy weapons and armors.");

                InsertName(name);
                Console.WriteLine("It is not a bad town by any stretch of the imagination" +
                    ", but it doesn't provide much excitement either.");
                InsertName(name);
                Console.WriteLine("If I were you, I'll just rest of at the inn and head" +
                    " out the very next morning, before the boredom takes over your " +
                    "sanity.");

                InsertName(name);
                Console.WriteLine("In anyway you seem quite powerful.");

                InsertName(name);
                Console.WriteLine("I want to test my skills against capable fighters" +
                    " before I go to join the High King's Legion.");

                InsertName(name);
                Console.WriteLine("Do you want to have a spar?\n");
            }

            internal static void ChallengeNotMaxHP()
            {
                String name = "Jeremy";

                InsertName(name);
                Console.WriteLine("Hm? You seem to be quite injured.");

                InsertName(name);
                Console.WriteLine("I really do not think you should fight me in" +
                    " this state. That would just be unfair for you.");

                InsertName(name);
                Console.WriteLine("Rest up at the inn, friend. I will be here" +
                    " if you still want to fight.");

            }

            internal static void ChallengeReject()
            {
                String name = "Jeremy";

                InsertName(name);
                Console.WriteLine("Aah, that is quite a shame");

                InsertName(name);
                Console.WriteLine("Well, it cannot be helped.");

                InsertName(name);
                Console.WriteLine("I will just be here in case you change your mind.");
            }

            internal static void ChallengeWin()
            {
                throw new NotImplementedException();
            }

            internal static void ChallengeLost(Dragon player)
            {
                throw new NotImplementedException();
            }
        }
        
    }
}
