using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidOnlyUI : MonoBehaviour {

	// Use this for initialization
	void Start() {
#if UNITY_ANDROID
		DeactivateButtons();
	}

#else
	//if on pc, the buttons don't appear
	void Start() { 
		gameObject.SetActive(false);
	}
#endif
	

	public void ActivateButtons() {
		gameObject.SetActive(true);

	}

	public void DeactivateButtons() {
		gameObject.SetActive(false);
	}
}
