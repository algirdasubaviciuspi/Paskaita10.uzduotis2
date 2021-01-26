using System;
using System.IO;

namespace Paskaita10uzduotis2
{
    class Program
    {
        const string CData = "..\\..\\..\\Duomenys.txt";
        const string CData2 = "..\\..\\..\\Duomenys2.txt";
        const string CFr = "..\\..\\..\\Rezultatai2.txt";
        static void Main(string[] args)
        {
            CandidatesContainer ListOfCandidates = new CandidatesContainer();
            CandidatesContainer ListOfCandidates2 = new CandidatesContainer();

            ReadData(CData, ListOfCandidates);
            ReadData(CData2, ListOfCandidates2);

            if (File.Exists(CFr))
                File.Delete(CFr);

            PrintCandidatesTable(CFr, "Pradinis kandidatų sąrašas", ListOfCandidates);
            PrintCandidatesTable(CFr, "Naujų kandidatų sąrašas", ListOfCandidates2);

            ListOfCandidates.Sort();
            ListOfCandidates2.Sort();

            PrintCandidatesTable(CFr, "Surūšiuotas pradinis kandidatų sąrašas", ListOfCandidates);
            PrintCandidatesTable(CFr, "Surūšiuotas naujų kandidatų sąrašas", ListOfCandidates2);

            InsertCandidates(ListOfCandidates, ListOfCandidates2);
            PrintCandidatesTable(CFr, "Duomenys po įterpimo", ListOfCandidates);
        }
        static void ReadData(string file, CandidatesContainer Candid)
        {           // nuskaito duomenis iš failo
            if (File.Exists(file))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts;
                        parts = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        string nameSurname = parts[0].Trim();
                        int mindBattles = int.Parse(parts[1]);
                        int answere = int.Parse(parts[2]);
                        int time = int.Parse(parts[3]);

                        Candidate newCandid = new Candidate(nameSurname, mindBattles, answere, time);
                        Candid.AddCandidate(newCandid);
                    }
                }
            }
        }
        static void PrintCandidatesTable(string file, string tableName, CandidatesContainer Candid)
        {               // spausdina lentelę į failą
            using (var fr = File.AppendText(file))
            {
                fr.WriteLine(tableName);
                if (Candid.n > 0)
                {
                    string tableHead = new string('-', 87) + '\n' +
                         String.Format("{0,-20} {1,20} {2,20} {3,22}", "Vardas ir pavardė", "Prieš tai dalyvavęs", "Teisingi atsakymai", "Sugaištas laikas (sek.)") + '\n' +
                         new string('-', 87);
                    fr.WriteLine(tableHead);
                    for (int i = 0; i < Candid.n; i++)
                    {
                        fr.WriteLine(Candid.CandidatesArray[i].ToString());
                    }
                    fr.WriteLine(new string('-', 87));
                }
                else
                {
                    fr.WriteLine("Sąrašas tuščias");
                }
                fr.WriteLine();
            }
        }
        static void InsertCandidates(CandidatesContainer Candid1, CandidatesContainer Candid2)
        {               // iš 2-ojo sąrašo tvarkingai įterpia į rikiuotą 1-ąjį
            int startInd = 0;
            int j = 0;
            bool notFool = true;
            while ((j < Candid2.n) && (notFool))
                Candid1.Insert(ref startInd, ref notFool, Candid2.CandidatesArray[j++]);
        }
    }
}
