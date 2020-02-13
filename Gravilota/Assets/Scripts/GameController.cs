using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public int CurrentScore;
    public int CurrentLives;
    public TextMesh ScoreText;
    public GameObject GameOverText;
    public TextMesh LivesText;
    public GameObject BallPrefab;
    const float MINX = -7.8f, MAXX = 7.8f;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScore = 0;
        CurrentLives = 3;
        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();
        GameOverText = GameObject.Find("GameOverText");
        
        InvokeRepeating("InstantiateBall", 0, 1.5f);
        GameOverText.SetActive(false);
        
    }

    // Update is called once per frame
    void InstantiateBall()
    {
       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
            return;
        }      
        Instantiate(BallPrefab, new Vector3 (Random.Range (MINX, MAXX),6,0), Quaternion.identity);

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
        LivesText.text = $"Vidas: {CurrentLives}"; 

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
/*
public int DecrementLives()
    {
       CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
        LivesText.text = $"Vidas: {CurrentLives}"; 

        return 0;
    }
*/