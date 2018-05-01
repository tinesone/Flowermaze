using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(AudioSource))]
public class DetectPlayer : MonoBehaviour
{
    public float fadeTime = 2.0f;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;

    private int currentArea;
    private int nextArea = -1;
    private int fadeDirection = 0;
    private float fadeStartTime;
    private GameObject player;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        float volume = (Time.time-fadeStartTime)/fadeTime; // Calculate the volume
        if(fadeDirection == -1) volume = 1 - volume; // Invert the volume if necessary
        if(volume >= 1 && fadeDirection == 1) // If we reached 100% volume stop fading
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
            Debug.Log(nextArea); // TODO: Need to replace with audio play
        }
        audioSource.volume = volume;
    }

    int GetArea()
    {
      float x = player.transform.position.x;
      float y = player.transform.position.y;

      if (x >= -3.5f && x <= 3.5f && y >= -3.5f && y <= 3.5f)
          return 1;
      else if (x >= 3.5f && x <= 10.5f && y >= 3.5f && y <= 10.5f)
          return 2;
      else if (x >= 3.5f && x <= 10.5f && y >= -7f && y <= -3.5)
          return 3;
      return -1;
    }
}
