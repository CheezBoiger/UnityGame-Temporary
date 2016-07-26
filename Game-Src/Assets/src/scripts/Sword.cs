using UnityEngine;
using System.Collections;
using System;

namespace GameProject {
	public class Sword : Item {
			bool done = false;
		// Use this for initialization
		public override void Start() {
		}

		// Update is called once per frame
		public override void Update() {
			if (Input.GetKeyDown(KeyCode.Y)) {
				CameraFixed c = Camera.main.GetComponent<CameraFixed>();
				c.setNewTransform(transform);
				c.StartTransition(2.5f);
				done = true;
			}
		}
	}
}
