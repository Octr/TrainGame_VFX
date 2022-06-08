using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    #region Variables
    public Sound[] sounds;
    public AudioMixer AudioMix;
    private static AudioManager instance = null;
    #endregion

    #region Initialize
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (AudioManager)FindObjectOfType(typeof(AudioManager));
                if (instance == null)
                    instance = (new GameObject("AudioManager")).AddComponent<AudioManager>();
            }

            return instance;
        }
    }

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.awake;
            s.source.spatialBlend = s.spatialBlend;
            s.source.bypassListenerEffects = s.bypassListenerEffects;

            s.source.outputAudioMixerGroup = s.mixerGroup;
        }

    }

    #endregion

    #region Internal

    private void PlayAudio(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Play();
    }

    private void PauseAudio(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    private void StopAudio(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    private void PlayAudioPitch(string sound, float pitch)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = pitch;

        s.source.Play();
    }

    private void WaitForAudio(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        StartCoroutine(WaitForAudioFinish(s.source));
    }

    #endregion

    #region Public
    public void Play(Audio audio)
    {
        PlayAudio(audio.ToString());
        Debug.Log("Playing Audio: " + audio.ToString());
    }

    public void PlayPitch(Audio audio, float pitch)
    {
        PlayAudioPitch(audio.ToString(), pitch);
        Debug.Log("Playing Audio: " + audio.ToString());
    }

    public void Stop(Audio audio)
    {
        StopAudio(audio.ToString());
        Debug.Log("Stopping Audio: " + audio.ToString());
    }

    public void Pause(Audio audio)
    {
        PauseAudio(audio.ToString());
        Debug.Log("Pausing Audio: " + audio.ToString());
    }

    public void Wait(Audio audio)
    {
        WaitForAudio(audio.ToString());
        Debug.Log("Waiting For Audio: " + audio.ToString());
    }

    IEnumerator WaitForAudioFinish(AudioSource source)
    {
        yield return new WaitForSeconds(source.clip.length);
    }

    #endregion
}