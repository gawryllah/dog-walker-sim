using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeScript : MonoBehaviour
{
    private void Start()
    {
        transform.DOMove(new Vector3(transform.position.x - 10f, 0f, 0f), 3).SetEase(Ease.InOutBounce).SetLoops(-1, LoopType.Yoyo);
    }
}
