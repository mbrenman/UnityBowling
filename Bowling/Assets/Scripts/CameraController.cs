using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject _target;
	public Vector3 _offset;

	// Use this for initialization
	void Start () {
		_target = GameObject.Find ("Ball"); // Follow the ball
		_offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = _target.transform.position + _offset;
	}
}
