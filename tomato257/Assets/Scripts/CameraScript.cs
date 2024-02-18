using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    private float xDiff=0.0f;
    private float zDiff=0.0f;
    private float yDiff=0.0f;

    void CameraTrack(){
        Vector3 playerPosition=player.transform.position;
        transform.position=new Vector3(playerPosition.x,playerPosition.y+yDiff,playerPosition.z+zDiff);
    }
    // Start is called before the first frame update
    void Start(){
        Vector3 playerPosition=player.transform.position;
        Vector3 cameraPosition=transform.position;
        xDiff=-playerPosition.x+cameraPosition.x;
        yDiff=-playerPosition.y+cameraPosition.y;
        zDiff=-playerPosition.z+cameraPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        CameraTrack();
    }
}