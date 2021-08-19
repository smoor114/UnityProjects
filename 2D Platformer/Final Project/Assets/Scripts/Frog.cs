using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
	public float leftCap;
	public float rightCap;

	private float jumpLength = 3f;
	private float jumpHeight = 4f;

	private bool facingLeft = true;

	private Collider2D coll;
	public LayerMask ground;

	public AudioSource jump_;


	protected override void Start()
	{
		base.Start();
		coll = GetComponent<Collider2D>();
	}

	private void Update()
	{
		if(anim.GetBool("Jumping"))
		{
			if(rb.velocity.y < 0.1)
			{
				anim.SetBool("Falling", true);
				anim.SetBool("Jumping", false);
			}
		}

		if(coll.IsTouchingLayers(ground) && anim.GetBool("Falling") )
		{
			anim.SetBool("Falling", false); 
		}
	}

	private void Move()
	{
		if(facingLeft)
		{	
			if(transform.position.x > leftCap)
			{
				if(transform.localScale.x != 1)
				{
					transform.localScale = new Vector3(1, 1);
				}

				if(coll.IsTouchingLayers())
				{
					//jump_.Play();
					rb.velocity = new Vector2(-jumpLength, jumpHeight);
					anim.SetBool("Jumping", true);
				}
			}
			else
			{
				facingLeft = false;
			}
		}
		else
		{
			if(transform.position.x < rightCap)
			{
				if(transform.localScale.x != -1)
				{
					transform.localScale = new Vector3(-1, 1);
				}

				if(coll.IsTouchingLayers())
				{
					//jump_.Play();
					rb.velocity = new Vector2(jumpLength, jumpHeight);
					anim.SetBool("Jumping", true);
				}
			}
			else
			{
				facingLeft = true;
			}
		}
	}
}

