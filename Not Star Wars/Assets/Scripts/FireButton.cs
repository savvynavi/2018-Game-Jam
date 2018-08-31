using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireButton : TouchTarget {

	public Vector3 mouseDownPos;
	public bool ButtonDown = false;

	Vector3 pos;


#if UNITY_ANDROID
#else

	public void onMouseDown(){
		OnDown(Input.mousePosition);
	}

	public void onMouseUp(){
		OnUp();
	}
#endif
	//when first clicked
	public override void OnDown(Vector3 mousePos) {
 		mouseDownPos = mousePos;
		ButtonDown = true;
		Debug.Log("start of button press");
	}

	//while dragging, will move stick to point
	public override void OnDrag(Vector3 mousePos) {
		Debug.Log("dragging");
	}

	//when stick let go, recentres
	public override void OnUp() {
		ButtonDown = false;
		Debug.Log("end of button press");
	}
}
