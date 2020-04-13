using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Velocity on Y Axis Does Not Stay at 0.0f When Moving on X Axis?
// TODO: Rotation on X and Z Axis Causes the Character to Fall Off Of the Map

public class PlayerMovement : MonoBehaviour
{

    // For Flippin!
    private SpriteRenderer spriteRenderer;

    // For Jumpin!
    private bool jumping = false;
    private Rigidbody _rigidbody;
    // public float jumpPower = 100.0f; // UNUSED RIGHT NOW

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        Vector3 x = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // X Axis Movement
        float speed = transform.InverseTransformDirection(_rigidbody.velocity).y;

        // Freeze Positions to prevent FLAPPIN'  
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

        // Freeze Rotations to prevent FLAPPIN'
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        CheckSpeed(speed);
 
        // DEBUG
        // Debug.Log(speed);
        Debug.Log(_rigidbody.velocity[1]);
        Debug.Log(jumping);

        if (x[0] < 0.0)
        {
            spriteRenderer.flipX = true;
        }
        else if (x[0] > 0.0)
        {
            spriteRenderer.flipX = false;
        }
        else { } // do nothing

        transform.position = transform.position + x * Time.deltaTime * 10; // 10 Adds Speed GOTTA GO FAST

        if (Input.GetKeyDown(KeyCode.Space) && !jumping) // If You Pressed Space and You aren't Already Jumping...
        {
            _rigidbody.AddForce(0, 400, 0, 0);
            jumping = true;
        }

    }

    void CheckSpeed(float pSpeed) // I actually think we need the magnitude (Speed) here...
    {
        if (pSpeed > 0.1f || pSpeed < -0.1f)
        {
            jumping = true;
        }
        else
        {
            jumping = false;
        }
    }
}
