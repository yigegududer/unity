using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cc : MonoBehaviour {
	public float pitch { get; private set; }
	public float Yaw { get; private set; }
	private float mouseS = 3;
	public float cameraR = 80;
	private float cameraYspeed = 3;
	private Transform _target;
	private Transform _camera;
	[SerializeField] private AnimationCurve animationCurve;
	private void Amage()
    {
		_camera = transform.GetChild(0);
    }
	// Use this for initialization
	void Start () {
		Amage();
		Cursor.visible = false; // 隐藏鼠标
	}
	public void InitCamera(Transform target)
    {
		_target = target;
		transform.position = target.position;
    }
	
	// Update is called once per frame
	void Update () {
		a1();
		a2();
		a3();
		shubiao();
	}
	private void a1()
    {
		Yaw += Input.GetAxis("Mouse X") * mouseS;
		Yaw += Input.GetAxis("Camera Rate X") * cameraR * Time.deltaTime;
		pitch += Input.GetAxis("Mouse Y") * mouseS;
		pitch += Input.GetAxis("Camera Rate Y") * cameraR * Time.deltaTime;
		pitch = Mathf.Clamp(pitch, -90, 90);
		transform.rotation = Quaternion.Euler(pitch, Yaw, 0);

	}
	private void a2()
    {
		Vector3 position = _target.position;
		float newY = Mathf.Lerp(transform.position.y,position.y, Time.deltaTime * cameraYspeed);
		transform.position = new Vector3(position.x, newY,position.z);
		
    }
	private void a3()
    {
		_camera.localPosition=new Vector3(0,0, animationCurve.Evaluate(pitch)*-1);
    }
	public GameObject[] uiObject; // 引用UI对象
	bool subiao=false;//鼠标
	/// <summary>
	/// 鼠标
	/// </summary>
	public void shubiao()
	{
		bool anyUIActive = false; // 是否有任何一个 UI 激活

		foreach (GameObject uiObj in uiObject)
		{
			if (uiObj.activeSelf)
			{
				anyUIActive = true;
				break;
			}
		}
		if (Input.GetKey(KeyCode.LeftAlt))
		{
			Cursor.visible = true; // 显示鼠标
			Cursor.lockState = CursorLockMode.None; // 解锁鼠标
			mouseS = 0;
			subiao = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftAlt))
		{
			subiao = false;
		}
		if(!anyUIActive&& !subiao)
        {
			Cursor.visible = false; // 隐藏鼠标
			Cursor.lockState = CursorLockMode.Locked; // 锁定鼠标在屏幕中心
			mouseS = 3;
		}
	}
}
