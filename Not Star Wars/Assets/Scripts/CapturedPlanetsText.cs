using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapturedPlanetsText : MonoBehaviour {

	public Player player;
	Text text;


	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		text.text = "PLANETS CAPTURED: " + player.planetsCaptured + "/" + player.planetsToCapture;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "PLANETS CAPTURED: " + player.planetsCaptured + "/" + player.planetsToCapture;
	}
}
