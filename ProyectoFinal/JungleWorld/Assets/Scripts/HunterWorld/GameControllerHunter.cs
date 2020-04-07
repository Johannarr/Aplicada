using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerHunter : MonoBehaviour
{
    
    public int CurrentScore;
    public int CurrentLives;
    public TextMesh ScoreText;
    public TextMesh LivesText;
    public GameObject WinText;
    public GameObject GameOverText;
    public GameObject GoBackText;
    public GameObject RetryText;
    public GameObject DuckPrefab;
    bool isGameOver;

    const float MINY = -4.2f, MAXY = 4.2f;
    // Start is called before the first frame update
    void Start()
    {
        
        CurrentScore = 0;
        CurrentLives = 3;
        GameOverText = GameObject.Find("GameOverText");
        WinText = GameObject.Find("WinText");
        RetryText = GameObject.Find("RetryText");
        GoBackText = GameObject.Find("GoBackText");

        InvokeRepeating("InstantiateDuck", 0, 0.5f);
        GameOverText.SetActive(false);
        WinText.SetActive(false);
        RetryText.SetActive(false);
        GoBackText.SetActive(false);

        HunterWorldAudioManager.Instance.PlaySoundEffect(HunterWorldAudioManager.SoundEffect.Start);
        
    }

    // Update is called once per frame
    void InstantiateDuck()
    {
        if (CurrentLives == 0)
        {
            return;
        }

        if (CurrentScore > 5)
        {
            return;
        }

        Instantiate(DuckPrefab, new Vector3 (10, Random.Range (3,4)),
        Quaternion.identity);

    }

    public int IncrementScore()
    {
           

       CurrentScore = CurrentScore + 1;
       ScoreText.text = CurrentScore.ToString();

        if (CurrentScore == 5 && isGameOver==false)
        {
            StartCoroutine("SendScore");
            WinText.SetActive(true);
            RetryText.SetActive(true);
            GoBackText.SetActive(true);
           
            
            HunterWorldAudioManager.Instance.PlaySoundEffect(HunterWorldAudioManager.SoundEffect.Win);
        }

        return CurrentScore;

    }

    public int DecrementLives()
    {
        CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
        LivesText.text = $"{CurrentLives}";

        if (CurrentLives == 0)
        {
            GameOver();
                    
        }

        return CurrentLives;
    }


    public void GameOver()
    {
        isGameOver = true;
        GameOverText.SetActive(true);
        StartCoroutine("SendScore");
        RetryText.SetActive(true);
        GoBackText.SetActive(true);
        HunterWorldAudioManager.Instance.PlaySoundEffect(HunterWorldAudioManager.SoundEffect.GameOver);
        return;

    }

    
   IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<HunterWorldWebServiceClient>().SendWebRequest(CurrentScore);
    }
}
