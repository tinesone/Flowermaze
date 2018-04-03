using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class DetectPlayer : MonoBehaviour {

    AudioSource audioSource;

    private bool played = false;

    public AudioClip music1;

    GameObject player;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
    
        Control control = player.GetComponent<Control>();
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        if (x >= -3.5 && x <= 3.5 && y >= -3.5 && y <= 3.5 && played == false)
        {
            audioSource.PlayOneShot(music1, 1f);
            played = true;

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