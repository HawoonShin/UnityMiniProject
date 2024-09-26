using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // TODO
    // 전체 탄창수 
    // R키로 
    // 재장전
    // 탄창을 다 사용했을 경우
    // 자동 재장전

    // 총알이 몬스터와 충돌하였을 경우
    // 몬스터의 체력을 감소

    // 총알 프리팹
    [SerializeField] GameObject bulletPrefab;
    // 탄속
    [SerializeField] float bulletSpeed;


    private void Update()
    {
        // 좌클릭 입력
        if (Input.GetMouseButtonDown(0))
        {
            // 발사
            Shoot();
        }
    }

    private void Shoot()
    {
        // 발사될 방향 필요
        // Vector2.forward = new Vector2 (회전후 방향으로부터 우측으로 직선상의 부분)
        // 같은 느낌으로 만들면 될것도 같고..
        // 누르고 있는 동안 계속 발사
        // 발사 사이에 딜레이 필요?

        // 총알 생성
        GameObject bullet = Instantiate(bulletPrefab);
       // 총 위치에 총알 생성
        bullet.transform.position = gameObject.transform.position;
        // 총알 이동
       
        
    }

}
