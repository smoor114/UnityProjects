using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

	//Movement Variables
	private int jumpHeight = 23;
	private int moveSpeed = 8;
	private int moveSpeed_boost = 12;
	
	//Start() Variables
	private Rigidbody2D rb;
	private Animator anim;
	private Collider2D coll;
	public LayerMask ground;

	//State Variables
	private enum State{idle, running, jumping, falling, hurt};
	private State state = State.idle;

	//Score Variables
	private int cherries = 0;
	public Text cherryText;
	private int maxCherries = 50;
	public Text maxCherryText;
	public Text winText;

	private float hurtForce = 10f;

	private bool unlocked_dj = false;
	private bool unlocked_speed = false;

	private bool can_dj = true;

	public Image orange_img;
	public Image grape_img;
	
	//Sound Sources
	public AudioSource footstep_;
	public AudioSource jump_;
	public AudioSource hit_;
	public AudioSource cherry_;
	public AudioSource orange_;


	private void Start()
	{
		orange_img.enabled = false;
		grape_img.enabled = false;
		winText.enabled = false;
		cherryText.text = cherries.ToString();
		maxCherryText.text = maxCherries.ToString();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		coll = GetComponent<Collider2D>();
		//footstep = GetComponent<AudioSource>();
	}

	private void Update()
	{ 
		if(state != State.hurt)
		{
			InputManager();
		}
		checkWin();
		VelocityState();
		anim.SetInteger("state", (int)state);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Collectable")
		{
			cherry_.Play();
			Destroy(collision.gameObject);
			cherries += 1;
			cherryText.text = cherries.ToString();
		}

		if(collision.tag == "powerup_jump")
		{
			orange_.Play();
			orange_img.enabled = true;
			Destroy(collision.gameObject);
			unlocked_dj = true;
		}

		if(collision.tag == "powerup_speed")
		{
			orange_.Play();
			grape_img.enabled = true;
			Destroy(collision.gameObject);
			moveSpeed = moveSpeed_boost;
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Enemy enemy = other.gameObject.GetComponent<Enemy>();
			if(state == State.falling)
			{
				enemy.JumpedOn();
				Jump();
				//Destroy(other.gameObject);
			}
			else
			{
				state = State.hurt;
				cherries -= 1;
				cherryText.text = cherries.ToString();
				hit_.Play();
				if(other.gameObject.transform.position.x > transform.position.x)
				{
					//Enemy is to right - Damage taken, pushed left
					rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
				}
				else
				{
					//Enemy is to left - Damage taken, pushed right
					rb.velocity = new Vector2(hurtForce, rb.velocity.y);
				}
			}

		}
	}

	private void InputManager()
	{
		//Run
		if(Input.GetKey(KeyCode.A))
		{
			rb.velocity = new Vector2(-moveSpeed,rb.velocity.y);
			transform.localScale = new Vector2(-1,1);	
		}
		else if(Input.GetKey(KeyCode.D))
		{
			rb.velocity = new Vector2(moveSpeed,rb.velocity.y);
			transform.localScale = new Vector2(1,1);
		}
		//Jump
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(coll.IsTouchingLayers(ground))
			{
				Jump();
			}
			else if((unlocked_dj) && (can_dj))
			{
				Jump();
				can_dj = false;
			}
		}d
	}

	private void VelocityState()
	{
		if(state == State.jumping)
		{
			if(rb.velocity.y < 0.1f)
			{
				state = State.falling;
			}
		}
		else if(state == State.falling)
		{
			if(coll.IsTouchingLayers(ground))
			{
				state = State.idle;
				can_dj = true;
			}
		}
		else if(state == State.hurt)
		{
			if(Mathf.Abs(rb.velocity.x) < 0.1f)
			{
				state = State.idle;
			}
		}
		else if(rb.velocity.y > 2f)
		{
			state = State.jumping;
		}
		else if(Mathf.Abs(rb.velocity.x) > 2f)
		{
			state = State.running;
		}
		else
		{
			state = State.idle;
		}

	}

	private void Jump()
	{
		jump_.Play();
		rb.velocity = new Vector2(rb.velocity.x,jumpHeight);
		state = State.jumping;
	}
	private void Dash()
	{

		rb.velocity = new Vector2(rb.velocity.x + 20 ,rb.velocity.y);
	}
		

	private void Footstep()
	{
		footstep_.Play();
	}

	private void checkWin()
	{
		if(cherries >= maxCherries)
		{
			winText.enabled = true;
		}
	}

}
