using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

[RequireComponent(typeof(AudioSource))]
public class DetectPlayer : MonoBehaviour {
  AudioSource audioSource;

  public AudioClip music1;
  public AudioClip music2;
  public AudioClip music3;

  private int musicPicker;
  private int musicBlocker;

  private string boundariesFileName = "boundaries.json";

  //Dictionary<string, List<float>> boundaries = new Dictionary<string, List<float>>();
  Boundaries boundaries;

  GameObject player;

	void Start () {
    audioSource = GetComponent<AudioSource>();
    player = GameObject.FindGameObjectWithTag("Player");
    musicBlocker = 0;

    loadBoundaryData();
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

  private void loadBoundaryData()
  {
    // Path.Combine combines strings into a file path
    // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
    string filePath = Path.Combine(Application.streamingAssetsPath, boundariesFileName);

    if(File.Exists(filePath))
    {
      // Read the json from the file into a string
      string dataAsJson = File.ReadAllText(filePath);
      // Pass the json to JsonUtility, and tell it to create a GameData object from it
      Boundaries loadedData = JsonUtility.FromJson<Boundaries>(dataAsJson);

      // Retrieve the allRoundData property of loadedData
      boundaries = loadedData;
    }
    else
    {
      Debug.LogError("Cannot load music boundaries!");
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
