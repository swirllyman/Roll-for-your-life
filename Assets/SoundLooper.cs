using UnityEngine;
using System.Collections;

public class SoundLooper : MonoBehaviour {

    public bool mute = false;

    public AudioClip[] songs;
    AudioSource aSource;
    int currentSongNumber = 0;

	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
        aSource.clip = songs[currentSongNumber];
        currentSongNumber++;
        aSource.Play();
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        aSource.mute = mute;

        if (!aSource.isPlaying) {
            NextSong();
        }

    }


    public void NextSong() {
        aSource.clip = songs[currentSongNumber];
        currentSongNumber = ((currentSongNumber + 1) % songs.Length);
        aSource.Play();
    }

	public void ToggleSound()
	{
        mute = !mute;
	}
}
