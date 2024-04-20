using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource source;

    private string bgmKey = "BGMVolume";
    private string effectKey = "EffectVolume";

    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip jumpSound;
    

    private void Awake()
    {
        if (Instance != null)
        {
            print("사운드매니저에러에러");
        }
        Instance = this;

        source = GetComponent<AudioSource>();
            
        PlayerPrefs.SetFloat(bgmKey, 0.1f);
        PlayerPrefs.SetFloat(effectKey, 0.4f);
    }
    private void Start()
    {
        GameManager.Instance.mainCam.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(bgmKey);
        GameManager.Instance.mainCam.GetComponent<AudioSource>().loop = true;

        source.volume = PlayerPrefs.GetFloat(effectKey);
    }

    public void PlayJumpSound()
    {
        source.PlayOneShot(jumpSound);
    }
    public void PlayCoinSound()
    {
        source.PlayOneShot(coinSound);
    }
}
