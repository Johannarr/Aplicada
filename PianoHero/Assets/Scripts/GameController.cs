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
    public GameObject Coin2;
    public GameObject Coin3;

    public GameObject Heart3;

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
        Coin2 = GameObject.Find("Coin2");
        Coin3 = GameObject.Find("Coin3");

        Heart3 = GameObject.Find("Heart3");
        
        RetryText.SetActive(false);
        GameOverText.SetActive(false);
        WinText.SetActive(false);

        Coin.SetActive(false);
        Coin2.SetActive(false);
        Coin3.SetActive(false);

        Heart3.SetActive(true);

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
           Coin.SetActive(true);
       }
       else if (CurrentScore == 4)
       {
           Coin2.SetActive(true);
       }
        else if (CurrentScore == 5)
       {
            Coin3.SetActive(true);
            
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

            Heart3.SetActive(false);

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
