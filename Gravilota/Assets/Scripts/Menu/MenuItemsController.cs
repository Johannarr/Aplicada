using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Menu.Entities;

public class MenuItemsController : MonoBehaviour
{
    const float _HOVERSCALEFACTOR = 1.4f;

    GameMenuController _menuController;

    private void Awake()
    {
        _menuController = GameObject.Find("GlobalScriptsText").GetComponent<GameMenuController>();
    }

    public void OnMouseEnter()
    {
       
        transform.localScale *= _HOVERSCALEFACTOR;
    }

    public void OnMouseExit()
    {
        transform.localScale /= _HOVERSCALEFACTOR;
    }

    //funciona parecido a onmousedown
    public void OnMouseUp()
    {
        MenuAudioManager.Instance.PlaySoundEffect(MenuAudioManager.SoundEffect.Click);

        if (_menuController.isCanvasActive())
            return;
            
        

        switch (gameObject.name)
        {
            case "Play":
            SceneManager.LoadScene("Taberna");
            break;

            case "Options":
            _menuController.ShowGameOptions();
            break;

            case "Exit":
            //quita la scena
            Application.Quit();
            break;

        }

    }


    public void AcceptDialog()
    {
        _menuController.HideGameOptions();
    }


    public void CancelDialog()
    {

        Game.CurrentGame.LoadCurrentState();
        _menuController.HideGameOptions();
    }


    public void OnPlayerNameChanged(InputField input)
    {
        Game.CurrentGame.PlayerName = input.text;
    }


    public void OnMusicVolumeChanged(Slider slider)
    {
        Game.CurrentGame.MusicVolume = slider.value;
    }


    public void OnFXMusicChanged(Slider slider) 
    {
        Game.CurrentGame.EffectsVolume = slider.value;
    }


    public void OnDifficultyChanged(Dropdown drop)
    {
        Game.CurrentGame.Difficulty = (Game.eDifficulty)drop.value;
    }
}
