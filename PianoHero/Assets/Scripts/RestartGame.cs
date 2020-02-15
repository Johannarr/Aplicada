using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    
    // Esta funcion se encarga de si el boton retry es presionado por el mouse o por el touch 
    // se cargara de nuevo la escena del juego que tenemos
    void OnMouseDown()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
