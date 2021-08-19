using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	protected Animator anim;
	protected Rigidbody2D rb;
	public AudioSource death;

	protected virtual void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

    public void JumpedOn()
	{
		anim.SetTrigger("Death");
		death.Play();
		rb.velocity = Vector2.zero;
		rb.constraints = RigidbodyConstraints2D.FreezeAll;
	}

	private void Death()
	{
		Destroy(this.gameObject);
	}
}
