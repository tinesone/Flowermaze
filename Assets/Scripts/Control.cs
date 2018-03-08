using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Control : MonoBehaviour {

	Rigidbody2D rb;

	public int dmg = 20;
	
	public float speed = 10f;
	
	public float y;
	public float x;
	

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		y = Input.GetAxisRaw("Vertical") * speed;
		x = Input.GetAxisRaw("Horizontal") * speed;
		rb.velocity = new Vector2(x, y);
	}
}
