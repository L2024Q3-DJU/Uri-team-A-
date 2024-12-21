using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // 씬 이름 또는 인덱스를 여기에 설정
    public string sceneName;

    // 버튼이 눌렸을 때 실행될 메서드
    public void SwitchScene()
    {
        // SceneManager를 사용해 씬 변경
        SceneManager.LoadScene(sceneName);
    }
}
