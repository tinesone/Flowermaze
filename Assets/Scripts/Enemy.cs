using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour {
	
	public int armor = 30;

	public float maxHealth = 200f;
	private float curHealth = 0;
	
	public GameObject player;
	
	public AudioClip death;
	public AudioClip hit;
	AudioSource audioSource;
	
	void Start(){
		audioSource = GetComponent<AudioSource>();
		curHealth = maxHealth;
	}

	void Update(){
		if (curHealth <= 0) {
			Destroy (gameObject);
			audioSource.PlayOneShot(death, 1f);
		}
	}


	public void ApplyDamage(float dmg){
		dmg = dmg - (dmg * armor / 100f);
		curHealth -= dmg;
		print(curHealth);
		audioSource.PlayOneShot(hit, 1f);
	}
}
