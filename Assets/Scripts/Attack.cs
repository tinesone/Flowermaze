using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	private bool attacking = false;

	private float attackingTimer = 0f;
	private float attackingCD = .03f;

	public Collider2D attackTrigger;

	private Animator anim;

	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.F) && !attacking) {
			attacking = true;
			attackingTimer = attackingCD;
			attackTrigger.enabled = true;
		}
		if (attacking){
			if (attackingTimer > 0) {
				attackingTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}
	}
}
