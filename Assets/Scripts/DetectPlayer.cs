using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(AudioSource))]
public class DetectPlayer : MonoBehaviour
{
    public float fadeTime = 2.0f;
    public List<AudioClip> musicClips = new List<AudioClip>();
    private AudioSource audioSource;

    private int currentArea = -1;
    private int nextArea = -1;
    private int fadeDirection = 0;
    private float fadeStartTime;
    private GameObject player;

    private float volume;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        int area = GetArea(); // Get the area where the player currently is
        if((area == -1 || area == currentArea) && nextArea == -1) return; // If the player is in no area and we are not currently fading then return
        if(nextArea == -1 || (area != nextArea && area != -1)) // If the player steps into a new area
        {
            nextArea = area;
            if(fadeDirection == 0) fadeStartTime = Time.time;
            if(fadeDirection == 1) fadeStartTime = Time.time - (fadeTime - (Time.time - fadeStartTime));
            fadeDirection = -1;
        }
        if (audioSource.clip != null) // Check if clip is playing
        {
            // If a clip is already active, Fade out
            volume = (Time.time - fadeStartTime) / fadeTime; // Calculate the volume
            if (fadeDirection == -1) volume = 1 - volume; // Invert the volume if necessary
        } else
        {
            // If  no clip is active, skip fading and instantly set volume to 0
            volume = 0;
        }
        if(volume >= 1 && fadeDirection == 1) // If we reached 100% volume and a clip is playing, stop fading
        {
            currentArea = nextArea;
            nextArea = -1;
            volume = 1;
            fadeDirection = 0;
        }
        if(volume <= 0 && fadeDirection == -1) // If we reached 0% volume invert fading direction
        {
            volume = 0;
            fadeDirection = 1;
            fadeStartTime = Time.time;
            audioSource.clip = musicClips[nextArea]; //Used this instead of audioSource.playOneShot() becouse this one can loop, and also can check if there is already a clip playinh
            audioSource.Play();
        }
        audioSource.volume = volume;
    }

    int GetArea()
    {
      float x = player.transform.position.x;
      float y = player.transform.position.y;

      if (x >= -3.5f && x <= 3.5f && y >= -3.5f && y <= 3.5f)
          return 0;
      else if (x >= 3.5f && x <= 10.5f && y >= 3.5f && y <= 10.5f)
          return 1;
      else if (x >= 3.5f && x <= 10.5f && y >= -7f && y <= -3.5)
          return 2;
      return -1;
    }
}
