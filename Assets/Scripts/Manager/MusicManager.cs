using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class MusicManager : Singleton<MusicManager> {
    
    private AudioClip backgroundMusic;
    private AudioClip moneyMusic;
    private AudioClip loseMusic;
    private AudioClip buttonMusic;
    [HideInInspector]
    public bool isPlayingMusic = true;
    private AudioSource audioSource;
    void Start () {
        backgroundMusic = Resources.Load("bgm") as AudioClip;
        moneyMusic = Resources.Load("money") as AudioClip;
        loseMusic = Resources.Load("lose") as AudioClip;
        buttonMusic = Resources.Load("button") as AudioClip;
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.volume = 0.5f;
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }
	
	public void PlayMusic()
    {
        audioSource.Play();
        isPlayingMusic = true;
    }

    public void StopMusic()
    {
        audioSource.Pause();
        isPlayingMusic = false;
    }

    public void PlayButtonSound()
    {
        if(isPlayingMusic)
        {
            audioSource.PlayOneShot(buttonMusic);
            AudioSource.PlayClipAtPoint(buttonMusic, Vector3.zero);
        }
    }

    public void PlayMoneySound()
    {
        if (isPlayingMusic)
        {
            audioSource.PlayOneShot(moneyMusic);
            AudioSource.PlayClipAtPoint(moneyMusic, Vector3.zero);
        }
    }

    public void PlayLoseSound()
    {
        if (isPlayingMusic)
        {
            audioSource.PlayOneShot(loseMusic);
            AudioSource.PlayClipAtPoint(loseMusic, Vector3.zero);
        }
    }
}
