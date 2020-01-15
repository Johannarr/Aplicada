using System;
using System.IO;

namespace Ejercicio1
{
    public class Game
    {

        #region "Enums"

        public enum eGameState
        {
            Starting,
            Playing,
            Over
        }

        public enum AttemptResult
        {

            Guessed,
            Lower,
            Greater
        }

        #endregion

        #region "Atributes"

        const string DEFAULTPATH = "score.txt";
        const int MIN =1, MAX=1001;
        public int SecretNumber {get; set;}

        public eGameState CurrentState{get; set;}

        public int LastTry {get; set;}

        public int Attemps {get; set;}

        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}

        public TimeSpan TimeSpent
        {
            get
            {
                return EndTime.Subtract(StartTime);
            }
        }

        public string ScorePath {get;set;}


        #endregion

        #region "Behaviours"
        public void GameInit()
        {
            ScorePath = DEFAULTPATH;
            SecretNumber = GenerateNumber (MIN,MAX);
            CurrentState = eGameState.Starting;
            Attemps =0;
            StartTime = DateTime.Now;
        }

        private int GenerateNumber(int min, int max)
        {
            Random rdn = new Random();
            return rdn.Next(min,max);
        }


        public AttemptResult CheckIfGuessed()
        {
            Attemps++;
            if (LastTry == SecretNumber)
            {
                EndTime = DateTime.Now;
                 return AttemptResult.Guessed;
            }
               

            else if (LastTry > SecretNumber)
                return AttemptResult.Greater;
            else
                return AttemptResult.Lower;
        }

        public void SaveState()
        {
           /*using (FileStream fstream = File.Open(ScorePath, FileMode.Append))
           {
               UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
               unicodeEncoding.GetBytes($"Tiempo: {TimeSpent.TotalSeconds} - Intentos: {Attempts}");
    
               fstream.Write(Buffer,0,Buffer.Length);
           }*/

           var streamWriter = File.AppendText(ScorePath);
           streamWriter.Write($"Tiempo: {TimeSpent.TotalSeconds} - Intentos: {Attemps}");
           streamWriter.Flush();
           streamWriter.Close();
        }

        public string ReadScores()

        {
           
            return   File.ReadAllText (ScorePath);
        }
        #endregion
    }
}
