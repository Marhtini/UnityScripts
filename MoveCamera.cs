using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: When the Character dies, we want the character to drop off screen!

public class MoveCamera : MonoBehaviour {

    public GameObject player; // Reference to Player Object
    private Vector3 playerCameraOffset; // offset distance between player and cam

    // Start is called before the first frame update
    void Start()
    {
        playerCameraOffset = transform.position - player.transform.position;
    }

    // LateUpdate is called AFTER each Update()
    void LateUpdate()
    {
        transform.position = player.transform.position + playerCameraOffset;
    }
}
