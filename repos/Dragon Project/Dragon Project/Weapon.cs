using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon_Project
{
    class Weapon
    {
        private int iD;
        private String description;

        private int might;
        private int hitRate;
        private int critRate;
        private int evdRate;
        private int critEvdRate;

        private int strBonus;
        private int endBonus;
        private int resBonus;
        private int spdBonus;
        private int agiBonus;
        private int lukBonus;

        public int ID { get => iD; set => iD = value; }
        public string Description { get => description; set => description = value; }

        public int Might { get => might; set => might = value; }
        public int HitRate { get => hitRate; set => hitRate = value; }
        public int CritRate { get => critRate; set => critRate = value; }
        public int EvdRate { get => evdRate; set => evdRate = value; }
        public int CritEvdRate { get => critEvdRate; set => critEvdRate = value; }

        public int StrBonus { get => strBonus; set => strBonus = value; }
        public int EndBonus { get => endBonus; set => endBonus = value; }
        public int ResBonus { get => resBonus; set => resBonus = value; }
        public int SpdBonus { get => spdBonus; set => spdBonus = value; }
        public int AgiBonus { get => agiBonus; set => agiBonus = value; }
        public int LukBonus { get => lukBonus; set => lukBonus = value; }
    }
}
