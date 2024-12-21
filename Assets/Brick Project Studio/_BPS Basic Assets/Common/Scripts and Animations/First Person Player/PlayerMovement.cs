using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;

        public float speed = 5f;
        public float gravity = -15f;

        public float mouseSensitivity = 2f;  // 마우스 회전 감도 (조정 가능)
        public bool lockCursor = true;       // 마우스 커서를 화면 중앙에 고정할지 여부

        public Transform playerCamera;       // 플레이어의 카메라

        Vector3 velocity;
        bool isGrounded;

        float xRotation = 0f; // 카메라의 상하 회전 상태 저장

        void Start()
        {
            // 마우스 커서 잠금 설정
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        void Update()
        {
            MovePlayer();
            RotatePlayer();
        }

        void MovePlayer()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        void RotatePlayer()
        {
            // 마우스 입력 받기 (프레임 독립적으로 계산)
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // 카메라의 상하 회전 제한
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 고개가 너무 꺾이지 않도록 제한

            // 상하 회전 적용 (카메라)
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // 좌우 회전 적용 (플레이어)
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
