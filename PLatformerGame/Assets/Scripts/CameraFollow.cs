using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        //store the player's position in a variable
        Vector3 playerPos = player.transform.position;

        //store the camera's (this) position in a variable
        Vector3 cameraPos = this.transform.position;

        //move the camera's x to the player's x on every frame
        cameraPos.x = playerPos.x;
        cameraPos.y = playerPos.y;

        //update both the camera and player position to the new position
        player.transform.position = playerPos;
        this.transform.position = cameraPos;
    }
}