using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    // ��Ʈ�� �� �����̴�
    [SerializeField] Slider slider;

    //  ���¸� �ݿ��� ������Ʈ
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
    // ������Ʈ�� ��ũ���� �� ü�� �κ� ����
    // ������ ü�� ��� %�� ���� �ݿ�

}
