using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEfefcts : MonoBehaviour
{
    public Transform Camera;

    public float smakeRotateAmount;

    public float shakeAmount=0;

    private Vector3 startingLocalPos;

    public Vector3 InitialPos;
    
    void Start()
    {
        Camera = GameObject.Find("Main Camera").transform;
        InitialPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("caling Update Of camrera");
        if (shakeAmount>0.01f)
        {
            Debug.Log("Inside th shake Amount If Block");
            Vector3 localPosition = startingLocalPos;
            localPosition.x += shakeAmount * Random.Range(2, 3);
            localPosition.y += shakeAmount * Random.Range(2, 5);
            transform.localPosition = localPosition;
            shakeAmount = 0;

        }
        this.transform.position = InitialPos;


    }

    public void SmallShake()
    {
        Debug.Log("Small shake Method Block");
        shakeAmount = Mathf.Min(0.1f, shakeAmount + 0.01f);
        Debug.Log("Small shakeAmount>>>"+ shakeAmount);
    }

    public void BigShake()
    {
        Debug.Log("BigShake  Method Block");
        shakeAmount = Mathf.Min(0.15f, shakeAmount + 0.015f);
        Debug.Log("BigShake shakeAmount>>>" + shakeAmount);
    }


    public void RotateCameraToFront()
    {
        StartCoroutine(RotateCameraToFrontCourotine());
    }

    public void RotateCameraToSide()
    {
        StartCoroutine(RotateCameraToSideCourotine());
    }


    public IEnumerator RotateCameraToFrontCourotine()
    {
        int loopCount = 30;

        float angle = smakeRotateAmount / loopCount;

        for (int i = 0; i < loopCount; i++)
        {
            this.transform.RotateAround(Vector2.zero, new Vector3(0, 1, 0), -angle);
            yield return null;
        }
        transform.localEulerAngles = new Vector3(0, 0, 0);
        yield break; // What is use of yield break;

    }
    public IEnumerator RotateCameraToSideCourotine()
    {
        int loopCount =30;

        float angle = smakeRotateAmount / loopCount;

        for (int i = 0; i < loopCount; i++)
        {
            this.transform.RotateAround(Vector2.zero, new Vector3(0, 1, 0), angle);
            yield return null;
        }

        yield break; // hwta is use of yiled break;

    }
}
