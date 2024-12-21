using UnityEngine;

public class ParticleSoundController : MonoBehaviour
{
    public ParticleSystem explosionParticle; // 폭발 파티클 시스템
    public VolcanoSoundPlayer soundPlayer;   // VolcanoSoundPlayer 스크립트
    private float lastTime = -1f; // 마지막으로 소리가 재생된 시점 저장
    private float threshold = 0.1f; // 중복 재생 방지 시간 간격

    void Update()
    {
        if (explosionParticle != null)
        {
            float currentTime = explosionParticle.time; // 현재 재생 시간

            // 파티클이 새로 시작되었는지 확인
            if (currentTime < lastTime && explosionParticle.isPlaying)
            {
                PlaySound(); // 소리 재생
            }

            lastTime = currentTime; // 마지막 시간 업데이트
        }
    }

    private void PlaySound()
    {
        if (soundPlayer != null)
        {
            soundPlayer.PlayRandomExplosionSound();
            Debug.Log("Explosion sound played with particle effect.");
        }
        else
        {
            Debug.LogError("Sound player is not assigned!");
        }
    }
}
