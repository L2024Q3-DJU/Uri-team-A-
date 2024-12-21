using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSound : MonoBehaviour
{
    public AudioSource audioSource; // 사운드를 재생할 AudioSource

    // 애니메이션 이벤트에서 호출할 메서드
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
