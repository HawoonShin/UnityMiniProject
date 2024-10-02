using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    // 컨트롤 할 슬라이더
    [SerializeField] Slider slider;

    //  상태를 반영할 오브젝트
    [SerializeField] GameObject target;

    float maxhp;
    float curhp;

    private void Awake()
    {
        
    }

    private void Update()
    {
        slider.value = curhp/maxhp;
    }
    // 오브젝트의 스크립터 중 체력 부분 참조
    // 참조한 체력 대비 %로 비율 반영

}
