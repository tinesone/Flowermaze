using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(AudioSource))]
public class DetectPlayer : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;

    private int musicPicker;
    private int musicBlocker;

    public static DetectPlayer Instance;
    public float FadeTime = 2.0f;


    private static bool keepFadingIn;
    private static bool keepFadingOut;


    private string boundariesFileName = "boundaries.json";

    //Dictionary<string, List<float>> boundaries = new Dictionary<string, List<float>>();
    Boundaries boundaries;

    GameObject player;

    void Start()
    {
        loadBoundaryData();
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        musicBlocker = 0;
        Instance = this;
    }

    void Update()
    {
        print(audioSource.volume);
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        if (x >= -3.5f && x <= 3.5f && y >= -3.5f && y <= 3.5f)
            musicPicker = 1;
        else if (x >= 3.5f && x <= 10.5f && y >= 3.5f && y <= 10.5f)
            musicPicker = 2;
        else if (x >= 3.5f && x <= 10.5f && y >= -7f && y <= -3.5)
            musicPicker = 3;
        switch (musicPicker)
        {
            case (1):
                if (musicBlocker != musicPicker)
                {
                    musicBlocker = musicPicker;
                    Crossfade(music1, FadeTime);
                }
                break;
            case (2):
                if (musicBlocker != musicPicker)
                {
                    musicBlocker = musicPicker;
                    Crossfade(music2, FadeTime);
                }
                break;
            case (3):
                if (musicBlocker != musicPicker)
                {
                    musicBlocker = musicPicker;
                    Crossfade(music3, FadeTime);
                }
                break;
        }
    }

    private void loadBoundaryData()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, boundariesFileName);

        if (File.Exists(filePath))
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

    public static void Crossfade(AudioClip newTrack, float fadeTime = 1.0f)
    {
        AudioSource newAudioSource = Instance.gameObject.AddComponent<AudioSource>();

        newAudioSource.volume = 0.0f;

        newAudioSource.clip = newTrack;

        newAudioSource.Play();

        Instance.StartCoroutine(Instance.RealCrossFade(newAudioSource, fadeTime));
    }

    private IEnumerator RealCrossFade(AudioSource newAudioSource, float fadeTime)
    {
        float t = 0.0f;

        while (t < fadeTime)
        {
            newAudioSource.volume = Mathf.Lerp(0.0f, 1.0f, t / fadeTime);
            audioSource.volume = 1.0f - newAudioSource.volume;

            t += Time.deltaTime;
            yield return null;
        }

        newAudioSource.volume = 1.0f;

        audioSource = newAudioSource;
    }
}
 


/*
void Earbuds(stupid person)
{
    Destroy(person);
}

Earbuds(mees);

*/