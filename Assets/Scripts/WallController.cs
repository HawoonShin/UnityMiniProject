using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallController : MonoBehaviour
{
    // 방벽 체력
    [SerializeField] public float wallHp;

    // 반영할 슬라이더
    [SerializeField] Slider slider;
    float maxHp;

    private void Awake()
    {
        maxHp = wallHp;
    }

    private void Update()
    {
         Debug.Log($"{wallHp}");

        // 방벽의 체력이 0이 될 경우
        if (wallHp <= 0)
        {
            // 방벽 파괴
            Destroy(gameObject);    
            // 게임 오버
        }

        HpSlider();
    }

    private void HpSlider()
    {
        slider.value = wallHp / maxHp;
    }
}
