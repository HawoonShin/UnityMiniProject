using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // 구현할 것

    // 방벽으로 이동
    // 방벽과 일정거리? 혹은 닿았을 경우
    // 공격 실행

    // 몬스터 체력
    [SerializeField] public float monHp;
    // 몹 이동 속도
    [SerializeField] float monSpeed;
    // 몹 rigidbody
    [SerializeField] Rigidbody2D rigid;
    // 몹 공격력
    [SerializeField] float attackDamage;
    // 공격 딜레이
    [SerializeField] float attackDelay;

    // 충돌 확인
    private bool isCollision = false;

    // 코루틴 시작 확인
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

    // 충돌시
    private void OnCollisionStay2D(Collision2D collision)
    {
        isCollision = true;

        // 코루틴 동작이 false일 경우
        // 공격 후 코루틴 실행
        if (isCoroutineRunning == false &&
            collision.gameObject.tag == "Wall")
        {
            // 공격
            Debug.Log("공격한다.");
            collision.gameObject.GetComponent<WallController>().wallHp -= attackDamage;

            animator.Play(attackHash);

            // 코루틴 실행
            StartCoroutine(AttackCoroutine());
        }
        if (collision.gameObject.tag == "Bullet")
        {
           // rigid.velocity = Vector2.left * monSpeed;

            // 피격 애니메이션 실행
            animator.Play(hitHash);

        }

    }


    // 공격 쿨타임 코루틴
    IEnumerator AttackCoroutine()
    {
        isCoroutineRunning = true;
        // n초 간격으로 = 코루틴
        Debug.Log("공격 쿨타임");
        yield return new WaitForSeconds(attackDelay);
        isCoroutineRunning = false;
    }
}
