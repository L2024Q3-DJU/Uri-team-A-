using UnityEngine;

public class ParticleSoundController : MonoBehaviour
{
    public ParticleSystem explosionParticle; // ���� ��ƼŬ �ý���
    public VolcanoSoundPlayer soundPlayer;   // VolcanoSoundPlayer ��ũ��Ʈ
    private float lastTime = -1f; // ���������� �Ҹ��� ����� ���� ����
    private float threshold = 0.1f; // �ߺ� ��� ���� �ð� ����

    void Update()
    {
        if (explosionParticle != null)
        {
            float currentTime = explosionParticle.time; // ���� ��� �ð�

            // ��ƼŬ�� ���� ���۵Ǿ����� Ȯ��
            if (currentTime < lastTime && explosionParticle.isPlaying)
            {
                PlaySound(); // �Ҹ� ���
            }

            lastTime = currentTime; // ������ �ð� ������Ʈ
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
