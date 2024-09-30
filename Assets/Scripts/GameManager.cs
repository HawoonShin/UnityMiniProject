using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임 클리어와 오버 같은 상태로 취급
    public enum GameState { Ready, Running, GameOver }

    [SerializeField] GameState curState;

    // 게임오버 확인할 벽
    [SerializeField] GameObject wall;
    // 클리어 확인할 몬스터
    [SerializeField] GameObject monster;

    private void Start()
    {
        // 시작 씬 로드
        // 게임 상태 ready
        curState = GameState.Ready;
        //  SceneManager.LoadScene("StartScene");
    }

    private void Update()
    {
        // 아무키나 입력하면 
        if (curState == GameState.Ready
            && Input.anyKeyDown)
        {
            // 게임 스타트
            GameStart();
        }

        // (임시) 벽이 사라질 경우
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
            // 게임 오버상태
            // 게임 오버 씬 불러오기
            // 이후 게임 시작 으로 변경
        }

    }

    public void GameStart()
    {
        curState = GameState.Running;

        // 메인 씬 불러오기
        // SceneManager.LoadScene("Main2DScene");
    }

    public void GameOver()
    {
        curState = GameState.GameOver;
        // 게임오버 화면 불러오기
        SceneManager.LoadScene("GameOverScene");
    }

    public void GameClear()
    {
        curState = GameState.GameOver;
        // 게임 오버 화면 불러오기
        SceneManager.LoadScene("ClearScene");
     
    }

    public void GameRestart()
    {
        curState = GameState.Ready;

        // SceneManager.LoadScene("Main2DScene");
        // 시작 화면 불러오기
        // SceneManager.LoadScene("StartScene");
    }
}
