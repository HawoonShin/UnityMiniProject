using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // TODO
    // 총알 발사
    // 총알이 몬스터와 닿을 경우
    // 몬스터의 체력을 감소
    // 총알은 삭제

    // 이동시킬 rigidbody
    [SerializeField] Rigidbody2D rigid;
    // 탄속
    [SerializeField] float bulletSpeed;

    // 총알의 공격력 필요
    [SerializeField] float bulletDamage;

    // 총알 발사 위치?
    [SerializeField] Transform firePoint;

    // 총으로 탄환이 생성될때 불러옴
    private void Start()
    {
        // 총알 발사
        rigid.velocity = transform.right * bulletSpeed;

        // 총알 회전
        transform.rotation = Quaternion.Euler(0, 0, -90);

        // 충돌이 없을 경우
        // 일정시간 이후 총알 삭제
        StartCoroutine(DestroyCoroutine());

    }

    private void Update()
    {


    }

    // 몬스터와 총알이 충돌할 경우
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            // 몬스터는 체력 감소
            collision.gameObject.GetComponent<MonsterController>().monHp -= bulletDamage;
            Debug.Log("몬스터 공격");
            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall")
        {
            // 총알은 삭제
            Destroy(gameObject);

        }
    }

    // 총알 자동 삭제 
    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
