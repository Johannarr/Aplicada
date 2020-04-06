using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Menu.Entities;

public class GameMenuController : MonoBehaviour
{

    GameObject _canvas;
    public InputField PlayerNameInputField;
    public Slider MusicVolumeSlider;
    public Slider EffectsVolumeSlider;
    public Dropdown DifficultyDropdown;

    bool _isActive;


    private void Awake()
    {
        _canvas = GameObject.Find("GameOptionsDialog");

        _canvas.SetActive(false);
    }


    private void Start()
    {
        MenuAudioManager.Instance.PlaySoundEffect(MenuAudioManager.SoundEffect.Song);
        Game.CurrentGame.LoadCurrentState();
    }


    public void ShowGameOptions()
    {
        _canvas.SetActive(true);
    }


    public void HideGameOptions()
    {
        _canvas.SetActive(false);

        Game.CurrentGame.SaveCurrentState();
    }


   public bool isCanvasActive()
    {
        return _canvas.activeSelf;
    }

    public void UpdateOptionsGUI()
    {
        PlayerNameInputField.text = Game.CurrentGame.PlayerName;

        MusicVolumeSlider.value = Game.CurrentGame.MusicVolume;

        EffectsVolumeSlider.value = Game.CurrentGame.EffectsVolume;
        
        DifficultyDropdown.value = (int)Game.CurrentGame.Difficulty;
    }
}
