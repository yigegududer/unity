using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class bb : MonoBehaviour
{/// <summary>
 /// 刚体
 /// </summary>
	private Rigidbody rigidbody;
	public static int tc;
	public Vector3 CurrenTnput { get; private set; }
	public float MaxWalkSpeed = 4f;
	public float maxw = 4f;
	public float max = 8f;
	// Use this for initialization
	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	private void FixedUpdate()
	{
		rigidbody.MovePosition(rigidbody.position + CurrenTnput * MaxWalkSpeed * Time.fixedDeltaTime);
	}
	public void seMo(Vector3 input)
	{
		CurrenTnput = Vector3.ClampMagnitude(input, 1);
	}
	void OnTriggerEnter(Collider other)
	{
		string tag = other.gameObject.tag;
        if (tag=="Untagged")
        {
			max = 2;
			maxw = 2;
		}
	}
	void OnTriggerExit(Collider other)
	{
		max = 8;
		maxw = 4;
	}
}