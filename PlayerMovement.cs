using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // For Flippin!
    private SpriteRenderer spriteRenderer;

    // For Jumpin!
    private bool jumping = false;
    private Rigidbody _rigidbody;
    public float jumpPower = 1.0f;

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

        Vector3 x = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // X Axis Movement

        Debug.Log(x);

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

        if (Input.GetKeyDown(KeyCode.Space)) // && !jumping) // If You Pressed Space and You aren't Already Jumping...
        {
            _rigidbody.AddForce(0,500,0,0);
            jumping = true;
        }

    }
}
