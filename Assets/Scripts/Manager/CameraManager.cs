using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class CameraManager : Singleton<CameraManager> {

	private Transform player;

	[HideInInspector]
	public bool startFollow = false;

	public Vector3 initPos;


    void Start () {
		initPos = gameObject.transform.position;
		player = GameObject.FindWithTag ("Player").GetComponent<Transform>();
	}

	void Update () {
		if (startFollow) {
			Vector3 nextPos = new Vector3 (gameObject.transform.position.x, 
				player.position.y + 1.5f, player.position.z);
			gameObject.transform.position = Vector3.Lerp 
				(gameObject.transform.position, nextPos, Time.deltaTime);
		}
	}
		
}
