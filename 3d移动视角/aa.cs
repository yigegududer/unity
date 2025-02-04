using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class aa : MonoBehaviour {
	private bb characterMovement;
	[SerializeField]
	private cc photographer;
	[SerializeField] private Transform followingfTarget;
	// Use this for initialization
	private  void Amake()
    {
		characterMovement = GetComponent<bb>();
		photographer.InitCamera(followingfTarget);
    }
	void Start () {
		Amake();
	}
	// Update is called once per frame
	void FixedUpdate() {
		UpdateMovementInput();
	}
	[SerializeField] private float rotationSpeed = 5f;  // 添加这一行来声明 rotationSpeed 变量

    private void UpdateMovementInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // 计算相机的旋转方向
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // 计算移动方向向量
        Vector3 moveDirection = cameraForward * verticalInput + cameraRight * horizontalInput;

        // 如果移动方向不等于零向量
        if (moveDirection.magnitude > 0)
        {
            // 计算目标旋转角度
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            // 平滑地旋转角色到目标旋转角度
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // 将移动方向向量传递给 characterMovement.seMo() 方法
        characterMovement.seMo(moveDirection);
    }
}
 