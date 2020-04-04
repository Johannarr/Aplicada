using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishType
    {
        Blue = 0,
        Green,
        Red,
        Orange,
        Frog,
    }
public class FishInstantiator : MonoBehaviour
{
    
    float _lastSpawnedTime, _spawnDeltaTime = 0.5f;
    float enemyProbability = 16.7f;
    Dictionary<FishType, GameObject> FishPrefabs;
    CrocoPlayerController _playerControllerCroco;
    public GameObject  BlueFishPrefab, 
                        GreenFishPrefab, 

                        RedFishPrefab,
                        OrangeFishPrefab, 
                        FrogPrefab,
                        EnemyPrefab;
    // Start is called before the first frame update
    
    private void Awake()
    {
        _playerControllerCroco = GameObject.FindGameObjectWithTag("Player").GetComponent<CrocoPlayerController>();
    }
    void Start()
    {
        _lastSpawnedTime = Time.time;
        FishPrefabs = new Dictionary<FishType, GameObject>{
            {FishType.Blue, BlueFishPrefab},
            {FishType.Green, GreenFishPrefab},
            {FishType.Red, RedFishPrefab},
            {FishType.Orange, OrangeFishPrefab},
            {FishType.Frog, FrogPrefab},
         };
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerControllerCroco.IsGameOver && Time.time - _lastSpawnedTime > _spawnDeltaTime)
        {
            _lastSpawnedTime = Time.time;
            InstantiateFish();
            InstantiateEnemy();
        }
        
    }

    void InstantiateFish()
    {
        Instantiate(FishPrefabs[(FishType)Random.Range(0,6)], new Vector3(12, Random.Range(-4,4)), Quaternion.identity);
    }

    void InstantiateEnemy()
    {
        if (Random.Range(0f, 100f)<=enemyProbability)
        {
            Instantiate(EnemyPrefab, new Vector3(12, Random.Range(-4,4)), Quaternion.identity);
        }
    }

}
