using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    const float MINX = -2.37f, MAXX = 2.37f;
    
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

        CurrentScore = 0;
        CurrentLives = 4;

        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();
        GameOverText = GameObject.Find("GameOverText");
        WinText = GameObject.Find("WinText");
        RetryText = GameObject.Find("RetryText");

        Coin = GameObject.Find("Coin");
        Crown = GameObject.Find("Crown");
        Crown2 = GameObject.Find("Crown2");
        Crown3 = GameObject.Find("Crown3");

        Heart = GameObject.Find("Heart3");
        
        RetryText.SetActive(false);
        GameOverText.SetActive(false);
        WinText.SetActive(false);

        Coin.SetActive(true);

        Crown.SetActive(false);
        Crown2.SetActive(false);
        Crown3.SetActive(false);

        

        Heart.SetActive(true);

        InvokeRepeating("InstantiateKey", 0, 1.5f);
       
        
    }

    void InstantiateKey()
    {
       if (CurrentLives <= 0)
        {

            return;
        } 

        else if (CurrentScore == 5)  
        {
            return;
        }

        Instantiate(KeyPrefab, new Vector3 (Random.Range (MINX, MAXX),6,0), Quaternion.identity);
    }

    public int IncrementScore()
    {

       CurrentScore = CurrentScore + 1;
       ScoreText.text = CurrentScore.ToString();

       if (CurrentScore == 2)
       {
           Crown.SetActive(true);
       }
       else if (CurrentScore == 4)
       {
           Crown2.SetActive(true);
       }
        else if (CurrentScore == 5)
       {
            Crown3.SetActive(true);
            
            StartCoroutine("SendScore");

            WinText.SetActive(true);

            RetryText.SetActive(true);

            AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Win);
       }
    
       return CurrentScore;
    }

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

    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }
}
