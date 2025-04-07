using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource soundPlayer;
    [SerializeField]
    AudioClipList audioList;
    private Dictionary<string, AudioClip> audioClips;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //convert list to dictionary
        audioClips = new Dictionary<string, AudioClip>();
        foreach (AudioClipEntry entry in audioList.AudioClipEntries)
        {
            audioClips.Add(entry.Key, entry.Clip);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //plays the audio clip from the AudioClipList asset wtih the givn key
    public void PlaySound(string key)
    {
        if (audioClips[key] != null)
        {
            soundPlayer.pitch = Random.Range(0.9f, 1.1f);
            soundPlayer.PlayOneShot(audioClips[key]);
        }
        else
        {
            Debug.Log(key + " clip not found");
        }
    }
}
