
using UnityEngine;
using UnityEngine.Serialization;

namespace ExtraHealth.Scripts
{
    public class ExtraLifeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _extraLifePrefab;
        [SerializeField] private float interval = 50f;
        private float[] _optionalXPositions = { -3f, 0, 3f };
        private float _time = 0f;
        private bool _hasSpawned = false;

        void Update()
        {
            if (_time > interval && !_hasSpawned)
            {
                SpawnExtraLife();
                _hasSpawned = true;
            }
            _time += Time.deltaTime;
        }

        private void SpawnExtraLife()
        {
            GameObject extraLife = Instantiate(_extraLifePrefab, transform.position, Quaternion.identity);
            int xPositionIndex = Random.Range(0, _optionalXPositions.Length);
            var yPos = transform.position.y;
            extraLife.transform.position = new Vector3(_optionalXPositions[xPositionIndex], yPos , 0);
        }
    }
}