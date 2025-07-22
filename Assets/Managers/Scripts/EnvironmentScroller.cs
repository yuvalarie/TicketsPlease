using UnityEngine;

public class EnvironmentScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private float resetYPosition = 20f; // Set this based on your layout
    [SerializeField] private float bottomYPosition = -20f; // When to reset

    private void Update()
    {
        transform.position += Vector3.down * (scrollSpeed * Time.deltaTime);

        if (transform.position.y < bottomYPosition)
        {
            Vector3 newPos = transform.position;
            newPos.y += resetYPosition;
            transform.position = newPos;
        }
    }
}