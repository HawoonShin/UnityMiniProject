using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // ������ ��

    // �溮���� �̵�
    // �溮�� �����Ÿ�? Ȥ�� ����� ���
    // ���� ����

    // ���� ü��
    [SerializeField] int monHp;
    // �� �̵� �ӵ�
    [SerializeField] float monSpeed;
    // �� rigidbody
    [SerializeField] Rigidbody2D rigid;
    // �� ���ݷ�
    [SerializeField] float attackDamage;
    // ���� ������
    [SerializeField] float attackDelay;

    // �ڷ�ƾ ���� Ȯ��
    private bool isCoroutineRunning = false;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rigid.velocity = Vector2.left * monSpeed;
    }

    // �浹��
    private void OnCollisionStay2D(Collision2D collision)
    {
        // ���� ������Ʈ�� ü�� ����



        // �ڷ�ƾ ������ false�� ���
        // ���� �� �ڷ�ƾ ����
        if (isCoroutineRunning == false)
        {
            // ����
            Debug.Log("�����Ѵ�.");
            collision.gameObject.GetComponent<WallController>().wallHp -= attackDamage;

            // �ڷ�ƾ ����
            StartCoroutine(AttackCoroutine());
        }

    }


    // ���� �ڷ�ƾ
    IEnumerator AttackCoroutine()
    {
        isCoroutineRunning = true;
        // n�� �������� = �ڷ�ƾ
        Debug.Log("���� ��Ÿ��");
        yield return new WaitForSeconds(attackDelay);
        isCoroutineRunning = false;
    }
}
