using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoaderController : MonoBehaviour
{

    string _sceneName;
    public void OnTriggerStay (Collider other)
    {
        if (Input.GetButtonDown("Submit"))
        {
            switch(gameObject.name)
            {
                case "GameLoader1":
                _sceneName="FlappyBird";
                break;
             }
            
        }

    SceneManager.LoadScene(_sceneName);
    }
    // Start is called before the first frame update
}
