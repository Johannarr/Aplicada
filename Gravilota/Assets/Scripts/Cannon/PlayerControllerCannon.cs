using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCannon : MonoBehaviour
{
    const float MINX = -8f, MAXX = 8f;
    Vector3 _deltaPos, _mousePosition;

    float _speedX = 20f;
    float _triggerSpeed = 10f, _triggerAngle;
    public GameObject CannonBallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _deltaPos = new Vector3();

    }

    // Update is called once per frame
    void Update()
    {
        //Position changing
        _deltaPos.y = 0;
        _deltaPos.z= 0;
        _deltaPos.x = Input.GetAxis("Horizontal") *_speedX * Time.deltaTime;
        gameObject.transform.Translate(_deltaPos);
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, MINX, MAXX),
        gameObject.transform.position.y,
        gameObject.transform.position.z);


        //Calculating angle:
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _deltaPos.y = _mousePosition.y - gameObject.transform.position.y;
        _deltaPos.x = _mousePosition.x - gameObject.transform.position.x;
        


        if (_deltaPos.x < 0)
            _triggerAngle = Mathf.PI / 2;
    

        else if (_deltaPos.y < 0)
            _triggerAngle=0;
        
        else 
            _triggerAngle= Mathf.Atan(_deltaPos.y / _deltaPos.x);// * Mathf.Rad2Deg;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(CannonBallPrefab, gameObject.transform.position, 
            Quaternion.identity).GetComponent<CannonBallBehaviour>().Shoot(_triggerSpeed, _triggerAngle);

        }

        
        Debug.Log((_triggerAngle)* Mathf.Rad2Deg);
        
    }
}
