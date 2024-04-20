using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Life")]
    [SerializeField] private Transform lifeParent;
    [SerializeField] private HeartUI[] hearts;


    [Header("Setting")]
    [SerializeField] private GameObject settingPanel;
    private bool isSetting = false;
    public bool IsSetting => isSetting;

    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider effectSlider;

    private string bgmKey = "BGMVolume";
    private string effectKey = "EffectVolume";


    [Header("ETC")]
    [SerializeField] private Image fadeImg;

    private void Awake()
    {
        if (Instance != null) print("UIManager Error");
        Instance = this;
    }

    private void Start()
    {
        isSetting = false;
        settingPanel.SetActive(false);

        hearts = lifeParent.GetComponentsInChildren<HeartUI>();

        bgmSlider.value = PlayerPrefs.GetFloat(bgmKey);
        effectSlider.value = PlayerPrefs.GetFloat(effectKey);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSetting) // 세팅이 켜져 있을땐
            {
                OffSetting();
            }
            else // 반대
            {
                OnSetting();
            }
        }
    }

    public void OnSetting()
    {
        isSetting = true;
        settingPanel.SetActive(true);

        Time.timeScale = 0;
    }
    public void OffSetting()
    {
        isSetting = false;
        settingPanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void SetLife(int value)
    {
        for(int i = 0; i < value; ++i)
        {
            hearts[i].SetFillHeart();
        }
        for(int i = 0; i < 3 - value; ++i)
        {
            hearts[i].SetEmptyHeart();
        }
    }

    public void DoFadeImage()
    {
        fadeImg.DOFade(1.0f, 0.7f).OnComplete(() => fadeImg.DOFade(0f, 0.5f));
    }
}
