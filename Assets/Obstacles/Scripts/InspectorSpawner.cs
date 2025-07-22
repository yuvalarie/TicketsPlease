using UnityEngine;
using UnityEngine.Serialization;

public class InspectorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject InspectorPrefab;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private ObstaclePool obstaclePool;
    private int _numberOfSpawns = 2;
    private float _interval = 30f;
    private float[] _optionalXPositions = { -3f, 3f };
    private float _YAxis = 0.47f;
    private float _time = 0f;

    void Update()
    {
        if (_time > _interval && _numberOfSpawns > 0)
        {
            SpawnInspector();
            _time = 0;
            _numberOfSpawns--;
        }
        _time += Time.deltaTime;
    }

    private void SpawnInspector()
    {
        GameObject inspector = Instantiate(InspectorPrefab, transform.position, Quaternion.identity);
        inspector.transform.position = new Vector3(_optionalXPositions[0], _YAxis, 0);
        SpawnerBehavior behavior = inspector.GetComponent<SpawnerBehavior>();
        behavior.Init(obstaclePrefab, obstaclePool, true);
        if (_optionalXPositions.Length > 1)
        { 
            _optionalXPositions = new float[] { _optionalXPositions[1] };
        }
    }
}
