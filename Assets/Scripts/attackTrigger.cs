﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {
	
	
	public float attackCooldown = 1.5f;
	private float attackTimer = 0f;
	
	void FixedUpdate(){
		if (attackTimer > 0f)
			attackTimer -= .1f;
	}
	
	
	
	void OnTriggerStay2D(Collider2D col){
		Control control = this.transform.parent.parent.GetComponent<Control>();
		if (Input.GetMouseButtonDown(0) && attackTimer <= 0){
			col.SendMessageUpwards("ApplyDamage", control.dmg);
			attackTimer = attackCooldown;
		}
	}
}