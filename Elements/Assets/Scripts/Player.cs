using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	private Rigidbody2D myRigidbody;

	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;

	private bool facingRight;

	[SerializeField]
	private bool isGrounded;

	[SerializeField]
	private float initialJumpPower = 400f;

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

	private void OnTriggerEnter2D(Collider2D other)
	{
		isGrounded = true;
				if (other.gameObject.CompareTag("enemy"))
		{
			//Destroy (other.gameObject);
			// Yield return new WaitForSeconds(3);
			SceneManager.LoadScene(7);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		isGrounded = false;
	}

	private void Jump()
	{
		if(isGrounded == true)
		{
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
            myRigidbody.AddForce(Vector2.up * initialJumpPower);
		}
		
	}



}