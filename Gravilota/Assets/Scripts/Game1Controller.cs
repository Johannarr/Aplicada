using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Controller : MonoBehaviour
{
    private bool isCollidedWithObj1 = false;
    private bool isCollidedWithObj2 = false;
    public int CurrentScore;
    public int CurrentLives;
    public TextMesh BestText;
     public TextMesh ScoreText;
    public GameObject GameOverText;
    public TextMesh VidasText;
    public GameObject RedCubePrefab;
    public GameObject YellowCubePrefab;
    const float MINX = -7.8f, MAXX = 7.8f;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScore = 0;
        CurrentLives = 3;
        VidasText = GameObject.Find("VidasText").GetComponent<TextMesh>();
        //GameOverText = GameObject.Find("GameOverText");
        
        InvokeRepeating("InstantiateCube", 0, 1.5f);
        //GameOverText.SetActive(false);
        
    }

    // Update is called once per frame
    void InstantiateCube()
    {
       if (CurrentLives <= 0)
        {
            GameOverText.SetActive(true);
            return;
        }      
        Instantiate(RedCubePrefab, new Vector3 (Random.Range (MINX, MAXX),6,0), Quaternion.identity);
        Instantiate(YellowCubePrefab, new Vector3 (Random.Range (MINX, MAXX),6,0), Quaternion.identity);

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
        VidasText.text = $"Vidas: {CurrentLives}"; 

        if (CurrentLives == 0)
        {
            StartCoroutine("SendScore");
            //GameOverText.SetActive(true);
        }

        return CurrentLives;
    }

    IEnumerator SendScore()
    {
        yield return gameObject.GetComponent<WebServiceClient>().SendWebRequest(CurrentScore);
    }


     public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RedCubePrefab")
            isCollidedWithObj1 = true;
        else if (collision.gameObject.tag == "RedCubePrefab")
            isCollidedWithObj2 = true;

        if (isCollidedWithObj1 && isCollidedWithObj2)
         Destroy(gameObject);

    }
}
