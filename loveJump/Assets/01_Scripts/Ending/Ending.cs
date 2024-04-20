using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] private Image fadeImg;
    [SerializeField] private TextMeshProUGUI infotext;
    [SerializeField] private GameObject Endboy;

    [SerializeField] private GameObject button;
    [SerializeField] private GameObject button2;

    [Header("Dialog")]
    [SerializeField] private Transform dialogParent;
    [SerializeField] private DialogUI dialogboy;
    [SerializeField] private DialogUI dialoggirl;
    [SerializeField] private DialogUI[] dialogList;

    [SerializeField] private string[] textList;
    [SerializeField] private string[] textList2;

    private void Start()
    {
        infotext.text = "";
        fadeImg.DOFade(0f, 1.2f);
    }

    public void GiveHerFlower()
    {
        Endboy.GetComponent<Animator>().SetTrigger("Give");
        button.SetActive(false);
        button2.SetActive(false);

        StartCoroutine(TalkingWithFlower());
    }
    public void ApologizeHer()
    {
        button2.SetActive(false);
        StartCoroutine(TalkingWithApologize());
    }

    private IEnumerator TalkingWithFlower()
    {
        int i = 0;
        yield return new WaitForSeconds(5.0f);

        DialogUI d = Instantiate(dialogboy, dialogParent);
        d.SetDialog(textList[i++], 0);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialoggirl, dialogParent);
        d.SetDialog(textList[i++], 0);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialoggirl, dialogParent);
        d.SetDialog(textList[i++], 0);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        button2.SetActive(true);
    }

    private IEnumerator TalkingWithApologize()
    {
        int i = 0;
        yield return new WaitForSeconds(3.0f);

        DialogUI d = Instantiate(dialogboy, dialogParent);
        d.SetDialog(textList2[i++], 0);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialogboy, dialogParent);
        d.SetDialog(textList2[i++], 0);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialoggirl, dialogParent);
        d.SetDialog(textList2[i++], 0);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialoggirl, dialogParent);
        d.SetDialog(textList2[i++], 0);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialoggirl, dialogParent);
        d.SetDialog(textList2[i++], 0);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        fadeImg.DOFade(1f, 1.2f);
        infotext.text = "그렇게 행복하게 살았답니다~";
        TextType();
    }

    public void TextType()
    {
        infotext.maxVisibleCharacters = 0;
        DOTween.To(x => infotext.maxVisibleCharacters = (int)x, 0f, infotext.text.Length, 4f).OnComplete(() => SceneManager.LoadScene(0));
    }
}
