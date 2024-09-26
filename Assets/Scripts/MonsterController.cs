using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // 구현할 것

    // 방벽으로 이동
    // 방벽과 일정거리? 혹은 닿았을 경우
    // 공격 실행

    // 몬스터 체력
    [SerializeField] int monHp;
    // 몹 이동 속도
    [SerializeField] float monSpeed;
    // 몹 rigidbody
    [SerializeField] Rigidbody2D rigid;
    // 몹 공격력
    [SerializeField] float attackDamage;
    // 공격 딜레이
    [SerializeField] float attackDelay;

    // 코루틴 시작 확인
    private bool isCoroutineRunning = false;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rigid.velocity = Vector2.left * monSpeed;
    }

    // 충돌시
    private void OnCollisionStay2D(Collision2D collision)
    {
        // 닿은 오브젝트의 체력 감지



        // 코루틴 동작이 false일 경우
        // 공격 후 코루틴 실행
        if (isCoroutineRunning == false)
        {
            // 공격
            Debug.Log("공격한다.");
            collision.gameObject.GetComponent<WallController>().wallHp -= attackDamage;

            // 코루틴 실행
            StartCoroutine(AttackCoroutine());
        }

    }


    // 공격 코루틴
    IEnumerator AttackCoroutine()
    {
        isCoroutineRunning = true;
        // n초 간격으로 = 코루틴
        Debug.Log("공격 쿨타임");
        yield return new WaitForSeconds(attackDelay);
        isCoroutineRunning = false;
    }
}
