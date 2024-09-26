using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // 방벽 체력
    [SerializeField] public float wallHp;

    private void Update()
    {
        Debug.Log($"{wallHp}");
    }
}
