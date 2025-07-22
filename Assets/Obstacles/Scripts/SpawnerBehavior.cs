using System;
using Obstacles.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class SpawnerBehavior: MonoBehaviour
{
    [Header("Obstacle Prefab")] 
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private ObstaclePool obstaclePool;
    
    private float[] _optionalXPositions = { -3f, 0, 3f };
    float YIndex;
    
    [Header("Time between spawns")]
    [SerializeField] private float interval = 5f;
    
    private float _time = 0f;
    public bool isInspector;

    private Random _rnd = new Random();
    public void Init(GameObject prefab, ObstaclePool pool, bool isInspectorFlag)
    {
        obstaclePrefab = prefab;
        obstaclePool = pool;
        isInspector = isInspectorFlag;

        _rnd = new System.Random(); // Make sure this is initialized
        YIndex = isInspector ? _rnd.Next(35, 75) / 10f : transform.position.y;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        /**_rnd = new Random();
        if (isInspector)
        {
            YIndex = _rnd.Next(35, 75) / 10f;
        }
        else
        {
            YIndex = transform.position.y;
        }**/
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > interval)
        {
            float currentY = transform.position.y;
            if (currentY > -1f)
            {
                GameObject obstacle = obstaclePool.GetFromPool(transform.position);

                int XIndex = _rnd.Next(3);
                YIndex = isInspector ? _rnd.Next(45, 75) / 10f : transform.position.y;
                var startMovement = new Vector3(_optionalXPositions[XIndex], YIndex, 0);
                obstacle.GetComponent<ObstacleBehavior>().Init(startMovement, obstaclePool);
            }
            _time = 0;
        }
        _time += Time.deltaTime;
    }
}
