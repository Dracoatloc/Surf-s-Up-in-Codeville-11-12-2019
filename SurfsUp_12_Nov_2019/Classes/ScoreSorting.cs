using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SurfsUp_12_Nov_2019.Classes;

namespace SurfsUp_12_Nov_2019.Classes
{
    class ScoreSorting
    {
        static public List<Tuple<float, string>> SortScores()
        {
            string[] unsortedScores = FileReader.ReadFile();    //essential
            List<float> score = new List<float>();              //essential
            List<Tuple<float, string>> tempList = new List<Tuple<float, string>>();

            int j = 0;

            for (int i = 0; i < unsortedScores.Count(); i++)
            {
                string t = "";
                float z = 0;
                string n = "";
                foreach (char c in unsortedScores[i])
                {
                    if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '.')
                    {
                        t = t + c;
                    }
                    else if (c == ',')
                    {
                        continue;
                    }
                    else
                    {
                        n = n + c;
                    }
                }
                z = float.Parse(t);

                score.Add(z);

                if (z == 0)
                {
                    continue;
                }
                else
                {
                    tempList.Add(Tuple.Create(z, n));
                }
                j++;
            }

            List<Tuple<float, string>> scoresAndDictionary = new List<Tuple<float, string>>();
            float temp = 0;

            for (int i = 0; i < score.Count() - 1; i++)
            {
                for (j = 0; j < score.Count() - 1; j++)
                {
                    if (score[j] < score[j + 1])
                    {
                        continue;
                    }
                    else if (score[j] > score[j + 1])
                    {
                        temp = score[j];
                        score[j] = score[j + 1];
                        score[j + 1] = temp;
                    }
                }
            }

            for(int i = 0; i < score.Count(); i++)
            {
                for(int k = 0; k < score.Count(); k++)
                {
                    if(score[i] == tempList[k].Item1)
                    {
                        scoresAndDictionary.Add(Tuple.Create(score[i], tempList[k].Item2));
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            for (int i = 0; i < scoresAndDictionary.Count(); i++)
            {
                for (int k = 0; k < scoresAndDictionary.Count(); k++)
                {
                    if ((scoresAndDictionary[i].Item1 == scoresAndDictionary[k].Item1) && (scoresAndDictionary[i].Item2 == scoresAndDictionary[k].Item2))
                    {
                        if (i == k)
                        {
                            continue;
                        }
                        else
                        {
                            scoresAndDictionary.RemoveAt(k);
                        }
                    }
                }
            }
            return scoresAndDictionary;
        }

        static public void DisplayScores()
        {
            if (Validator.ValidateFile() == true) //Checks if there's a file with the proper name and path
            {                                     //If true, there's no problem.
            }
            else                                  //If there's an error with the file, it will display it to the user and prevent any further progress of the system.
            {
                Console.WriteLine("No hay archivo disponible, verifique que exista uno. ") ;
                Console.ReadKey();
                Environment.Exit(0);
            }
            List<Tuple<float, string>>sortedScores; //List of tuples holding a score and name per index
            sortedScores = ScoreSorting.SortScores();
            for(int i = 1; i < 4; i++)
            {
                Console.WriteLine(sortedScores[sortedScores.Count()-i].Item2 + " " + sortedScores[sortedScores.Count()-i].Item1);
                Console.WriteLine();
            }
            Console.ReadKey();
            return;
        }
    }
}
