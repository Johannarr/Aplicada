using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameC : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("CrocodileWorld");
    }
}
