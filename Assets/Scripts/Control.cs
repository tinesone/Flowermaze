using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Control : MonoBehaviour {

	Rigidbody2D rb;

	public int dmg = 20;
	
	public float speed = 10f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float y = Input.GetAxisRaw("Vertical") * speed;
		float x = Input.GetAxisRaw("Horizontal") * speed;
		rb.velocity = new Vector2(x, y);
	}
}
