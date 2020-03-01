using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Horse_Controller_Script : MonoBehaviour {
	public Text Score; 

	private Animator myAnimator;
	public float VSpeedRun = 0.0f;
	private float direction = 0.0f;
	private int counter = 0;
	
	void Start () {
		myAnimator = GetComponent<Animator> ();
		Score.text = counter.ToString ();
	}

	void FixedUpdate () {
		if (Input.GetAxis ("Vertical") > 0.0f && Input.GetButton ("Fire3") && VSpeedRun < 1.1f) {
			VSpeedRun += 0.05f;
		} else if (VSpeedRun > 0 ){
			VSpeedRun -= 0.05f;
		} else {
			VSpeedRun = 0.0f;
		}

		if (Input.GetAxis ("Vertical") > 0.0f) {
			myAnimator.SetFloat ("VSpeed", Input.GetAxis ("Vertical") + VSpeedRun);
			direction += Input.GetAxis ("Horizontal") * (2 - Input.GetAxis ("Vertical") * 1.5f);
			transform.position += (transform.forward * (Input.GetAxis ("Vertical") + VSpeedRun) * 3) * Time.deltaTime;
		} else if (Input.GetAxis ("Vertical") <= 0.0f) {
			myAnimator.SetFloat ("VSpeed", VSpeedRun -= 0.05f );
		}
		transform.rotation = Quaternion.Euler(0.0f, direction, 0.0f);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Collectable")){
			other.gameObject.SetActive(false);
			counter += 100;
			Score.text = counter.ToString ();
		} 

		if (counter >= 1800) {
			Score.text = ("You Win!");
		}
	}
}
