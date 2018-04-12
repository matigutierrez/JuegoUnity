using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraExpController : MonoBehaviour {

	public Image Exp;
	public Text texto;


	int nivel = 0;
	float exp;
	float expMax = 100f;

	// Use this for initialization
	void Start () {
		texto.text = "Nivel" + nivel.ToString();
		exp = 0f;
	}
	
	public void agregarExp(float cantidad){
		exp = Mathf.Clamp (exp + cantidad, 0f, expMax);
		Exp.transform.localScale = new Vector2 (exp/expMax, 1);
		if(exp == 100f){
			nivel = nivel + 1;
			texto.text = "Nivel" + nivel.ToString();
			Exp.transform.localScale = new Vector2 (0, 1);
		}
	}
}
