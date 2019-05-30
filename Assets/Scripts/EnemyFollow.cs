using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;

    private Transform _target;

	private Rigidbody2D _rigidbody;

	private Animator _animator;

	private bool _facingRight;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();

        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	private void Flip(float horizontal)
	{
		if (horizontal > 0 && _facingRight || horizontal < 0 && !_facingRight)
		{
			_facingRight = !_facingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;					
		}

		_animator.SetFloat("speed", Mathf.Abs(horizontal));
	}

    void Update(){

		if (Vector3.Distance(_target.position, transform.position) <= 4.0f){ 
			if()
			transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
		}
    }
}
