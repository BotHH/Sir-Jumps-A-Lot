using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour
{
    public float movementSpeed = 10000.0f;
    private bool isGrounded = true;


    void Update() {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0); //Set X and Z velocity to 0
 
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);
		

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump(); //Manual jumping
        }
		isGrounded = Physics.Raycast(transform.position, -Vector3.up, 1.0f);
	}

    void Jump()
    {
        if (!isGrounded) { return; }
        isGrounded = false;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.AddForce(new Vector3(0, 600, 0), ForceMode.Force);
		if(isGrounded == false)
		{
			isGrounded = Physics.Raycast(transform.position, -Vector3.up, 1.0f);
		}
    }
}

