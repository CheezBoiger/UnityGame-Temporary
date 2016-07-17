using UnityEngine;
using System.Collections;
using System;

namespace GameProject {
	/*
	 * Player test, only for experimenting, not Official.
	 */
	public sealed class Player : Actor {
		public override void Start() {
			MovementRate = 10;
		}


		// Update is called once per frame
		public override void Update () {
			Debug.Log("Object is moving!");
			Vector3 pos = this.transform.position;
			pos.x -= 0.05f;
			transform.position = pos;
		}


		public void OnApplicationFocus( bool focusStatus ) {
			Debug.Log("Player focused!!");
		}


		public void OnApplicationPause( bool pauseStatus ) {
			Debug.Log("Player is paused!!");
		}


		public void OnCollisionStay2D(Collision2D coll) {
			Actor enemy = coll.gameObject.GetComponent<Actor>();
			Debug.Log("I am collided!!");
			if (coll.gameObject.tag.CompareTo("Enemy") == 0) {
			  Debug.Log("Enemy is touching me!!");
			}
		}
	}
} // GameProject namespace