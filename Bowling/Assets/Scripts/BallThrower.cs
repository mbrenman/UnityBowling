using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour {

	public float _power = 0;
	public float _throw = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			_power += _throw * 1000 * Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			StartCoroutine(ThrowBall());		
		}
	}

	public IEnumerator ThrowBall() {
		gameObject.constantForce.force = new Vector3 (0, 0, _power);
		yield return 0;
		gameObject.constantForce.force = Vector3.zero;
	}
}
