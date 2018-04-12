using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSuelo : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		this.player = GetComponentInParent<PlayerController>();
	}
	
	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.tag == "suelo") {
			player.ground = true;
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.tag == "suelo") {
			player.ground = false;
		}
	}
}
