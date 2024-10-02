using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallController : MonoBehaviour
{
    // �溮 ü��
    [SerializeField] public float wallHp;

    // �ݿ��� �����̴�
    [SerializeField] Slider slider;
    float maxHp;

    private void Awake()
    {
        maxHp = wallHp;
    }

    private void Update()
    {
         Debug.Log($"{wallHp}");

        // �溮�� ü���� 0�� �� ���
        if (wallHp <= 0)
        {
            // �溮 �ı�
            Destroy(gameObject);    
            // ���� ����
        }

        HpSlider();
    }

    private void HpSlider()
    {
        slider.value = wallHp / maxHp;
    }
}
