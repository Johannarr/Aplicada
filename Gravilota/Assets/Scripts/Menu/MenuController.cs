using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    GameObject _canvas;

    private void Awake()
    {
        _canvas= GameObject.Find("GameOptionsDialog");
        _canvas.SetActive(false);
    }

    public void ShowGameOptions()
    {
        _canvas.SetActive(true);
    }

    public void HidenGameOptions()
    {
        _canvas.SetActive(false);
    }

    public bool IsCanvasActive()
    {
        return _canvas.activeSeft;
    }
    
}
