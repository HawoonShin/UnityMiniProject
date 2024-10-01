using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // ������ ��

    // �溮���� �̵�
    // �溮�� �����Ÿ�? Ȥ�� ����� ���
    // ���� ����

    // ���� ü��
    [SerializeField] public float monHp;
    // �� �̵� �ӵ�
    [SerializeField] float monSpeed;
    // �� rigidbody
    [SerializeField] Rigidbody2D rigid;
    // �� ���ݷ�
    [SerializeField] float attackDamage;
    // ���� ������
    [SerializeField] float attackDelay;

    // �浹 Ȯ��
    private bool isCollision = false;

    // �ڷ�ƾ ���� Ȯ��
    private bool isCoroutineRunning = false;

    [SerializeField] Animator animator;
    private static int walkHash = Animator.StringToHash("walk");
    private static int attackHash = Animator.StringToHash("attack");
    private static int hitHash = Animator.StringToHash("hit");


    private void Update()
    {
        rigid.velocity = Vector3.zero;

        if (monHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isCollision == false)
        {
            Move();
        }
    }

    private void Move()
    {
        rigid.velocity = Vector2.left * monSpeed;
        animator.Play(walkHash);
    }

    // �浹��
    private void OnCollisionStay2D(Collision2D collision)
    {
        isCollision = true;

        // �ڷ�ƾ ������ false�� ���
        // ���� �� �ڷ�ƾ ����
        if (isCoroutineRunning == false &&
            collision.gameObject.tag == "Wall")
        {
            // ����
            Debug.Log("�����Ѵ�.");
            collision.gameObject.GetComponent<WallController>().wallHp -= attackDamage;

            animator.Play(attackHash);

            // �ڷ�ƾ ����
            StartCoroutine(AttackCoroutine());
        }
        if (collision.gameObject.tag == "Bullet")
        {
           // rigid.velocity = Vector2.left * monSpeed;

            // �ǰ� �ִϸ��̼� ����
            animator.Play(hitHash);

        }

    }


    // ���� ��Ÿ�� �ڷ�ƾ
    IEnumerator AttackCoroutine()
    {
        isCoroutineRunning = true;
        // n�� �������� = �ڷ�ƾ
        Debug.Log("���� ��Ÿ��");
        yield return new WaitForSeconds(attackDelay);
        isCoroutineRunning = false;
    }
}
