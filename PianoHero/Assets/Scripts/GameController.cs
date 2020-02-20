using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    // estas constantes indican el minimo y maximo en x que se pueden mover o salir las teclas
    const float MINX = -2.37f, MAXX = 2.37f;
    
    //aqui defino las distinitas variables y objetos que utilizare en el juego
    public int CurrentScore;
    public int CurrentLives;
    public TextMesh ScoreText;
    public GameObject GameOverText;
    public GameObject WinText;

    public GameObject Coin;
    public GameObject Crown;
    public GameObject Crown2;
    public GameObject Crown3;

    public GameObject Heart;

    public GameObject RetryText;
    public TextMesh LivesText;
    public GameObject KeyPrefab;
    
    
    void Start()
    {

        // Inicio la cancion de fondo
        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Start);

        //definiendo los valores iniciales del score y de las vidas
        CurrentScore = 0;
        CurrentLives = 4;


        // Buscando los distintos objetos por su nombre para poder utilizarlos ene sta clase
        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();
        GameOverText = GameObject.Find("GameOverText");
        WinText = GameObject.Find("WinText");
        RetryText = GameObject.Find("RetryText");

        Coin = GameObject.Find("Coin");
        Crown = GameObject.Find("Crown");
        Crown2 = GameObject.Find("Crown2");
        Crown3 = GameObject.Find("Crown3");

        Heart = GameObject.Find("Heart3");


        // aqui indico cuales objetos deseo que se muestren cuando el juego inicia y cuales otros no
        RetryText.SetActive(false);
        GameOverText.SetActive(false);
        WinText.SetActive(false);

        Coin.SetActive(true);

        Crown.SetActive(false);
        Crown2.SetActive(false);
        Crown3.SetActive(false);

        Heart.SetActive(true);


        // Hago que la funcion InstatiateKey se repita cada 1.5 segundos y que espere 0 segundos para iniciar
        InvokeRepeating("InstantiateKey", 0, 1.5f);
            
    }


    //Funcion encargada de instanciar los prefabs de tecla, estas se detienen cuando las vidas sean 0 o menor
    // o el Score sea igual a 100
    void InstantiateKey()
    {
       if (CurrentLives <= 0)
        {

            return;
        } 

        else if (CurrentScore == 230)  
        {
             StartCoroutine("SendScore");
            return;
        }

        Instantiate(KeyPrefab, new Vector3 (Random.Range (MINX, MAXX),6,0), Quaternion.identity);
    }


    //Esta funcion se encarga de aumentar el puntaje en el juego de 10 en 10, no toma parametros y retorna un entero
    //que es el puntaje actual, ademas de que cuando el score llegaa a 100 se gana automaticamente y al mismo tiempo
    // se crea un hilo para que se mande el score tan pronto se acabe el juego y por ultimo toca un sonido de win   
    public int IncrementScore()
    {

       CurrentScore = CurrentScore + 10;
       ScoreText.text = CurrentScore.ToString();

       if (CurrentScore == 50)
       {
           Crown.SetActive(true);
       }
       else if (CurrentScore == 130)
       {
           Crown2.SetActive(true);
       }
        else if (CurrentScore == 230)
       {
            Crown3.SetActive(true);
            

            WinText.SetActive(true);

            RetryText.SetActive(true);

            AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Win);
       }
    
       return CurrentScore;
    }
    

    //Esta funcion se encarga de disminuir las vidas en el juego de 1 en 1, no toma parametros y retorna un entero
    //que es la vida actual, ademas de que cuando las vidas llegan a 0 se pierde automaticamente y al mismo tiempo
    // crea un hilo para que se mande el score tan pronto se acabe el juego y por ultimo toca un sonido de game over
    public int DecrementLives()
    {
        CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
       
        LivesText.text = $"Lives: {CurrentLives}"; 


        if (CurrentLives == 0)
        {

            Heart.SetActive(false);

            StartCoroutine("SendScore");

            GameOverText.SetActive(true);

            RetryText.SetActive(true);

            AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.GameOver);
        }

        return CurrentLives;
    }

    // funcion encargada de mandar el score a webservice client, no toma parametros esta funcion
    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }
}
