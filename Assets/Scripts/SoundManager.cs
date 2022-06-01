using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound { Coin, Boost, Victory, Walk }
public class SoundManager : MonoBehaviour
{
    public SoundAudioClip[] sounds;
    private static Dictionary<Sound, float> soundTimerDict;

    public static SoundManager i;
    private void Awake()
    {
        if (!i)
        {
            i = this;
        }else
        {
            Destroy(gameObject);
        }
        soundTimerDict = new Dictionary<Sound, float>();
        soundTimerDict[Sound.Walk] = 0f;
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
    }
    
    public static void PlaySound(Sound sound, float timeBetweenShots = 0)
    {
        if (CanPlaySound(sound, timeBetweenShots))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();

            Destroy(soundGameObject, audioSource.clip.length);
        }
    }
    private static bool CanPlaySound(Sound sound, float timeBetweenShots = 0)
    {
        switch (sound)
        {
            default:
                return true;
            case Sound.Walk:
                if (soundTimerDict.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDict[sound];
                    if (lastTimePlayed + timeBetweenShots < Time.time)
                    {
                        soundTimerDict[sound] = Time.time;
                        return true;
                    }else
                    {
                        return false;
                    }
                }else
                {
                    return true;
                }
        }
    }
    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAudioClip soundAudioClip in i.sounds) 
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.Log($"Sound {sound} not found!");
        return null;
    }
}
