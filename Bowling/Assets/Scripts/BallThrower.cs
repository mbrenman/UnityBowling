using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour {

	public float _power = 0;
	public float _throw = 20;
	public bool thrown = false;
	public bool throwHasStarted = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			throwHasStarted = true;
			_power += _throw * Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			StartCoroutine(ThrowBall());		
		}
		SetUpBallLocation ();
	}

	void SetUpBallLocation() {
		if (!throwHasStarted) {
			Vector3 offset = new Vector3(0, 0, 0.05f);
			this.transform.position += offset;
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
