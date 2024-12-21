using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Animator[] doorAnimators; // 두 개의 문에 연결된 애니메이터 배열
    public string openAnimationName = "DoorOpen"; // 문 열림 애니메이션 이름
    public string closeAnimationName = "DoorClose"; // 문 닫힘 애니메이션 이름
    private bool isDoorOpen = false; // 문이 열렸는지 여부를 확인

    void Start()
    {
        if (doorAnimators == null || doorAnimators.Length == 0)
        {
            Debug.LogError("Door Animators are not assigned!");
        }
    }

    void OnMouseDown()
    {
        if (doorAnimators == null || doorAnimators.Length == 0)
            return;

        foreach (Animator doorAnimator in doorAnimators)
        {
            if (doorAnimator == null)
                continue;

            if (isDoorOpen)
            {
                doorAnimator.Play(closeAnimationName);
            }
            else
            {
                doorAnimator.Play(openAnimationName);
            }
        }

        isDoorOpen = !isDoorOpen; // 상태 전환
    }
}
