using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraController : MonoBehaviour
{
    private Transform player;
    public  float yOffset=1.23f;
    public float zOffset=-6.64f;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position= new Vector3(player.position.x, player.position.y+yOffset,player.position.z+zOffset);

        
    }
}
