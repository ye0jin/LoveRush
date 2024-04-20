using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject btnContainer;
    [SerializeField] private Image fadeImg;

    [SerializeField] private GameObject girlObj;

    [Header("Dialog")]
    [SerializeField] private Transform dialogParent;
    [SerializeField] private DialogUI dialogboy;
    [SerializeField] private DialogUI dialoggirl;
    [SerializeField] private DialogUI[] dialogList;

    [SerializeField] private string[] textList;

    private void Start()
    {
        fadeImg.DOFade(0f, 1.5f);
    }

    public void Move()
    {
        btnContainer.transform.DOLocalMoveY(1070f, 2.0f).OnComplete(() =>
        {
            btnContainer.SetActive(false);
            btnContainer.transform.localPosition = Vector3.zero;
        });
        background.transform.DOLocalMoveY(10f, 3f).SetEase(Ease.InOutQuint).OnComplete(() => StartCoroutine(StartTalking()));
    }

    private IEnumerator StartTalking()
    {
        int i = 0;

        DialogUI d = Instantiate(dialogboy, dialogParent);
        d.SetDialog(textList[i++]);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialoggirl, dialogParent);
        d.SetDialog(textList[i++]);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialoggirl, dialogParent);
        d.SetDialog(textList[i++]);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialoggirl, dialogParent);
        d.SetDialog(textList[i++]);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialogboy, dialogParent);
        d.SetDialog(textList[i++]);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialoggirl, dialogParent);
        d.SetDialog(textList[i++]);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        d = Instantiate(dialoggirl, dialogParent);
        d.SetDialog(textList[i++]);
        yield return new WaitForSeconds(2f);
        Destroy(d.gameObject);

        fadeImg.DOFade(1.0f, 1.5f).OnComplete(() =>
        {
            fadeImg.DOFade(0f, 1.0f);
            girlObj.SetActive(false);
        });

        yield return new WaitForSeconds(3.0f);

        d = Instantiate(dialogboy, dialogParent);
        d.SetDialog(textList[i++]);
        yield return new WaitForSeconds(1.5f);

        FadeIn();
    }

    public void FadeIn()
    {
        fadeImg.DOFade(1.0f, 1.5f).OnComplete(() => SceneManager.LoadScene(1));
    }
}
