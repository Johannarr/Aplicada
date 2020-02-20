using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int CurrentScore;
    public int CurrentLives;
    public TextMesh ScoreText;
    public GameObject GameOverText;
    public TextMesh LivesText;
    public GameObject CubePrefab;
    //public GameObject MenosPrefab;
    const float MINX = -7.8f, MAXX = 7.8f;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.Start);
        CurrentScore = 0;
        CurrentLives = 5;
        LivesText = GameObject.Find("LivesText").GetComponent<TextMesh>();
        GameOverText = GameObject.Find("GameOverText");
        
        InvokeRepeating("InstantiateCube", 0, 1.5f);
       // InvokeRepeating("InstantiateMenos", 0, 1.5f);
        GameOverText.SetActive(false);
        
    }

    // Update is called once per frame
    void InstantiateCube()
    {
       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
            return;
        }      
        Instantiate(CubePrefab, new Vector3 (Random.Range (MINX, MAXX),6,0), Quaternion.identity);

    }



    public int IncrementScore()
    {
      // CurrentScore++;
      // ScoreText.text = CurrentScore.ToString(); 
       

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

        //AudioManager.Instance.PlaySoundEffect(AudioManager.SoundEffect.GameOver);

        return CurrentLives;
    }

    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }
}
