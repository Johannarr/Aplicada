using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerFlappy : MonoBehaviour
{
    
    public int CurrentScore;
    public TextMesh ScoreText;
    public GameObject GameOverText;
    public GameObject ObstPrefab;

    const float MINY = -4.2f, MAXY = 4.2f;
    // Start is called before the first frame update
    void Start()
    {
        
        CurrentScore = 0;
        GameOverText = GameObject.Find("GameOverText");
        
        InvokeRepeating("InstantiateObst", 0, 0.75f);
        GameOverText.SetActive(false);

        FlappyAudioManager.Instance.PlaySoundEffect(FlappyAudioManager.SoundEffect.Start);
        
    }

    // Update is called once per frame
    void InstantiateObst()
    {
       
        Instantiate(ObstPrefab, new Vector3 (10, Random.Range (-1,1)),
        Quaternion.identity);

    }

    public int IncrementScore()
    {
           

       CurrentScore = CurrentScore + 1;
       ScoreText.text = CurrentScore.ToString();
       return CurrentScore;
    }

    public void GameOver()
    {
        GameOverText.SetActive(true);
        StartCoroutine("SendScore");
        return;

    }

    
    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<FlappyWebServiceClient>().SendWebRequest(CurrentScore);
    }
}
