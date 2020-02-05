using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("").GetComponent<GameController>();
    }

    // Update is called once per frame
    void OnTrigggerEnter(Collider other)
    {
        Destroy (other.gameObject);
    }
}
