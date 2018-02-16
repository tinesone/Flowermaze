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
		triggerDistanceY = Screen.height * distance;
	}

	// Update is called once per frame
	void Update () {
		Vector2 screenPos = Camera.main.WorldToScreenPoint(player.transform.position);
		Vector2 newScreenPosition = new Vector2(Screen.width / 2, Screen.height / 2);

		if (screenPos.x < triggerDistanceX)
			newScreenPosition += new Vector2(screenPos.x - triggerDistanceX, 0);
		else if(screenPos.x > Screen.width - triggerDistanceX)
			newScreenPosition += new Vector2(screenPos.x - Screen.width + triggerDistanceX, 0);

		if (screenPos.y < triggerDistanceY)
			newScreenPosition += new Vector2(0, screenPos.y - triggerDistanceY);
		else if(screenPos.y > Screen.height - triggerDistanceY)
			newScreenPosition += new Vector2(0, screenPos.y - Screen.height + triggerDistanceY);

		newScreenPosition = Camera.main.ScreenToWorldPoint(newScreenPosition);
		moveCameraTo(newScreenPosition);
	}

	void moveCameraTo(Vector2 pos){
		transform.position = new Vector3(pos.x, pos.y, -10);
	}
}
