using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    GameManagement manager;
    Room oldRoom;
    AudioSource audio;
    public AudioClip floorAudio;
    public AudioClip elseAudio;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        audio.Play();
        //audio.Play(44100);
        manager = GameObject.Find("Background").GetComponent<GameManagement>();
        oldRoom = manager.room;
    }
	
	// Update is called once per frame
	void Update () {
        if (manager.room == Room.FLOOR && oldRoom != manager.room)
        {
            audio.clip = floorAudio;
            audio.Play();
            oldRoom = manager.room;
        }
        else
        {
            if (oldRoom != manager.room)
            {
                audio.clip = elseAudio;
                audio.Play();
                oldRoom = manager.room;
            }
        }

	}
}
