using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // �溮 ü��
    [SerializeField] public float wallHp;

    private void Update()
    {
        // Debug.Log($"{wallHp}");

        // �溮�� ü���� 0�� �� ���
        if (wallHp < 0)
        {
            // �溮 �ı�
            Destroy(gameObject);    
            // ���� ����
        }
    }
}
