using UnityEngine;

public class UIButtonHideHandler : MonoBehaviour
{
    public GameObject objectToHide; // 숨길 오브젝트

    // UI 버튼에서 호출할 함수
    public void HideObjectAndCursor()
    {
        // 지정된 오브젝트 숨기기
        if (objectToHide != null)
        {
            objectToHide.SetActive(false); // 오브젝트 비활성화
        }

        // 마우스 포인터 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 마우스 락
        Cursor.visible = false; // 마우스 포인터 숨기기

        Debug.Log("오브젝트와 마우스 포인터를 숨겼습니다.");
    }
}
