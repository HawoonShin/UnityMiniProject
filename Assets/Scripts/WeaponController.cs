using TMPro;
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

    // �Ѿ� �߻� ����
    [SerializeField] GameObject fire;

    // �Ѿ� ���� UI ��¿�
    [SerializeField] TextMeshProUGUI bulletText;

    private void Start()
    {
        curBulletNumber = bulletNumber;
        fire.SetActive(false);
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

            // �߻� ����
            fire.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            fire.SetActive(false);
        }

        // R��ư���� ������
        if (Input.GetKeyDown(KeyCode.R))
        {
            curBulletNumber = bulletNumber;
            bulletText.text = "������!";
            Debug.Log($"������! (���� ź�� : {curBulletNumber})");
        }
        if (curBulletNumber >= 0)
        {
            bulletText.text = $"{curBulletNumber}/{bulletNumber}";
        }
        else if (curBulletNumber < 0)
        {
            bulletText.text = "������ ��...";
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
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // bullet.transform.rotation = Quaternion.Euler(0,0,-90);
            // �ڿ� ���ʹϾ� �Ⱦ��� -90 �׷��� �ٿ��ٰ� �����¾��� ����
            // ������ ������ �Ʒ��� �߻�...
            // �ҷ������� �ű�� �ذ�

            // ��� �߻� �� �Ҳ��� Ƣ�� ���� ȿ��
            // ������Ʈ�� on off�ؼ� 

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
