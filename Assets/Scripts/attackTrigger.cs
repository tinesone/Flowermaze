using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {
	
	
	public float attackCooldown = 3f;
	private float attackTimer = 0f;
	Control control;
	
	void FixedUpdate(){
		if (attackTimer > 0f)
			attackTimer -= .1f;
	}
	
	
	
	void OnTriggerStay2D(Collider2D col){
		Control control = this.transform.parent.GetComponent<Control>();
		if (Input.GetMouseButton(0) && attackTimer <= 0){
			col.SendMessageUpwards("ApplyDamage", control.dmg);
			attackTimer = attackCooldown;
		}
	}
}