using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


	public GameObject playerFollow;
	public Vector2 minCamP;
	public Vector2 maxCamP;
	public float retardo;

	private Vector2 velocidad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float posX = Mathf.SmoothDamp(transform.position.x ,playerFollow.transform.position.x, ref velocidad.x, retardo);
		float posY = Mathf.SmoothDamp(transform.position.y ,playerFollow.transform.position.y, ref velocidad.y, retardo);

		transform.position = new Vector3 (Mathf.Clamp(posX, minCamP.x, maxCamP.x), Mathf.Clamp(posY, minCamP.y, maxCamP.y), transform.position.z);
	}
}
