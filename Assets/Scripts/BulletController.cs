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

        // �Ѿ� ȸ��
        transform.rotation = Quaternion.Euler(0, 0, -90);

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
        if (collision.gameObject.tag == "Monster")
        {
            // ���ʹ� ü�� ����
            collision.gameObject.GetComponent<MonsterController>().monHp -= bulletDamage;
            Debug.Log("���� ����");
            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
        {
            // �Ѿ��� ����
            Destroy(gameObject);

        }
    }

    // �Ѿ� �ڵ� ���� 
    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
