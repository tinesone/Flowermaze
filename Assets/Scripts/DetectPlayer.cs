using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {



    GameObject player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        Control control = player.GetComponent<Control>();
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        if (x >= -3.5 && x <= 3.5 && y >= -3.15 && y <= 3.15)
        {
            control.ApplyDamage(20);
        }
	}
}


/*
void Earbuds(stupid person)
{
    Destroy(person);
}

Earbuds(mees);

*/