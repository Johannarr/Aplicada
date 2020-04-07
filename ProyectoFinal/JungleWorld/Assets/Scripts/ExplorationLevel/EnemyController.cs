using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 0.00001f;

    GameControllerExplo gameController;
    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<GameControllerExplo>();
    }

    void Update()
    {
       if (gameObject.tag == ("EnemyBck1"))
        {
            pos1 = new Vector3(8.190001f, -0.73f, 0);
            pos2 = new Vector3(8.190001f, -6.21f, 0);

        }

        if (gameObject.tag == ("EnemyBck2"))
        {
            pos1 = new Vector3(20.46f, -9.06f, 0);
            pos2 = new Vector3(20.46f, -3.76f, 0);

        }

        if (gameObject.tag == ("EnemyBck3"))
        {
            pos1 = new Vector3(40.48f, -9.13f, 0);
            pos2 = new Vector3(40.48f, -0.69f, 0);

        }

        if (gameObject.tag == ("EnemyBck4"))
        {
            pos1 = new Vector3(74.1f, -8.5f, 0);
            pos2 = new Vector3(74.1f, -1.3f, 0);

        }

        if (gameObject.tag == ("EnemyBck5"))
        {
            pos1 = new Vector3(142.4f, -1.1f, 0);
            pos2 = new Vector3(142.2f, -8.2f, 0);

        }

        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time, 1.2f));
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.ToString().Contains("Player"))
        {

            gameController.DecrementLives();

            ExploAudioManager.Instance.PlaySoundEffect(ExploAudioManager.SoundEffect.CapturePowerUp);
        }
    }


}    


