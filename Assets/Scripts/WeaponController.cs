using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // 총알 프리팹
    [SerializeField] GameObject bulletPrefab;
    // 탄속
    [SerializeField] float bulletSpeed;
    // (임시) 탄창수
    [SerializeField] float bulletNumber;
    private float curBulletNumber;

    private void Start()
    {
        curBulletNumber = bulletNumber;
    }

    private void Update()
    {
        // 좌클릭 입력
        // 누르고 있는 동안 발사할 경우 Down만 제거하면 되나?
        if (Input.GetMouseButtonDown(0))
        {
            // 발사
            Shoot();
        }
        // 자동 재장전
        if(curBulletNumber<0)
        {
            curBulletNumber = bulletNumber;
            Debug.Log($"자동 재장전! (현재 탄수 : {curBulletNumber})");
        }
        // R버튼으로 재장전
        if(Input.GetKeyDown(KeyCode.R))
        {
            curBulletNumber = bulletNumber;
            Debug.Log($"재장전! (현재 탄수 : {curBulletNumber})");
        }
    }

    private void Shoot()
    {

        // 발사 사이에 딜레이 필요?

        // 총알 생성
        GameObject bullet = Instantiate(bulletPrefab);
       // 총 위치에 총알 생성
        bullet.transform.position = gameObject.transform.position;

        Debug.Log($"발사! (현재탄수 : {curBulletNumber})");

        // (임시) 탄창 수 감소
        curBulletNumber -= 1;
    }

}
