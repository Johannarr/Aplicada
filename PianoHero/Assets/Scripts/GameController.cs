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
    public TextMesh LivesText;
    public GameObject KeyPrefab;
    
    void Start()
    {
        CurrentScore = 0;
        CurrentLives = 3;

        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();
        GameOverText = GameObject.Find("GameOverText");
        
        GameOverText.SetActive(false);

        InvokeRepeating("InstantiateKey", 0, 1.5f);
       
        
    }

    void InstantiateKey()
    {
       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
            return;
        }   

        Instantiate(KeyPrefab, new Vector3 (Random.Range (MINX, MAXX),6,0), Quaternion.identity);
    }

    public int IncrementScore()
    {

       CurrentScore = CurrentScore + 1;
       ScoreText.text = CurrentScore.ToString();
       return CurrentScore;
    }

    public int DecrementLives()
    {
       CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
        LivesText.text = $"Lives: {CurrentLives}"; 

        if (CurrentLives == 0)
        {
            StartCoroutine("SendScore");
            GameOverText.SetActive(true);
        }

        return CurrentLives;
    }

    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }
}
