using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D myRigidbody;

	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed = 5f;

	private bool facingRight;

	[SerializeField]
	private bool isGrounded = true;

	[SerializeField]
	private float initialJumpPower = 500f;

	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		HandleMovement(horizontal);

		Flip(horizontal);

		if(Input.GetButtonDown("Jump"))
		{
			Jump();
		}
	}

	private void HandleMovement(float horizontal)
	{
		myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y); //x-1, y = 0;

		myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
	}

	private void Flip(float horizontal)
	{
		if (horizontal > 0 & facingRight || horizontal < 0 && !facingRight)
		{
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;					
		}
	}

	private void Jump()
	{
		if(isGrounded == true)
		{
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
            myRigidbody.AddForce(Vector2.up * initialJumpPower);
		}
		
	}

	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "ground")
		{
		isGrounded = true;
		}

	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "ground")
		{
		isGrounded = false;
		}
	}



}