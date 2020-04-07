using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameE : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("ExplorationLevel");
    }
}
