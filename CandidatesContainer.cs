using System;
using System.Collections.Generic;
using System.Text;

namespace Paskaita10uzduotis2
{
    class CandidatesContainer
    {
        const int Cmax = 10000;
        public int n { get; set; }
        public Candidate[] CandidatesArray { get; set; }
        public CandidatesContainer()
        {
            n = 0;
            CandidatesArray = new Candidate[Cmax];
        }
        public void AddCandidate(Candidate c)       // + naujas objektas
        {
            if (n < Cmax)
                CandidatesArray[n++] = c;
        }
        public void Sort()                          // rikiuoja objektų sąrašą
        {
            for (int i = 0; i < n - 1; i++)
            {
                int maxInd = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (CandidatesArray[j] > CandidatesArray[maxInd])
                        maxInd = j;
                }
                Candidate temp = CandidatesArray[maxInd];
                CandidatesArray[maxInd] = CandidatesArray[i];
                CandidatesArray[i] = temp;
            }
        }
        public void Insert(ref int startInd, ref bool notFool, Candidate newCandidate)
        {                                           // įterpia naują objektą į surikiuotą sąrašą
            int insertionInd = n;
            for (int i = startInd; i < n; i++)
            {
                if (newCandidate > CandidatesArray[i])
                {
                    insertionInd = i;
                    break;
                }
            }
            if (n < Cmax)
            {
                for (int i = n; i > insertionInd; i--)
                    CandidatesArray[i] = CandidatesArray[i - 1];
                n++;
                CandidatesArray[insertionInd] = newCandidate;
                startInd = insertionInd;
            }
            else
            {
                Console.WriteLine("Kandidatų sąrašas pilnas");
                notFool = false;
            }
        }
    }
}
