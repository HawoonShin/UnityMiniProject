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
    // �¿� ������ ���콺 x�� �Է�
    private float mouseX;


    [SerializeField] Animator animator;
    private static int idleHash = Animator.StringToHash("Idle");
    private static int runHash = Animator.StringToHash("Run");

    private void Update()
    {
        if (Input.anyKey)
        {
            // �̵�
            Move();
        }
        else
        {
            animator.Play(idleHash);
        }

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

        //�ִϸ��̼� ���

        animator.Play(runHash);
    }

    private void LookMouse()
    {
        // ���콺 �Է� y�� �Ǵ�
        mouseY += Input.GetAxis("Mouse Y") * rotateSpeed;

        // ĳ���� �¿� �ü� ����
        mouseX += Input.GetAxis("Mouse X");
        if (mouseX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (mouseX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }

        // �� ȸ���� ���� ���� �̻� ���� �ʵ��� ����
        mouseY = Mathf.Clamp(mouseY, -60f, 40f);

        // ���콺 ��ġ�� ���� �Ӹ� ���� �̵�
        spine.transform.localEulerAngles = new Vector3(0, 0, mouseY);
    }
}
