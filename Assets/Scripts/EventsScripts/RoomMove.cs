using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 newMinPosition;
    public Vector2 newMaxPosition;
    public Vector3 playerChange;
    private CameraMovement cam;

    void Start()
    {
            cam = Camera.main.GetComponent<CameraMovement>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition = newMinPosition;
            cam.maxPosition = newMaxPosition;
            other.transform.position += playerChange;
        }
    }
}
