using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public int CurrentScore;
    public int CurrentLives;
    public TextMesh ScoreText;
    public TextMesh LivesText;
    public GameObject BallPrefab;
     public GameObject GameOverText;
    const float MINX = -7.8f, MAXX = 7.8f;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScore = 0;
        CurrentLives = 3;
        ScoreText = GetComponent<TextMesh>();
        LivesText = GameObject.Find("Lifes").GetComponent<TextMesh>();
        GameOverText = GameObject.Find("GameOverText");

        InvokeRepeating("IntantiateBall", 0, 1.5f);
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
       CurrentScore++;
       ScoreText.text = CurrentScore.ToString(); 
        return CurrentScore;
    }

    public int DecrementLives()
    {
       CurrentLives = CurrentLives > 0 ? CurrentLives - 1 : 0;
        LivesText.text = $"Vidas: {CurrentLives}"; 

        return 0;
    }
}
