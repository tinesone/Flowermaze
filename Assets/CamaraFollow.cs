using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour {
	public GameObject player;
	Control control;

	// Use this for initialization
	void Start () {
		control = player.GetComponent<Control> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)player.transform.position, control.speed * Time.deltaTime);
		transform.position = new Vector3(pos.x, pos.y, -1);
	}
}
