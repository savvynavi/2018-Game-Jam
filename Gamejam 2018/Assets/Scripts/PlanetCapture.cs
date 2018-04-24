using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlanetCapture : MonoBehaviour {
	SphereCollider collider;

	public float TimeToCapture;
	public Material capturedMat;

	// Use this for initialization
	void Start () {
		collider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		//if the planet is captured, disables both trigger box and this script so it isn't constantly checking this
		if(TimeToCapture <= 0){
			//changes the material when captured
			GetComponentInChildren<MeshRenderer>().material = capturedMat;
			Debug.Log("Planet Captured!");

			collider.enabled = false;
			this.enabled = false;
		}
	}

	private void OnTriggerStay(Collider other){
		Player tmp = other.gameObject.GetComponent<Player>();
		//if triggered by player, timer goes up
		if(tmp != null && TimeToCapture > 0){
			Debug.Log("trigger hit by player");
			TimeToCapture -= Time.deltaTime;
		}
	}
}
