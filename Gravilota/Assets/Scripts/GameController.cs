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
    const float MINX = -7.8f, MAXX = 7.8f;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScore = 0;
        CurrentLives = 3;
        InvokeRepeating("InstantiateBall", 0, 1.5f);
        
    }

    // Update is called once per frame
    void InstantiateBall()
    {
        if (CurrentLives <= 0){
            return
        }
        Instantiate(BallPrefab, new Vector3 (Random.Range (MINX, MAXX),6,0), Quaternion.identity);

    }

    public int IncrementScore()
    {
       CurrentScore++;
       ScoreText.text = CurrentScore.ToString(); 
        return CurrentScore;
    }

    public int DincrementLives()
    {
       CurrentLives--;
       LivesText.text = $"Vidas : {CurrentLives}"; 
        return CurrentLives;
    }
}
