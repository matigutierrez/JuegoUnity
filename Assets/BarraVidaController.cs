using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaController : MonoBehaviour {

	public Image vida;

	float hp;
	float maxHp = 100f;

	// Use this for initialization
	void Start () {
		hp = maxHp;
	}
	
	public void tomarDamage(float cantidad){
		hp = Mathf.Clamp (hp - cantidad, 0f, maxHp);
		vida.transform.localScale = new Vector2 (hp/maxHp, 1);
	}

}
