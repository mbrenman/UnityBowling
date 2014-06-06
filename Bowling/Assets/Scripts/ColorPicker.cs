using UnityEngine;
using System.Collections;

public class ColorPicker : MonoBehaviour {

	public Color color;
	public bool isRandom;
	void Start () {
		//color = null;
		if(isRandom)
			color = new Color(Random.Range(0,100)/100f,Random.Range(0,100)/100f,Random.Range(0,100)/100f);
		this.gameObject.renderer.material.color = color;
	
	}

}
