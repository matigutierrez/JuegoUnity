using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxspeed = 3f;

	public float speed = 2f;

	public bool ground;

	public float podersalto = 90000000000000;

	private SpriteRenderer spr;
	private bool jump; 
	private bool movement = true;
	private Rigidbody2D rigi2d;
	private Animator animator;

	private GameObject barraVida;

	// Use this for initialization
	void Start () {
		rigi2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
		barraVida = GameObject.Find ("BarraVida");
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("speed", Mathf.Abs (rigi2d.velocity.x));
		animator.SetBool ("ground", ground);

		if (Input.GetKeyDown(KeyCode.UpArrow) && ground) {
			jump = true;
		}
	}

	void FixedUpdate() {
		
		float h = Input.GetAxis ("Horizontal");
		if (!movement)
			h = 0;

		this.rigi2d.AddForce (Vector2.right * speed * h);

		float limitedSpeed = Mathf.Clamp(rigi2d.velocity.x, -maxspeed, maxspeed);
		this.rigi2d.velocity = new Vector2 (limitedSpeed, rigi2d.velocity.y);

		if(h > 0.1f) {
			transform.localScale = new Vector3 (3, 3, 1);
		}

		if(h < -0.1f) {
			transform.localScale = new Vector3 (-3, 3, 1);
		}

		if (jump) {
			rigi2d.AddForce(Vector2.up * podersalto);
			jump = false;

			Debug.Log ("hola");
		}
	}

	public void jumpEnemy (){
		jump = true;
	}

	public void golpeEnemy(float enemyx){

		barraVida.SendMessage ("tomarDamage", 15);

		jump = true;

		float side = Mathf.Sign (enemyx - transform.position.x);
		rigi2d.AddForce (Vector2.left * side * podersalto);

		movement = false;
		Invoke ("enableMovement", 1f);

		spr.color = Color.red;
	}

	void enableMovement(){
		movement = true;
		spr.color = Color.white;
	}
}
