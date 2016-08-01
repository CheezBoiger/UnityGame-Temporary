using UnityEngine;
using System.Collections;
using System;

namespace GameProject {
	/*
	 * Player test, only for experimenting, not Official.
	 */
	public sealed class Player : Actor {
		public override void Start() {
			health = GetComponent<Health>();
			energy = GetComponent<Energy>();
			followingCamera = GetComponent<CameraFixed>();
			movement = GetComponent<MovementController>();

			GameObject g = (GameObject)Instantiate(UnityEngine.Resources.Load("UIBar"));
			if (!g) {
				Debug.Log("NOPE DIDNT WORK");
			}

			UIBarStatus s = g.GetComponent<UIBarStatus>();
			s.target = this.transform;
		}

		// Update is called once per frame
		public override void Update () {
			Debug.Log("Object is moving!");
			Vector3 pos = this.transform.position;

			if (Input.GetKeyDown(KeyCode.K)) {
				CameraFixed c = Camera.main.GetComponent<CameraFixed>();
				c.SetNewTransform(transform);
				c.StartTransition(2.5f);
				c.SetZoomOutRate(6.6f);
				c.SetToShakeCamera(1f, 1f, 1f);
				//health.AppendMaxHealthByPercentage(2.5f);
				health.ReceiveDamage(1500.0f);
			}

			// Listen to key press to pick up item
			if (Input.GetKeyDown(KeyCode.E)) {
				health.ResetMaxHealth();
				if (WalkedOverItem) {
					Destroy(WalkedOverItem.gameObject);
					// TODO: Equipt the item to the player
				}
			}

			if (Input.GetKeyDown(KeyCode.H)) {
				health.Revive();
			}

			// Listen to key press to throw item
			if (Input.GetKeyDown(KeyCode.Space)) {
				// TODO: Get the item form the bag
				var item = new GameObject();
				var thrownItem = Instantiate(item, transform.position, Quaternion.identity) as Transform;
	
				thrownItem.name = item.name;
				thrownItem.Translate(0, 0, 2f);
				// Delete the item from the bag
			}
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
		}
	}
} // GameProject namespace