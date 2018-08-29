using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(SphereCollider))]
public class PlanetCapture : MonoBehaviour {
	SphereCollider collider;
	float timer = 0;

	public float totalTime;
	public float TimeToCapture;
	public Material capturedMat;
    public GameObject player;
    public GameObject conquerText;
    public bool capturing;
	public Image planetDial;

	// Use this for initialization
	void Start () {
		collider = GetComponent<SphereCollider>();
		totalTime = TimeToCapture;
		planetDial.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if the planet is captured, disables both trigger box and this script so it isn't constantly checking this
		if(TimeToCapture <= 0){
			//changes the material when captured
			GetComponentInChildren<SpriteRenderer>().material = capturedMat;
            player.GetComponent<Player>().planetsCaptured++;
            conquerText.GetComponent<disableTimer>().timer = 0;
            conquerText.SetActive(true);
            this.enabled = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Player tmp = other.gameObject.GetComponent<Player>();
		if(tmp != null && TimeToCapture > 0)
		{
			capturing = true;
			planetDial.enabled = true;
		}
	}

	private void OnTriggerStay(Collider other){
		Player tmp = other.gameObject.GetComponent<Player>();
		//if triggered by player, timer goes up
		if(tmp != null && TimeToCapture > 0)
		{
			timer += Time.deltaTime;
			Debug.Log("trigger hit by player");

			planetDial.fillAmount =  timer / totalTime;

			TimeToCapture -= Time.deltaTime;
		}
	}

	private void OnTriggerExit(Collider other){
		Player tmp = other.gameObject.GetComponent<Player>();
		if(tmp != null){
			planetDial.enabled = false;
		}
	}
}
