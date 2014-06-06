using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour {

	public float _throw = 20;
	public bool _hittingPins = false;
	public float maxPower = 10f;

	private float _power = 0;
	private bool thrown = false;
	private bool changingLocation = true;
	private bool changingRotation = true;
	private int  maxLaneWidth = 1;
	private int  minLaneWidth = -1;
	private bool increasingWidth = true;
	private bool increasingRotation = true;
	private int maxRotation = 30;
	private int minRotation = 330;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.touchCount == 1) {
//			Touch touch = Input.GetTouch(0);
			if (changingLocation) {
				if (Input.GetKey (KeyCode.Space)) {
//				if (touch.phase == TouchPhase.Began) {
					changingLocation = false;
				}
				ChangeBallLocation ();
			} else if (changingRotation) {
				if (Input.GetKey (KeyCode.Space)) {
//				if (touch.phase == TouchPhase.Began) {
					changingRotation = false;
				}
				changeBallRotation();
			} else {
				if (Input.GetKey (KeyCode.Space)) {
//				if (touch.phase == TouchPhase.Began) {
					_power += _throw * Time.deltaTime;
				}
			if (Input.GetKeyUp (KeyCode.Space)) {
//				if (touch.phase == TouchPhase.Ended) {
					_power = Mathf.Min(_power,maxPower);
					StartCoroutine(ThrowBall());
				}
			}
//		}
	}

	void ChangeBallLocation() {
		Vector3 offset = new Vector3(0.04f, 0, 0);
		if (increasingWidth) {
			this.transform.position += offset;
			if (this.transform.position.x > maxLaneWidth) {	
				increasingWidth = false;
				this.transform.position -= offset;
			}
		} else if (!increasingWidth) {
			this.transform.position -= offset;
			if (this.transform.position.x < minLaneWidth) {	
				increasingWidth = true;
				this.transform.position += offset;
			}
		}
	}

	void changeBallRotation() {
		if (increasingRotation) {
			transform.rotation = transform.rotation * Quaternion.Euler(0f, 1f, 0f);
//			Debug.Log(transform.rotation.eulerAngles.y);
			if (transform.rotation.eulerAngles.y > maxRotation && transform.rotation.eulerAngles.y < 60) {	
				increasingRotation = false;
			}
		} else if (!increasingRotation) {
			transform.rotation = transform.rotation * Quaternion.Euler(0f, (-1f), 0f);
			if (transform.rotation.eulerAngles.y < minRotation && transform.rotation.eulerAngles.y > 300) {	
				increasingRotation = true;
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.name == "Cylinder") {
			_hittingPins = true;
		}
	}
	
	public IEnumerator ThrowBall() {
		if (!thrown) {
			//Do not throw anymore
			thrown = true; 
			//Rotate the throw by the rotation angle
			rigidbody.velocity = transform.forward * _power;
			yield return new WaitForSeconds(5);
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
