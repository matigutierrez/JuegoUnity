using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float maxspeed = 3f;

	public float speed = 3f;

	private Rigidbody2D rigi2d;

	private GameObject ExpBarra;

	// Use this for initialization
	void Start () {
		rigi2d = GetComponent<Rigidbody2D>();
		ExpBarra = GameObject.Find ("BarraExp");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		this.rigi2d.AddForce (Vector2.right * speed);

		float limitedSpeed = Mathf.Clamp(rigi2d.velocity.x, -maxspeed, maxspeed);
		this.rigi2d.velocity = new Vector2 (limitedSpeed, rigi2d.velocity.y);

		if(rigi2d.velocity.x > -0.01f && rigi2d.velocity.x < 0.01f) {
			speed = -speed;
			this.rigi2d.velocity = new Vector2 (speed, rigi2d.velocity.y);
		}

		if(speed < 0) {
			transform.localScale = new Vector3 (3, 3, 1);
		}

		if(speed > 0) {
			transform.localScale = new Vector3 (-3, 3, 1);
		}
	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag == "Player"){

			float yDif = 0.4f;
			if (transform.position.y + yDif < col.transform.position.y) {
				col.SendMessage ("jumpEnemy");
				ExpBarra.SendMessage ("agregarExp", 15);
				Destroy (gameObject);
			} else {
				col.SendMessage ("golpeEnemy", transform.position.x);
			}
		}
	}
}
