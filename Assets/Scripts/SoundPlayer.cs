using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // 실행시킬 오디오 소스
    [SerializeField] AudioSource gunFX;

    private void Update()
    {
        // 마우스 우클릭시
        if (Input.GetMouseButtonDown(0))
        {
            // 총소리 출력
            gunFX.Play();
        }
    }
}
