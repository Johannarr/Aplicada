using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerExploLevel : MonoBehaviour
{
    Vector3 _movementSpeed = new Vector3(5, 5),
    _runningSpeed= new Vector3(15, 15);
    Rigidbody _rigidbody;
    Animator _animator;
    SpriteRenderer _renderer;
    Vector3 _newPosition= new Vector3();
    bool _isEnemy;

    const float ENEMYMOVEDISTANCE = 5f, ENEMYATTACKDISTANCE=2f, ENEMYRUNNINGSPEED=10f;
    GameObject _player;
    // Start is called before the first frame update
   
    private void Awake()
    {
    
        _animator =GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        Physics.IgnoreLayerCollision(8, 10);
        _player=GameObject.FindGameObjectWithTag("Player");

    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isEnemy = gameObject.tag == "Enemy";
       
    }

    // Update is called once per frame
    void Update()
    {
       if (!_isEnemy)
       {
        _newPosition.x = Input.GetAxis("Horizontal")* (Input.GetButton("Fire3")
        ? _runningSpeed.x : _movementSpeed.x);
        _newPosition.y = Input.GetAxis("Vertical")* (Input.GetButton("Fire3")
        ? _runningSpeed.y : _movementSpeed.y);

        _animator.SetFloat("Speed",_newPosition.magnitude);
       
         _rigidbody.MovePosition(transform.position + _newPosition* Time.deltaTime);

         _animator.SetBool("Attack", Input.GetButton("Fire1"));
        _renderer.flipX=_newPosition.x < 0;
       }

       else
       {
          
           if (Vector3.Distance(gameObject.transform.position,
           
           _player.transform.position)<ENEMYATTACKDISTANCE)
           {
               _animator.SetBool("Attack", true);

           }
           else
           {
               _animator.SetBool("Attack", false);
           }

           if (Vector3.Distance(gameObject.transform.position,
           
           _player.transform.position)<ENEMYMOVEDISTANCE)
           {
              _newPosition=Vector3.MoveTowards(gameObject.transform.position,
               _player.transform.position, ENEMYRUNNINGSPEED*Time.deltaTime);
               _rigidbody.MovePosition(_newPosition);

            _animator.SetFloat("Speed", ENEMYRUNNINGSPEED);
           } 
       
            else
            {
                _animator.SetFloat("Speed", 0);
            }       
        }
    }
}
