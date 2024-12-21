using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSound : MonoBehaviour
{
    public AudioSource audioSource; // ���带 ����� AudioSource

    // �ִϸ��̼� �̺�Ʈ���� ȣ���� �޼���
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
