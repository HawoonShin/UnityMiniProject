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

    // �Ѿ� �߻� ��ġ?
    [SerializeField] Transform firePoint;

    private void Start()
    {
        curBulletNumber = bulletNumber;
    }

    private void Update()
    {
        // ��Ŭ�� �Է�
        // �Ѿ� �߻� ���̿� �����̸� �߰��ؼ� ������ �ִµ���(�����) �������� ������ �� �����Ұ�
        // �߻� ���� ������ �߰� �������� Down���� ���
        if (Input.GetMouseButtonDown(0))
        {
            // �߻�
            Shoot();
        }

        // R��ư���� ������
        if (Input.GetKeyDown(KeyCode.R))
        {
            curBulletNumber = bulletNumber;
            Debug.Log($"������! (���� ź�� : {curBulletNumber})");
        }
    }

    private void Shoot()
    {
        // źâ���� 0> �� ��� �߻�
        if (curBulletNumber >= 0)
        {
            // �߻� ���̿� ������ �ʿ�? = �����

            // �Ѿ� ����
            // �� ��ġ�� �Ѿ� ����
            GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
           

            // Debug.Log($"�߻�! (����ź�� : {curBulletNumber})");

            // źâ �� ����
            curBulletNumber -= 1;
        }

        // �ڵ� ������
        else if (curBulletNumber < 0)
        {
            // �������� �����̸� �־��ٰ�

            // ������
            curBulletNumber = bulletNumber;
            // Debug.Log($"�ڵ� ������! (���� ź�� : {curBulletNumber})");
        }

    }

}
