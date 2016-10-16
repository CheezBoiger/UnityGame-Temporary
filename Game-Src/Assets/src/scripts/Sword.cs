using UnityEngine;
using System.Collections;
using System;

namespace GameProject {
	public class Sword : Item {
		public float damagebonus = 10000f;
		private Actor owner;
		// Use this for initialization
		public override void Start() {
			owner = GetComponent<Actor>();
		}

		// Update is called once per frame
		public override void Update() {
			if (Input.GetKeyDown(KeyCode.Y)) {
				CameraFixed c = Camera.main.GetComponent<CameraFixed>();
				c.SetNewTransform(transform);
				c.StartTransition(2.5f);
			}
		}

		public override void injectEffects(ActionObject obj) {
			
		}

		public override void obtainCommonEffect(ActionObject obj) {
			
		}

		public void SetOwner(Actor actor) {
			owner = actor;
		}
	}
}
