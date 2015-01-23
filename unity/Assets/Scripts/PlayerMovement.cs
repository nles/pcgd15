﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 3f;
	
	CharacterController controller;
	Animator animator;

	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController>();
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		Camera camera = Camera.main;
		Vector3 cameraForward = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up).normalized;
		Vector3 cameraRight = Vector3.ProjectOnPlane(camera.transform.right, Vector3.up).normalized;
		Vector3 input = cameraForward*Input.GetAxis("Vertical") + cameraRight*Input.GetAxis("Horizontal");
		
		if(Vector3.Angle(transform.forward, input) > 0.1f){
			transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, input, 0.5f, 0f));
		}
		
		controller.Move(input*Time.deltaTime*3f);
		animator.SetFloat("Velocity", controller.velocity.magnitude);
		
		controller.Move(Vector3.down*9.81f*Time.deltaTime);
	}
}