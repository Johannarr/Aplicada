using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoScrollController : MonoBehaviour
{
    Vector3 _scrollingSpeed =  new Vector3(0.3f,0);
    Vector3 _currentPosition = new Vector3();
    MeshRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer =  GetComponent<MeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
      _currentPosition += _scrollingSpeed * Time.deltaTime;
      _renderer.material.mainTextureOffset = _currentPosition;
    }
}
