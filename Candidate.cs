using System;
using System.Collections.Generic;
using System.Text;

namespace Paskaita10uzduotis2
{
    class Candidate
    {
        public string nameSurname { get; set; }
        public int mindBattles { get; set; }
        public int answere { get; set; }
        public int time { get; set; }
        public Candidate() { }
        public Candidate(string nameSurname, int mindBattles, int answere, int time)
        {
            this.nameSurname = nameSurname;
            this.mindBattles = mindBattles;
            this.answere = answere;
            this.time = time;
        }
        public override string ToString()
        {               // vieno objekto išvedimo formatas
            return String.Format("{0,-20} {1,20} {2,20} {3,22}", nameSurname, mindBattles, answere, time);
        }
        public static bool operator >(Candidate candid1, Candidate candid2)
        {               // operatoriaus > sąlyga
            int positionABC = String.Compare(candid1.nameSurname, candid2.nameSurname, StringComparison.CurrentCulture);

            return ((candid1.answere > candid2.answere) ||
                ((candid1.answere == candid2.answere) && (candid1.time < candid2.time)) ||
                ((candid1.answere == candid2.answere) && (candid1.time == candid2.time) && (candid1.mindBattles > candid2.mindBattles)) ||
                ((candid1.answere == candid2.answere) && (candid1.time == candid2.time) && (candid1.mindBattles == candid2.mindBattles) && (positionABC < 1)));
        }
        public static bool operator <(Candidate candid1, Candidate candid2)
        {               // operatoriaus < sąlyga
            int positionABC = String.Compare(candid1.nameSurname, candid2.nameSurname, StringComparison.CurrentCulture);

            return ((candid1.answere < candid2.answere) ||
                ((candid1.answere == candid2.answere) && (candid1.time > candid2.time)) ||
                ((candid1.answere == candid2.answere) && (candid1.time == candid2.time) && (candid1.mindBattles < candid2.mindBattles)) ||
                ((candid1.answere == candid2.answere) && (candid1.time == candid2.time) && (candid1.mindBattles == candid2.mindBattles) && (positionABC == 1)));
        }
    }
}
