using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class BowlingPin : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		//Debug.Log(collision.relativeVelocity.magnitude);
		if (collision.relativeVelocity.magnitude > 2){
			audio.Play();
		}
		
	}
}
