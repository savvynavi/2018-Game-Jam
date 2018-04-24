using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHud : MonoBehaviour {
	Player player;

	public Sprite[] healthImg;
	public Image healthUI;

	private void Start(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	//sets the health sprite to one that corresponds to current hp
	private void Update(){
		healthUI.sprite = healthImg[player.currHP];
	}
}
