﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableTimer : MonoBehaviour {

    public float timer = 0;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            gameObject.SetActive(false);
        }
	}
}
