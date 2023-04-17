using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShotCountText : MonoBehaviour
{
    public AnimationCurve scaleCurve;

    public CanvasGroup canvasGroup;

    public TextMeshProUGUI ShotText1;
    public TextMeshProUGUI ShotText2;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        ShotText1 = GameObject.Find("Cannonbase").transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ShotText2 = GameObject.Find("Cannonbase").transform.GetChild(3).transform.GetChild(1).GetComponent<TextMeshProUGUI>();


      // transform.localScale = Vector3.zero;
    }

  public void SetShotText_1(string text1)
    {
        ShotText1.text = text1;
    }
    public void SetShotText_2(string text1)
    {
        ShotText1.text = text1;
    }

    public void AnimationCanvas()
    {
        canvasGroup.alpha = 1;
        transform.localScale = Vector3.one;
      // StartCoroutine(AnimationNumerator());
    }


    IEnumerator AnimationNumerator()
    {



        for (int i = 0; i < 60; i++)
        {
            transform.localScale = Vector3.one * scaleCurve.Evaluate(i / 50);
            Debug.Log("    transform.localScale Inside Loop ==" + transform.localScale);
            //    if (i>40)
            //    {
            //        canvasGroup.alpha = (60 - i) / 20;
            //    }
            //    Debug.Log("canvasGroup.alpha In Loop ==" + canvasGroup.alpha + "value of i=" + i);
        }

        Debug.Log("canvasGroup.alpha Outside Loop ==" + canvasGroup.alpha );
            Debug.Log("    transform.localScale Outside Loop ==" + transform.localScale);
            yield break;
    }

}
