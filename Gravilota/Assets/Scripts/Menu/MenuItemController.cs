using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using 

public class MenuItemController: MonoBehaviour
{


    const float _HOVERSCALEFACTOR = 1.4f;
    MenuController _menuController;

    private void Awake()
    {
        _menuController = GameObject.Find("Global")
    }
    public void OnMouseEnter()
    {
        transform.localScale *= _HOVERSCALEFACTOR;
    }

    public void OnMouseExit()
    {
        transform.localScale /=_HOVERSCALEFACTOR;
    }

    public void OnMouseUp()
    {
        if (_menuController.IsCanvasActive())
        return;
        switch (gameObject.name)
        {
            case "Jugar"
            SceneManager.LoadScene("FlappyBird");
            break;

            case "Opciones"
            _menuController.ShowGameOptions();
            break;

            case "Salir"
            Application.Quit();
            break;
        }


    }


public void OkDialog()
{
    _menuController.HideGameOptions();
}

public void CancelDialog()
{
    _menuController.HideGameOptions();
}

public void OnPlayerNameChanged(InputField input)
{
    
}

    // Start is called before the first frame update
}