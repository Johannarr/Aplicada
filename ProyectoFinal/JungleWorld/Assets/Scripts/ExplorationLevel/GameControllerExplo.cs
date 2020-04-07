using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerExplo : MonoBehaviour
{
    
    public int CurrentScore;
    public int CurrentLives;
    public TextMesh ScoreText;
    public TextMesh LivesText;
    public GameObject WinText;
    public GameObject RetryText;
    public GameObject GoBackText; 
    public GameObject GameOverText;

    
   
    // Start is called before the first frame update
    void Start()
    {
        
        CurrentScore = 0;
        CurrentLives = 5;
        GameOverText = GameObject.Find("GameOverText");
        WinText = GameObject.Find("WinText");
        RetryText =GameObject.Find("RetryText");
        GoBackText = GameObject.Find("GoBackText");
        

        GameOverText.SetActive(false);
        WinText.SetActive(false);
        RetryText.SetActive(false);
        GoBackText.SetActive(false);

        ExploAudioManager.Instance.PlaySoundEffect(ExploAudioManager.SoundEffect.Start);
        
    }

    // Update is called once per frame
    public int IncrementScore()
    { 

       CurrentScore = CurrentScore + 100;
       ScoreText.text = CurrentScore.ToString();

      /*  if (CurrentScore == 2)
        {
            StartCoroutine("SendScore");
            WinText.SetActive(true);
           
            
            ExploAudioManager.Instance.PlaySoundEffect(ExploAudioManager.SoundEffect.Win);
        }*/

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
        GameOverText.SetActive(true);
        RetryText.SetActive(true);
        GoBackText.SetActive(true);
        StartCoroutine("SendScore");
        ExploAudioManager.Instance.PlaySoundEffect(ExploAudioManager.SoundEffect.GameOver);
        
        

    }

    public void Win()
    {
        WinText.SetActive(true);
        RetryText.SetActive(true);
        GoBackText.SetActive(true);
        StartCoroutine("SendScore");
        ExploAudioManager.Instance.PlaySoundEffect(ExploAudioManager.SoundEffect.Win);
        

    }


    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<ExploWebServiceClient>().SendWebRequest(CurrentScore);
        
    }
}
