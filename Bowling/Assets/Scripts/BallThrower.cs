using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour {

	public float _power = 0;
	public float _throw = 20;
	public bool thrown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			_power += _throw * Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			StartCoroutine(ThrowBall());		
		}
	}

	public IEnumerator ThrowBall() {
		if (!thrown) {
			thrown = true; //Do not throw anymore

			Vector3 movement = new Vector3 (0, 0, _power);
			rigidbody.velocity = movement;
			yield return 0;
		}
	}
}
