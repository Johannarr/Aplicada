﻿using System.Collections;
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
                switch (gameObject.name)
                {
                    case "Door":
                    _sceneName = "MapLevels";
                    break;

                }
        }

     SceneManager.LoadScene(_sceneName);
    }
}
