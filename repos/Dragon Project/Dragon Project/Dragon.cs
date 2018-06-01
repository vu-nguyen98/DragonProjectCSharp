using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Project
{
    class Dragon
    {
        private String name;
        private int maxHP;
        private int maxSP;
        private int hP;
        private int sP;

        private int strength;
        private int endurance;
        private int resilience;
        private int speed;
        private int agility;
        private int luck;

        private int strGrowth;
        private int endGrowth;
        private int resGrowth;
        private int spdGrowth;
        private int agiGrwoth;
        private int lukGrowth;

        private double baseHitRate;
        private double baseEvdRate;
        private double baseCritRate;
        private double baseCritEvdRate;

        private double hitRate;
        private double evdRate;
        private double critRate;
        private double critEvdRate;

        private int attack;
        private int defense;
        private int weaponID;
        private int armorID;

        private String type;
        List<int> skills = new List<int>();
        int[] skillCooldown = new int[99];
        int[] buffDuration = new int[99];

        private int currentLevel;
        private int currentEXP;
        private int maximumEXP;
        private int gold;

        private int aIBehaviorID;

        public string Name { get => name; set => name = value; }
        public int MaxHP { get => (50 + Strength*2 + Endurance*5); set => maxHP = value; }
        public int MaxSP { get => (25 + Resilience*2 + Endurance*5); set => maxSP = value; }
        public int HP { get => hP; set => hP = value; }
        public int SP { get => sP; set => sP = value; }

        public int Strength { get => strength; set => strength = value; }
        public int Endurance { get => endurance; set => endurance = value; }
        public int Resilience { get => resilience; set => resilience = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Agility { get => agility; set => agility = value; }
        public int Luck { get => luck; set => luck = value; }

        public int StrGrowth { get => strGrowth; set => strGrowth = value; }
        public int EndGrowth { get => endGrowth; set => endGrowth = value; }
        public int ResGrowth { get => resGrowth; set => resGrowth = value; }
        public int SpdGrowth { get => spdGrowth; set => spdGrowth = value; }
        public int AgiGrowth { get => agiGrwoth; set => agiGrwoth = value; }
        public int LukGrowth { get => lukGrowth; set => lukGrowth = value; }

        public double BaseHitRate { get => baseHitRate; set => baseHitRate = value; }
        public double BaseEvdRate { get => baseEvdRate; set => baseEvdRate = value; }
        public double BaseCritRate { get => baseCritRate; set => baseCritRate = value; }
        public double BaseCritEvdRate { get => baseCritEvdRate; set => baseCritEvdRate = value; }

        public double HitRate { get => (BaseHitRate + Agility * 2.2 + Luck); set => hitRate = value; }
        public double EvdRate { get => (BaseEvdRate + Speed * 2.2 + Luck); set => evdRate = value; }
        public double CritRate { get => (BaseCritRate + Agility + Luck * 1.5); set => critRate = value; }
        public double CritEvdRate { get => (baseCritEvdRate + Speed * 0.5 + Luck); set => critEvdRate = value; }


        public int Attack { get => (Strength * 3 + Agility); set => attack = value; }
        public int Defense { get => (Resilience * 3 + Speed / 4); set => defense = value; }
        public int WeaponID { get => weaponID; set => weaponID = value; }
        public int ArmorID { get => armorID; set => armorID = value; }

        public string Type { get => type; set => type = value; }
        public List<int> Skills { get => skills; set => skills = value; }
        public int[] SkillCooldown { get => skillCooldown; set => skillCooldown = value; }
        public int[] BuffDuration { get => buffDuration; set => buffDuration = value; }

        public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
        public int CurrentEXP { get => currentEXP; set => currentEXP = value; }
        public int MaximumEXP { get => maximumEXP; set => maximumEXP = value; }
        public int Gold { get => gold; set => gold = value; }

        public int AIBehaviorID { get => aIBehaviorID; set => aIBehaviorID = value; }
    }
}
