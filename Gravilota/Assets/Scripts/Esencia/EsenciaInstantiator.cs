using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EssenceType
    {
        Blue = 0,
        Green,
        Red,
        Yellow,
        Pink,
        Purple
    }
public class EsenciaInstantiator : MonoBehaviour
{
    
    float _lastSpawnedTime, _spawnDeltaTime = 0.5f;
    float enemyProbability = 16.7f;
    Dictionary<EssenceType, GameObject> EssencePrefabs;
    ESPlayerController _playerControllerEssence;
    public GameObject  BlueEssencePrefab, 
                        YellowEssencePrefab, 
                        RedEssencePrefab, 
                        GreenEssencePrefab, 
                        PurpleEssencePrefab, 
                        PinkEssencePrefab,
                        EnemyPrefab;
    // Start is called before the first frame update
    
    private void Awake()
    {
        _playerControllerEssence = GameObject.FindGameObjectWithTag("Player").GetComponent<ESPlayerController>();
    }
    void Start()
    {
        _lastSpawnedTime = Time.time;
        EssencePrefabs = new Dictionary<EssenceType, GameObject>{
            {EssenceType.Blue, BlueEssencePrefab},
            {EssenceType.Green, GreenEssencePrefab},
            {EssenceType.Pink, PinkEssencePrefab},
            {EssenceType.Purple, PurpleEssencePrefab},
            {EssenceType.Red, RedEssencePrefab},
            {EssenceType.Yellow, YellowEssencePrefab},
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerControllerEssence.IsGameOver && Time.time - _lastSpawnedTime > _spawnDeltaTime)
        {
            _lastSpawnedTime = Time.time;
            InstantiateEssence();
            InstantiateEnemy();
        }
        
    }

    void InstantiateEssence()
    {
        Instantiate(EssencePrefabs[(EssenceType)Random.Range(0,6)], new Vector3(10, Random.Range(-4,5)), Quaternion.identity);
    }

    void InstantiateEnemy()
    {
        if (Random.Range(0f, 100f)<=enemyProbability)
        {
            Instantiate(EnemyPrefab, new Vector3(10, Random.Range(-4,5)), Quaternion.identity);
        }
    }

}
