using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �̵� �ӵ�
    [SerializeField] float moveSpeed;

    // ȸ�� ��ų ����
    [SerializeField] GameObject spine;
    // ȸ�� �ӵ�
    [SerializeField] float rotateSpeed;
    // ���콺 y�� �Է� 
    private float mouseY;

    private void Update()
    {
        // �̵�
        Move();

        // ���콺�� ���� �ü� �̵�
        LookMouse();
    }

    private void Move()
    {
        // �� �� �Է� ( Ⱦ��ũ�� = x �ุ ���)
        float x = Input.GetAxisRaw("Horizontal");

        // ��ֶ�����
        Vector3 moveDir = new Vector3(x, 0, 0);
        moveDir.Normalize();

        // �̵�
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void LookMouse()
    {
        // ���콺 �Է� y�� �Ǵ�
        mouseY += Input.GetAxis("Mouse Y") * rotateSpeed;

        // �� ȸ���� ���� ���� �̻� ���� �ʵ��� ����
        mouseY = Mathf.Clamp(mouseY, -40f, 20f);

        // ���콺 ��ġ�� ���� �Ӹ� ���� �̵�
        spine.transform.localEulerAngles = new Vector3 (0,0, mouseY); 
    }
}
