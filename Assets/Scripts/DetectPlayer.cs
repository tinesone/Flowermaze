using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class DetectPlayer : MonoBehaviour {

    AudioSource audioSource;


    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;

    private int musicPicker;
    private int musicBlocker;

    GameObject player;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        musicBlocker = 0;
	}

	void Update () {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        if (x >= -3.5f && x <= 3.5f && y >= -3.5f && y <= 3.5f)
            musicPicker = 1;
        else if (x >= 3.5f && x <= 10.5f && y >= 3.5f && y <= 10.5f)
            musicPicker = 2;
        else if (x >= 3.5f && x <= 10.5f && y >= -3.5f && y <= -10.5f)
            musicPicker = 3;
        switch (musicPicker)
        {
            case (1):
                if (musicBlocker != musicPicker)
                {
                    audioSource.Stop();
                    audioSource.PlayOneShot(music1, 1f);
                }
                musicBlocker = musicPicker;
                break;
            case (2):
                if (musicBlocker != musicPicker)
                {
                    audioSource.Stop();
                    audioSource.PlayOneShot(music2, 1f);
                }
                musicBlocker = musicPicker;
                break;
            case (3):
                if (musicBlocker != musicPicker)
                {
                    audioSource.Stop();
                    audioSource.PlayOneShot(music3, 1f);
                }
                musicBlocker = musicPicker;
                break;
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
