using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // �����ų ����� �ҽ�
    [SerializeField] AudioSource gunFX;

    private void Update()
    {
        // ���콺 ��Ŭ����
        if (Input.GetMouseButtonDown(0))
        {
            // �ѼҸ� ���
            gunFX.Play();
        }
    }
}
