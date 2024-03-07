using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource m_AudioSource;

    public AudioClip[] audioClips;

    private void Start()
    {
        m_AudioSource = gameObject.AddComponent<AudioSource>();
        m_AudioSource.loop = true;

        PlayAudio(false);
    }

    public void PlayAudio(bool sceneChange)
    {
        m_AudioSource = FindObjectOfType<AudioSource>();

        Scene currentScene = SceneManager.GetActiveScene();
        int index = currentScene.buildIndex;

        if (sceneChange) 
        {
        
        }

        switch (index)
        {
            case 0:
                m_AudioSource.clip = audioClips[0];
                m_AudioSource.Play();
                break;
            case 1:
                m_AudioSource.clip = audioClips[1];
                m_AudioSource.Play();
                break;
        }
    }
}
