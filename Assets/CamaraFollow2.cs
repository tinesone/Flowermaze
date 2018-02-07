using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow2 : MonoBehaviour {
	public GameObject player;
	Control control;
	float triggerDistance = 3;

	void Start () {
		control = player.GetComponent<Control> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offSet = new Vector2 (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
		if (offSet.x < triggerDistance * -1 || offSet.x > triggerDistance || offSet.y < triggerDistance * -1 || offSet.y > triggerDistance) {
			Vector2 pos = Vector2.MoveTowards((Vector2)transform.position, (Vector2)player.transform.position, control.speed * Time.deltaTime); 
			transform.position = new Vector3 (pos.x, pos.y, -1);
		}
	}
}
