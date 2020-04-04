using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class CrocoWebClient : MonoBehaviour
{
    [Serializable]
    public class CrocodileScore
    {
        public int Id;
        public string PlayerName;
        public double BlueScore;
        public double GreenScore;
        public double RedScore;
        public double OrangeScore;
        public double FrogScore;
        
    }

    CrocoScoreController _scoreController;
    UnityWebRequest www;
    const string webServiceURL = "https://localhost:44345/api/crocodile";
    
    public void Awake()
    {
        _scoreController = GetComponent<CrocoScoreController>();
    }
    public void SaveScore()
    {

      StartCoroutine(SendWebRequest());
        
    }

   public IEnumerator SendWebRequest()
    {
       
       CrocodileScore newScore = new CrocodileScore();
       newScore.Id = 0;
       newScore.PlayerName = "Joha";
       newScore.BlueScore = _scoreController._scores[0];
       newScore.GreenScore =  _scoreController._scores[1];
       newScore.RedScore =  _scoreController._scores[2];
       newScore.OrangeScore =  _scoreController._scores[3];
       newScore.FrogScore =  _scoreController._scores[4];
       
        www = UnityWebRequest.Put(webServiceURL, JsonUtility.ToJson(newScore));
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        //Debug.Log(www.downloadHandler.text);
    }

}
