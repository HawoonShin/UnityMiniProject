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

    // 총알 발사 위치?
    [SerializeField] Transform firePoint;

    private void Start()
    {
        curBulletNumber = bulletNumber;
    }

    private void Update()
    {
        // 좌클릭 입력
        // 총알 발사 사이에 딜레이를 추가해서 누르고 있는동안(연사시) 여러발이 나가는 것 방지할것
        // 발사 사이 딜레이 추가 전까지는 Down으로 사용
        if (Input.GetMouseButtonDown(0))
        {
            // 발사
            Shoot();
        }

        // R버튼으로 재장전
        if (Input.GetKeyDown(KeyCode.R))
        {
            curBulletNumber = bulletNumber;
            Debug.Log($"재장전! (현재 탄수 : {curBulletNumber})");
        }
    }

    private void Shoot()
    {
        // 탄창수가 0> 일 경우 발사
        if (curBulletNumber >= 0)
        {
            // 발사 사이에 딜레이 필요? = 연사력

            // 총알 생성
            // 총 위치에 총알 생성
            GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
           

            // Debug.Log($"발사! (현재탄수 : {curBulletNumber})");

            // 탄창 수 감소
            curBulletNumber -= 1;
        }

        // 자동 재장전
        else if (curBulletNumber < 0)
        {
            // 재장전에 딜레이를 넣어줄것

            // 재장전
            curBulletNumber = bulletNumber;
            // Debug.Log($"자동 재장전! (현재 탄수 : {curBulletNumber})");
        }

    }

}
