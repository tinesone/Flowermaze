using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour {
	public GameObject player;
	Control control;
	public float distance = 10f;
	float triggerDistanceX;
	float triggerDistanceY;

	void Start () {
		control = player.GetComponent<Control> ();
		distance /= 100f;
		triggerDistanceX = Screen.width * distance; 
		triggerDistanceY = Screen.width * distance;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 screenPos = Camera.main.WorldToScreenPoint(player.transform.position);
		if (screenPos.x < triggerDistanceX || screenPos.y < triggerDistanceY || screenPos.x > Screen.width - triggerDistanceX || screenPos.y > Screen.height - triggerDistanceY) {
			Vector2 pos = Vector2.MoveTowards((Vector2)transform.position, (Vector2)player.transform.position, control.speed * Time.deltaTime); 
			transform.position = new Vector3 (pos.x, pos.y, -1);
		}
	}
}
