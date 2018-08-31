using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidOnlyUI : MonoBehaviour {

#if UNITY_ANDROID
	// Use this for initialization
	void Start() {

		DeactivateButtons();
	}
		public void ActivateButtons() {
		gameObject.SetActive(true);

	}

	public void DeactivateButtons() {
		gameObject.SetActive(false);
	}
#else
	//if on pc, the buttons don't appear
	void Start() { 
		gameObject.SetActive(false);
	}
#endif
	


}
