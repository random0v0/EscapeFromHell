using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tween : MonoBehaviour
{
    public GameObject uiii;
    public float xpos;
    public float time;
    public float localpos;
    public Ease ease;



    public void InvenUIShow()
    {
        transform.DOLocalMoveX(xpos, time).SetEase(ease);
    }

    public void InvenUIOff()
    {
        transform.DOLocalMoveX(localpos, time).SetEase(ease);
    }

}
