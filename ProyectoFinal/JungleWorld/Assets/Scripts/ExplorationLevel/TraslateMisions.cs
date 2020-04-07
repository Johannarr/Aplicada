using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TraslateMisions : MonoBehaviour
{

    string _sceneName;
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Submit") && other.gameObject.tag.ToString().Contains("Player"))
        {
             _sceneName = "MapLevels";
                  
        }

     SceneManager.LoadScene(_sceneName);
    }
}
