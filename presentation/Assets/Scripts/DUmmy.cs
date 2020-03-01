using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUmmy : MonoBehaviour {

	private Horse_Controller_Script horseControllerScript;
	private cameraTurnAround camTurn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (horseControllerScript.VSpeedRun);
	}
}
