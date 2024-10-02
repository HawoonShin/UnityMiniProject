using TMPro;
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

    // 총알 발사 연출
    [SerializeField] GameObject fire;

    // 총알 갯수 UI 출력용
    [SerializeField] TextMeshProUGUI bulletText;

    private void Start()
    {
        curBulletNumber = bulletNumber;
        fire.SetActive(false);
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

            // 발사 연출
            fire.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            fire.SetActive(false);
        }

        // R버튼으로 재장전
        if (Input.GetKeyDown(KeyCode.R))
        {
            curBulletNumber = bulletNumber;
            bulletText.text = "재장전!";
            Debug.Log($"재장전! (현재 탄수 : {curBulletNumber})");
        }
        if (curBulletNumber >= 0)
        {
            bulletText.text = $"{curBulletNumber}/{bulletNumber}";
        }
        else if (curBulletNumber < 0)
        {
            bulletText.text = "재장전 중...";
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
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // bullet.transform.rotation = Quaternion.Euler(0,0,-90);
            // 뒤에 쿼터니언 안쓰고 -90 그래도 붙였다가 오류냈었음 ㅋㅎ
            // 하지만 여전히 아래로 발사...
            // 불렛쪽으로 옮기니 해결

            // 충알 발사 시 불꽃이 튀는 듯한 효과
            // 오브젝트를 on off해서 

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
