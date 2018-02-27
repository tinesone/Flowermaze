using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int maxHealth = 20;
	public int curHealth = 0;

	void Start(){
		curHealth = maxHealth;
	}

	void Update(){
		if (curHealth <= 0) {
			Destroy (gameObject);
		}
	}


	public void RecieveDamage(int dmg){
		curHealth -= dmg;
	}
}
