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
    [SerializeField] private AudioClip healSound;
    [SerializeField] private AudioClip sakuraSound;
    [SerializeField] private AudioClip purchaseSound;
    

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

    // 배경음악은 메인 카메라로 재생
    // 볼륨 조절 함수
    public void SetBGMVolume(float value)
    {
        GameManager.Instance.mainCam.GetComponent<AudioSource>().volume = value;
        PlayerPrefs.SetFloat(bgmKey, value);
    }
    public void SetEffectVolume(float value)
    {
        source.volume = value;
        PlayerPrefs.SetFloat(effectKey, value);
    }


    public void PlayJumpSound()
    {
        source.PlayOneShot(jumpSound);
    }
    public void PlayCoinSound()
    {
        source.PlayOneShot(coinSound);
    }
    public void PlayHealSound()
    {
        source.PlayOneShot(healSound);
    }
    public void PlayPurchaseSound()
    {
        source.PlayOneShot(purchaseSound);
    }
    public void PlaySakuraSound()
    {
        source.PlayOneShot(sakuraSound);
    }
}
