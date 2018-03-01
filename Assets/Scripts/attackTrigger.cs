using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {
	
	public int dmg =  2;
	
	public float attackCooldown = .5f;
	private float attackTimer = 0f;
	
	
	void OnTriggerEnter2D(Collider2D col){
		if (Input.GetKeyDown(KeyCode.F)){
			col.SendMessageUpwards("ApplyDamage", dmg);
		}
	}
	
	void OnTriggerStay2D(Collider2D col){
		if (Input.GetKeyDown(KeyCode.F)){
			col.SendMessageUpwards("ApplyDamage", dmg);
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		if (Input.GetKeyDown(KeyCode.F)){
			col.SendMessageUpwards("ApplyDamage", dmg);
		}
	}
}
