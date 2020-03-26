using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject _player;
    Vector3 _newPosition;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

    }
    void Start()
    {
        _newPosition = gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        _newPosition.y=Mathf.Clamp(_player.transform.position.y, -2.25f, 2.25f);
        transform.position=_newPosition;
    }
}
