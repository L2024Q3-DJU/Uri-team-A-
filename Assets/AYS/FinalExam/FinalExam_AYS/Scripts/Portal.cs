using UnityEngine;
using System.Collections.Generic;

public class Portal : MonoBehaviour
{
    public GameObject miniMap; // �̴ϸ� ������Ʈ
    public List<GameObject> portalObjects; // ��Ż ����Ʈ�� ����� ������Ʈ ����Ʈ
    public MonoBehaviour playerMovementScript; // �÷��̾� ������ ��ũ��Ʈ (FirstPersonController ��)
    public KeyCode toggleKey = KeyCode.F; // �̴ϸ� ��� Ű

    private bool isMiniMapOpen = false; // �̴ϸ� ���¸� ����
    private bool isPlayerInPortalPoint = false; // �÷��̾ PortalPoint �ȿ� �ִ��� ����

    void Start()
    {
        // �ʱ� ����: �̴ϸ� ��Ȱ��ȭ
        miniMap.SetActive(false);

        // ��� ��Ż ������Ʈ�� ��Ȱ��ȭ
        foreach (GameObject obj in portalObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                Debug.Log($"{obj.name} ������Ʈ�� ��Ȱ��ȭ�Ǿ����ϴ�."); // �����
            }
        }

        // �÷��̾� ������ Ȱ��ȭ (�ʱ�ȭ)
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true;
        }

        // �ʱ� ���콺 ���� ����
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // F Ű �Է����� �̴ϸ� ����/�ݱ� (PortalPoint �ȿ� ���� ����)
        if (Input.GetKeyDown(toggleKey) && isPlayerInPortalPoint)
        {
            ToggleMiniMap();
        }
    }

    public void ToggleMiniMap()
    {
        // �̴ϸ� ���� ��ȯ
        isMiniMapOpen = !isMiniMapOpen;
        miniMap.SetActive(isMiniMapOpen);

        // �÷��̾� ������ ����
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = !isMiniMapOpen; // �̴ϸ��� ������ ��Ȱ��ȭ
        }

        // ���콺 ���� ����
        if (isMiniMapOpen)
        {
            Cursor.lockState = CursorLockMode.None; // ���콺 �� ����
            Cursor.visible = true; // ���콺 ������ ���̱�
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // ���콺 �� ����
            Cursor.visible = false; // ���콺 ������ �����
        }

        Debug.Log($"�̴ϸ� ����: {isMiniMapOpen}, �÷��̾� ������ Ȱ��ȭ: {!isMiniMapOpen}");
    }

    private void OnTriggerEnter(Collider other)
    {
        // ��Ż ����Ʈ�� �������� ��
        if (other.CompareTag("PortalPoint"))
        {
            isPlayerInPortalPoint = true; // PortalPoint ������ ����
            ActivatePortalObject();
        }

        // �÷��̾ ��Ż�� �������� ��
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);

            // �ڷ���Ʈ �� PortalPoint ���� �ʱ�ȭ
            isPlayerInPortalPoint = false;

            // �÷��̾� ������ ��ũ��Ʈ �ٽ� Ȱ��ȭ
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = true; // ��� ������ Ȱ��ȭ
            }

            // ���콺 ���� �ʱ�ȭ
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Debug.Log("�÷��̾ �ڷ���Ʈ�� �� �������� Ȱ��ȭ�Ǿ����ϴ�.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ��Ż ����Ʈ�� ����� ��
        if (other.CompareTag("PortalPoint"))
        {
            isPlayerInPortalPoint = false; // PortalPoint ������ ����
            DeactivatePortalObject();
        }
    }

    private void ActivatePortalObject()
    {
        foreach (GameObject obj in portalObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true); // ������Ʈ Ȱ��ȭ
                Debug.Log($"{obj.name} ������Ʈ�� Ȱ��ȭ�Ǿ����ϴ�."); // �����
            }
        }
    }

    private void DeactivatePortalObject()
    {
        foreach (GameObject obj in portalObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false); // ������Ʈ ��Ȱ��ȭ
                Debug.Log($"{obj.name} ������Ʈ�� ��Ȱ��ȭ�Ǿ����ϴ�."); // �����
            }
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        // ���� ��Ż ��ġ�� �÷��̾ �̵�
        player.transform.position = transform.position + Vector3.forward * 2; // ��: ��Ż ��ġ �������� �̵�
        Debug.Log($"{player.name}�� �ڷ���Ʈ�Ǿ����ϴ�: {player.transform.position}");
    }
}
