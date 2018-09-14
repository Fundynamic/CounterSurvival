using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    private float currentSpeed;

    public float offset = 0.0f;

    public GameObject light;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        currentSpeed = 0.0f;
        if (Input.GetButton("Horizontal") ||
            Input.GetButton("Vertical"))
        {
            currentSpeed = moveSpeed;
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        // Rotate player sprite
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        //rb2d.AddForce(movement * speed);
        var rb2DPosition = rb2d.position;
        var newPosition = rb2DPosition + ((movement * currentSpeed) * Time.fixedDeltaTime);

//        Debug.Log("Hor: " + moveHorizontal + " vert: " + moveVertical + " Speed: " + currentSpeed + " - current pos " + rb2DPosition + " - newPosition " + newPosition);

        rb2d.MovePosition(newPosition);
    }

    private void OnGUI()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
//        GUI.enabled = true;
//        GUI.color = Color.green;
//        GUI.backgroundColor = Color.green;
//        GUI.Box(new Rect(pos.x - 32, pos.y - 48, 64, 16), GUIContent.none);
//        GUI.color = Color.green;
//        GUI.Box(new Rect(pos.x - 32, pos.y - 48, 32, 16), GUIContent.none);
        
    }
}
