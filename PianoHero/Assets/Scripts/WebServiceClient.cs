using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebServiceClient : MonoBehaviour
{

    // Aqui definimos una clase y le indicamos que es serializable, hacemos esto porque esta clase sera enviada mediante como json
    // y la serializacion nos permite guardar el estado de un objeto para asi poder ser recreado cuando sea necesario
    [Serializable]
    public class PianoHeroScore
    {
        public int Id;
        public string PlayerName;
        public float Score;
    }


    //definimos un unitywebrequest cuyo proposito principal es permitir que nuestro juego pueda interactuar con el backend de una aplicacion web
    // que en este caso sera un servicio web que guardara los scores
    UnityWebRequest www;

    //const string webServiceURL = "http://localhost:8888/request";

    //definimos la url del servicio web
    const string webServiceURL = "https://localhost:44345/api/values";
    

   //Esta funcion se encarga de mandar el objeto PianoHeroScore transformado a formato Json via http mediante el metodo put en el body.
   //Recibe como parametro el score obtenido desde el juego.
   public IEnumerator SendWebRequest(float score)
    {
       
       PianoHeroScore newScore = new PianoHeroScore();

       newScore.Id = 0;
       newScore.PlayerName = "Joha";
       newScore.Score = score;

       www = UnityWebRequest.Put(webServiceURL, JsonUtility.ToJson(newScore));
       www.SetRequestHeader("Content-Type", "application/json");
       yield return www.SendWebRequest();

       Debug.Log(www.downloadHandler.text);
    }

}
