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
        int area = GetArea();
        if((area == -1 || area == currentArea) && nextArea == -1) return;
        if(nextArea == -1)
        {
            nextArea = area;
            fadeStartTime = Time.time;
            fadeDirection = -1;
        }
        float volume = (Time.time-fadeStartTime)/fadeTime;
        if(fadeDirection == -1) volume = 1 - volume;
        if(volume >= 1 && fadeDirection == 1)
        {
            currentArea = nextArea;
            nextArea = -1;
            volume = 1;
        }
        if(volume <= 0 && fadeDirection == -1)
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
