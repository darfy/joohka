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
	public int weapon = 0;
	public Sprite sprite;
	public Sprite sprite2h;


	void Start () {
		JumpTime  = MaxJumpTime;
		anim = GetComponent<Animator>();
		Debug.Log ("animator initiated");
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
		if (Input.GetKeyDown(KeyCode.E)){
			Debug.Log ("changing weapons");
			if (weapon == 0) {
				weapon = 1;
				Debug.Log (GetComponent<SpriteRenderer> ().sprite);
				Debug.Log (Resources.Load ("spritemap_0", typeof(Sprite)) as Sprite);
				Debug.Log (sprite2h);
				this.GetComponent<SpriteRenderer> ().sprite = sprite2h;

			} else {
				weapon = 0;
				this.GetComponent<SpriteRenderer> ().sprite = sprite;
			}


			anim.SetInteger ("Weapon", weapon);
			Debug.Log ("Sprite is set to " + this.GetComponent<SpriteRenderer> ().sprite + " After weapon change" );
		}
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