using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterWorldDeadZoneController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameControllerHunter gameController;
    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameControllerHunter>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Destroy (other.gameObject);
        gameController.DecrementLives();
        
    }
}


   