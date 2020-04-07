using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameH : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("HunterWorld");
    }
}
