using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class ESWebClient : MonoBehaviour
{
    [Serializable]
    public class EsenciaScore
    {
        public int Id;
        public string PlayerName;
        public double BlueScore;
        public double PinkScore;
        public double YellowScore;
        public double RedScore;
        public double GreenScore;
        public double PurpleScore;

    }

    ScoreController _scoreController;
    UnityWebRequest www;
    const string webServiceURL = "https://localhost:44345/api/esencia";
    
    public void Awake()
    {
        _scoreController = GetComponent<ScoreController>();
    }
    public void SaveScore()
    {

      StartCoroutine(SendWebRequest());
        
    }

   public IEnumerator SendWebRequest()
    {
       
       EsenciaScore newScore = new EsenciaScore();
       newScore.Id = 0;
       newScore.PlayerName = "Joha";
       newScore.BlueScore = _scoreController._scores[0];
       newScore.GreenScore =  _scoreController._scores[1];
       newScore.PinkScore =  _scoreController._scores[2];
       newScore.PurpleScore =  _scoreController._scores[3];
       newScore.RedScore =  _scoreController._scores[4];
       newScore.YellowScore =  _scoreController._scores[5];

        www = UnityWebRequest.Put(webServiceURL, JsonUtility.ToJson(newScore));
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        //Debug.Log(www.downloadHandler.text);
    }

}
