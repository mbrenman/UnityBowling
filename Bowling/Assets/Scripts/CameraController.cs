using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject _target;
	public int _offset = -3;

	// Use this for initialization
	void Start () {
		_target = GameObject.Find ("Ball"); // Follow the ball
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = _target.transform.rotation;
		this.transform.position = _target.transform.position + (transform.forward * _offset);
	}
}
