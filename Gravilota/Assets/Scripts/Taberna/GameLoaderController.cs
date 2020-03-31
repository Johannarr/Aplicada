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
                case "GameLoader0":
                _sceneName="ExplorationLevel";
                break;

                case "GameLoader1":
                _sceneName="SampleScene";
                break;

                case "GameLoader2":
                _sceneName="Esencia";
                break;

                case "GameLoader3":
                _sceneName="Cannon";
                break;

                case "GameLoader4":
                _sceneName="FlappyBird";
                break;
                                
             }
            
        }

    SceneManager.LoadScene(_sceneName);
    }
    // Start is called before the first frame update
}
