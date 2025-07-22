using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private Transform poolParent;

    private Queue<GameObject> _obstaclePool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(obstaclePrefab, poolParent);
            obj.SetActive(false);
            _obstaclePool.Enqueue(obj);
        }
    }

    public GameObject GetFromPool(Vector3 position)
    {
        GameObject obj = _obstaclePool.Count > 0 ? _obstaclePool.Dequeue() : Instantiate(obstaclePrefab, poolParent);
        obj.transform.position = position;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        _obstaclePool.Enqueue(obj);
    }
}