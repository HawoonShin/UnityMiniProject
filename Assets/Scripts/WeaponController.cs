using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // TODO
    // ��ü źâ�� 
    // RŰ�� 
    // ������
    // źâ�� �� ������� ���
    // �ڵ� ������

    // �Ѿ��� ���Ϳ� �浹�Ͽ��� ���
    // ������ ü���� ����

    // �Ѿ� ������
    [SerializeField] GameObject bulletPrefab;
    // ź��
    [SerializeField] float bulletSpeed;


    private void Update()
    {
        // ��Ŭ�� �Է�
        if (Input.GetMouseButtonDown(0))
        {
            // �߻�
            Shoot();
        }
    }

    private void Shoot()
    {
        // �߻�� ���� �ʿ�
        // Vector2.forward = new Vector2 (ȸ���� �������κ��� �������� �������� �κ�)
        // ���� �������� ����� �ɰ͵� ����..
        // ������ �ִ� ���� ��� �߻�
        // �߻� ���̿� ������ �ʿ�?

        // �Ѿ� ����
        GameObject bullet = Instantiate(bulletPrefab);
       // �� ��ġ�� �Ѿ� ����
        bullet.transform.position = gameObject.transform.position;
        // �Ѿ� �̵�
       
        
    }

}
