using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebServiceClient : MonoBehaviour
{

    [Serializable]
    public class PianoHeroScore
    {
        public int Id;
        public string PlayerName;
        public float Score;
    }
    /*public class GravilotaScore
    {
        public int id;
        public string playerName;
        public float score;
    }*/

    UnityWebRequest www;
    //const string webServiceURL = "http://localhost:8888/request";
    const string webServiceURL = "https://localhost:44345/api/values";
    
    void Start()
    {

    }

   public IEnumerator SendWebRequest(float score)
    {
       
       //GravilotaScore newScore = new GravilotaScore();
       PianoHeroScore newScore = new PianoHeroScore();

       //newScore.id = 20;
       //newScore.playerName = "Karvin";
       //newScore.score = score;

       newScore.Id = 0;
       newScore.PlayerName = "Joha";
       newScore.Score = score;

       www = UnityWebRequest.Put(webServiceURL, JsonUtility.ToJson(newScore));
       www.SetRequestHeader("Content-Type", "application/json");
       yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);
    }

}
