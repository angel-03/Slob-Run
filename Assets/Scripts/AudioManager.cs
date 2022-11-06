using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public float volume = 1f;
    public float pitch = 1f;

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

   public void Play()
   {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
   }
}

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    Sound[] sounds;

    public static AudioManager instance;

    void Awake() 
    {
        if(instance !=null)
        {
            Debug.LogError("More than one AudioManager in the scene");
        } 
        else
        {
            instance = this; 
        }
    }
    
    void Start()
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            AudioSource _source = _go.AddComponent<AudioSource>();
            sounds[i].SetSource(_source);
        }
    }

    public void PlaySound(string _name)
    {
        for(int i = 0; i < sounds.Length; i++)
        { 
            if(sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        Debug.LogWarning("AudioManager: Sound not found!");
    }
}
