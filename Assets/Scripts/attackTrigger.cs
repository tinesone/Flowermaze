﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {
	public int dmg = 2;
	
	

	void OnTriggerStay2D(Collider2D col){
		if (col.isTrigger != true && col.CompareTag ("Enemy"))
			col.SendMessage ("RecieveDamage", dmg);
	}
}
