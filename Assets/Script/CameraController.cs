using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f,-1f,-10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    
    // [SerializeField] private Transform player;
    [SerializeField] private GameObject player;
    private PlayerController playerControl;

    void Awake(){
        playerControl = player.GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        if(player != null && !playerControl.isGrounded()){
            Vector3 playerPosition = player.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity,smoothTime);
        }
        else if(player != null && playerControl.isGrounded()){
            Vector3 playerPosition = new Vector3(player.transform.position.x+offset.x,0f,player.transform.position.z+offset.z);
            transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity,smoothTime);
        }
    }
}
