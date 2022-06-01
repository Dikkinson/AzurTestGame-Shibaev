using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinRoller : MonoBehaviour
{
    [Range(0.5f, 2f)]
    [SerializeField] private float bounceDuration = 1.3f;
    [Range(0.5f, 3f)]
    [SerializeField] private float rotateDuration = 2f;
    void Start()
    {
        transform.DOMoveY(bounceDuration, 1).SetLoops(-1,LoopType.Yoyo);
        transform.DORotate(new Vector3(0, 360, 0), rotateDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
}
