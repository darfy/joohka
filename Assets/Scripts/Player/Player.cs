using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float Speed = 0f;
	public float MaxJumpTime = 2f;
	public float JumpForce;
	private float move = 0f;
	private float JumpTime = 0f;
	private bool CanJump;
	public Animator anim;


	void Start () {
		JumpTime  = MaxJumpTime;
		anim = GetComponent<Animator>();
		Debug.Log ("anim");
	}


	void Update ()
	{
		if (!CanJump)
			JumpTime  -= Time.deltaTime;
		if (JumpTime <= 0)
		{
			CanJump = true;
			JumpTime  = MaxJumpTime;
		}
	}

	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", move);
		if (move < 0 && move != 0) {
			anim.SetBool ("Right", false);
		} else
			anim.SetBool ("Right", true);

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * Speed, GetComponent<Rigidbody2D>().velocity.y);

		if (Input.GetKey (KeyCode.W)  && CanJump)
		{
			Debug.logger.Log ("JAMP");
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (GetComponent<Rigidbody2D>().velocity.x,JumpForce));
			CanJump = false;
			JumpTime  = MaxJumpTime;
		}
	}
}