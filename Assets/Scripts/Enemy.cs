using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public int armor = 30;

	public float maxHealth = 200f;
	private float curHealth = 0;
	
	public GameObject player;

	void Start(){
		curHealth = maxHealth;
	}

	void Update(){
		if (curHealth <= 0) {
			Destroy (gameObject);
		}
	}


	public void ApplyDamage(float dmg){
		dmg = dmg - (dmg * armor / 100f);
		curHealth -= dmg;
		print(curHealth);
	}
}
