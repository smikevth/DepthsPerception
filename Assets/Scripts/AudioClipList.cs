using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipList", menuName = "Scriptable Objects/AudioClipList")]
public class AudioClipList : ScriptableObject
{
    public List<AudioClipEntry> AudioClipEntries;
}
