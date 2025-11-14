using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Smooth movement")]
    [SerializeField] private float smoothTime = 0.25f;

    private float targetPosX;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        // Initialize camera position target
        targetPosX = transform.position.x;
    }

    private void Update()
    {
        // Move smoothly toward target X position
        Vector3 targetPosition = new Vector3(targetPosX, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    // Call this from another script when entering a new room
    public void MoveToNewRoom(Transform newRoom)
    {
        if (newRoom == null)
        {
            Debug.LogWarning("CameraController: newRoom is null!");
            return;
        }

        targetPosX = newRoom.position.x;
        Debug.Log($"Camera moving to room: {newRoom.name} (target X = {targetPosX})");
    }
}

