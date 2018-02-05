﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Control : MonoBehaviour {
	public float speed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
		float x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		transform.Translate(x, y, 0);
	}
}
