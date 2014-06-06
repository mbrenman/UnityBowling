using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject _target;
	public int _rotationOffset = -3;
	public Vector3 verticalOffset = new Vector3(0f, 0f, 0f);
	BallThrower ballScript;

	// Use this for initialization
	void Start () {
		_target = GameObject.Find ("BowlingBall"); // Follow the ball
		ballScript = _target.GetComponent<BallThrower> ();
	}

	// Update is called once per frame
	void Update () {
		if (!ballScript._hittingPins) {
			//transform.rotation = _target.transform.rotation;
			transform.position = _target.transform.position + (transform.forward * _rotationOffset);
			transform.position += new Vector3 (0, 1, 0);
		}
	}
}
