using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour {
	public GameObject player;
	Control control;
	public float widthOffset = 1;
	public float heigtOffset = 1;

	// Use this for initialization
	void Start () {
		control = player.GetComponent<Control> ();
		print (Screen.width);
		print (Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
		if (offset.x < -1*((Screen.width/200)-widthOffset)){
			Vector2 pos = Vector2.Lerp((Vector2)transform.position, (Vector2)player.transform.position, control.speed * Time.deltaTime);
			transform.position = new Vector3(pos.x, pos.y, -1);
			//print (offset.x);
			print (-1*((Screen.width/200)-widthOffset));
		}
	}
}
