using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // �� �̸� �Ǵ� �ε����� ���⿡ ����
    public string sceneName;

    // ��ư�� ������ �� ����� �޼���
    public void SwitchScene()
    {
        // SceneManager�� ����� �� ����
        SceneManager.LoadScene(sceneName);
    }
}
