using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // �Ѿ� ������
    [SerializeField] GameObject bulletPrefab;
    // ź��
    [SerializeField] float bulletSpeed;
    // (�ӽ�) źâ��
    [SerializeField] float bulletNumber;
    private float curBulletNumber;

    private void Start()
    {
        curBulletNumber = bulletNumber;
    }

    private void Update()
    {
        // ��Ŭ�� �Է�
        // ������ �ִ� ���� �߻��� ��� Down�� �����ϸ� �ǳ�?
        if (Input.GetMouseButtonDown(0))
        {
            // �߻�
            Shoot();
        }
        // �ڵ� ������
        if(curBulletNumber<0)
        {
            curBulletNumber = bulletNumber;
            Debug.Log($"�ڵ� ������! (���� ź�� : {curBulletNumber})");
        }
        // R��ư���� ������
        if(Input.GetKeyDown(KeyCode.R))
        {
            curBulletNumber = bulletNumber;
            Debug.Log($"������! (���� ź�� : {curBulletNumber})");
        }
    }

    private void Shoot()
    {

        // �߻� ���̿� ������ �ʿ�?

        // �Ѿ� ����
        GameObject bullet = Instantiate(bulletPrefab);
       // �� ��ġ�� �Ѿ� ����
        bullet.transform.position = gameObject.transform.position;

        Debug.Log($"�߻�! (����ź�� : {curBulletNumber})");

        // (�ӽ�) źâ �� ����
        curBulletNumber -= 1;
    }

}
