using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Life")]
    [SerializeField] private Transform lifeParent;
    [SerializeField] private HeartUI[] hearts;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI infotext;

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

        fadeImg.color = new Vector4(0, 0, 0, 1);

        DoFadeImage();
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

    // 음악 소리 변경
    public void OnBgmSliderValueChanged()
    {
        float bgmVolume = bgmSlider.value;
        SoundManager.Instance.SetBGMVolume(bgmVolume);
    }
    public void OnEffectSliderValueChanged()
    {
        float effectVolume = effectSlider.value;
        SoundManager.Instance.SetEffectVolume(effectVolume);
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

    public void DoFadeInImage()
    {
        fadeImg.DOFade(1.0f, 0.7f).SetUpdate(true);
    }

    public void DoSceneChange(int i)
    {
        fadeImg.DOFade(1.0f, 0.7f).SetUpdate(true).OnComplete(() => SceneManager.LoadScene(i));
    }
    public void DoFadeImage()
    {
        fadeImg.DOFade(1.0f, 0.7f).OnComplete(() => fadeImg.DOFade(0f, 1.2f));
    }

    public void SetInfoText(string text)
    {
        infotext.text = text;
        TextType();
    }
    public void TextType()
    {
        infotext.maxVisibleCharacters = 0;
        DOTween.To(x => infotext.maxVisibleCharacters = (int)x, 0f, infotext.text.Length, 4f).OnComplete(() => infotext.text = "");
    }
}
