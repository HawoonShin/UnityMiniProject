using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���� Ŭ����� ���� ���� ���·� ���
    public enum GameState { Ready, Running, GameOver }

    [SerializeField] GameState curState;

    // ���ӿ��� Ȯ���� ��
    [SerializeField] GameObject wall;
    // Ŭ���� Ȯ���� ����
    [SerializeField] GameObject monster;

    private void Start()
    {
        // ���� �� �ε�
        // ���� ���� ready
        curState = GameState.Ready;
        //  SceneManager.LoadScene("StartScene");
    }

    private void Update()
    {
        // �ƹ�Ű�� �Է��ϸ� 
        if (curState == GameState.Ready
            && Input.anyKeyDown)
        {
            // ���� ��ŸƮ
            GameStart();
        }

        // (�ӽ�) ���� ����� ���
        if (curState == GameState.Running)
        {
            if (wall == null)
            {
                GameOver();

            }
            else if (monster == null)
            {
                GameClear();
            }
            // ���� ��������
            // ���� ���� �� �ҷ�����
            // ���� ���� ���� ���� ����
        }

    }

    public void GameStart()
    {
        curState = GameState.Running;

        // ���� �� �ҷ�����
        // SceneManager.LoadScene("Main2DScene");
    }

    public void GameOver()
    {
        curState = GameState.GameOver;
        // ���ӿ��� ȭ�� �ҷ�����
        SceneManager.LoadScene("GameOverScene");
    }

    public void GameClear()
    {
        curState = GameState.GameOver;
        // ���� ���� ȭ�� �ҷ�����
        SceneManager.LoadScene("ClearScene");
     
    }

    public void GameRestart()
    {
        curState = GameState.Ready;

        // SceneManager.LoadScene("Main2DScene");
        // ���� ȭ�� �ҷ�����
        // SceneManager.LoadScene("StartScene");
    }
}
