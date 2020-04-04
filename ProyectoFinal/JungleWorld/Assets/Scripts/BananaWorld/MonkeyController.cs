using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour
{
    const float _MINX = -9.0f;
    const float _MAXX = 9.0f;
    float _speeddX = 15f;
    Vector3 deltaPos;
    BananaWorldGameController gameController;
    // Start is called before the first frame update

    void Start()
    {
        gameController = GameObject.Find("GlobalScriptsText").GetComponent<BananaWorldGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaPos = new Vector3(Input.GetAxis("Horizontal"),0) * _speeddX * Time.deltaTime;
        gameObject.transform.Translate(deltaPos);

        gameObject.transform.position = new Vector3(
            Mathf.Clamp(gameObject.transform.position.x, _MINX, _MAXX),
            gameObject.transform.position.y,
            gameObject.transform.position.z);
  
    }

    private void OnTriggerEnter (Collider other)
    {
        gameController.IncrementScore();
        Destroy (other.gameObject);
        BananaWorldAudioManager.Instance.PlaySoundEffect(BananaWorldAudioManager.SoundEffect.Capture);

    }
}
