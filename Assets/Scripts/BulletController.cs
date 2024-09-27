using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // TODO
    // �Ѿ� �߻�
    // �Ѿ��� ���Ϳ� ���� ���
    // ������ ü���� ����
    // �Ѿ��� ����

    // �̵���ų rigidbody
    [SerializeField] Rigidbody2D rigid;
    // ź��
    [SerializeField] float bulletSpeed;

    // �Ѿ��� ���ݷ� �ʿ�
    [SerializeField] float bulletDamage;

    // �Ѿ� �߻� ��ġ?
    [SerializeField] Transform firePoint;

    // ������ źȯ�� �����ɶ� �ҷ���
    private void Start()
    {
        // �Ѿ� �߻�
        rigid.velocity = transform.right * bulletSpeed;

        // �浹�� ���� ���
        // �����ð� ���� �Ѿ� ����
        StartCoroutine(DestroyCoroutine());

    }

    private void Update()
    {
      

    }

    // ���Ϳ� �Ѿ��� �浹�� ���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���ʹ� ü�� ����
        collision.gameObject.GetComponent<MonsterController>().monHp -= bulletDamage;
        Debug.Log("���� ����");

        // �Ѿ��� ����
        Destroy(gameObject);
    }

    // �Ѿ� �ڵ� ���� 
    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
