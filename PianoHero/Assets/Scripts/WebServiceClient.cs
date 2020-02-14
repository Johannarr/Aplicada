using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebServiceClient : MonoBehaviour
{

    [Serializable]
    public class GravilotaScore
    {
        public int id;
        public string playerName;
        public float score;
    }
    UnityWebRequest www;
    const string webServiceURL = "http://localhost:8888/request";
    
    void Start()
    {

    }

   public IEnumerator SendWebRequest(float score)
    {
       
       GravilotaScore newScore = new GravilotaScore();

       newScore.id = 20;
       newScore.playerName = "Karvin";
       newScore.score = score;

       www = UnityWebRequest.Put(webServiceURL, JsonUtility.ToJson(newScore));
       www.SetRequestHeader("Content-Type", "application/json");
       yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);
    }

}
