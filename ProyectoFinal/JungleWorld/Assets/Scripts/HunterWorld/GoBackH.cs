using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackH : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("MapLevels");
    }
}
