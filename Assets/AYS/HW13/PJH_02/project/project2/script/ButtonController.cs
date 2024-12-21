using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Animator doorAnimator1; // door1의 Animator
    public Animator doorAnimator2; // door2의 Animator
    private int doorState = 0;     // 문 상태 (0: 닫힘, 1: 열림)

    private void OnMouseDown()
    {
        if (doorState == 0)
        {
            OpenDoors(); // 문 열기
        }
        else
        {
            CloseDoors(); // 문 닫기
        }
    }

    void OpenDoors()
    {
        doorState = 1; // 상태를 열림(1)으로 설정
        doorAnimator1.SetInteger("int", doorState); // door1 애니메이터에 상태 전달
        doorAnimator2.SetInteger("int", doorState); // door2 애니메이터에 상태 전달
    }

    void CloseDoors()
    {
        doorState = 0; // 상태를 닫힘(0)으로 설정
        doorAnimator1.SetInteger("int", doorState); // door1 애니메이터에 상태 전달
        doorAnimator2.SetInteger("int", doorState); // door2 애니메이터에 상태 전달
    }
}
