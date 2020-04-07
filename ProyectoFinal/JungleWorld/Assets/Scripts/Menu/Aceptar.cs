using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aceptar : MonoBehaviour
{
    
	private void Start()
    {
        OnMouseUp();
    }
	
	
	public void OnMouseUp()
    {
        //MenuAudioManager.Instance.PlaySoundEffect(MenuAudioManager.SoundEffect.Click);

		SceneManager.LoadScene("Menu");

	}
    
}
