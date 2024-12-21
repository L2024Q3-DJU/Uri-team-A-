using UnityEngine;

public class UIButtonHideHandler : MonoBehaviour
{
    public GameObject objectToHide; // ���� ������Ʈ

    // UI ��ư���� ȣ���� �Լ�
    public void HideObjectAndCursor()
    {
        // ������ ������Ʈ �����
        if (objectToHide != null)
        {
            objectToHide.SetActive(false); // ������Ʈ ��Ȱ��ȭ
        }

        // ���콺 ������ �����
        Cursor.lockState = CursorLockMode.Locked; // ���콺 ��
        Cursor.visible = false; // ���콺 ������ �����

        Debug.Log("������Ʈ�� ���콺 �����͸� ������ϴ�.");
    }
}
