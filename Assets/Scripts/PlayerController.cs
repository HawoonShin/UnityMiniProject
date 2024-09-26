using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동 속도
    [SerializeField] float moveSpeed;

    // 회전 시킬 파츠
    [SerializeField] GameObject spine;
    // 회전 속도
    [SerializeField] float rotateSpeed;
    // 마우스 y축 입력 
    private float mouseY;

    private void Update()
    {
        // 이동
        Move();

        // 마우스를 따른 시선 이동
        LookMouse();
    }

    private void Move()
    {
        // 좌 우 입력 ( 횡스크롤 = x 축만 사용)
        float x = Input.GetAxisRaw("Horizontal");

        // 노멀라이즈
        Vector3 moveDir = new Vector3(x, 0, 0);
        moveDir.Normalize();

        // 이동
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void LookMouse()
    {
        // 마우스 입력 y축 판단
        mouseY += Input.GetAxis("Mouse Y") * rotateSpeed;

        // 목 회전시 일정 각도 이상 넘지 않도록 제한
        mouseY = Mathf.Clamp(mouseY, -40f, 20f);

        // 마우스 위치에 따라 머리 각도 이동
        spine.transform.localEulerAngles = new Vector3 (0,0, mouseY); 
    }
}
