using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player entered door");
        
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x){
                cam.MoveToNewRoom(nextRoom);
                Debug.Log("Moved to next room");
            }
            else{
                cam.MoveToNewRoom(previousRoom);
                Debug.Log("Moved to previous room");    
            }
                
        }
    }
}
