using UnityEngine;
using System.Collections;
using System;
using GameProject.Resources;

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

			// Listen to key press to pick up item
			if (Input.GetKeyDown(KeyCode.E)) {
				if (WalkedOverItem) {
					Destroy(WalkedOverItem.gameObject);
					// TODO: Equipt the item to the player
				}
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
			if (coll.gameObject.tag.CompareTo(GameTags.Enemy) == 0) {
				Debug.Log("Enemy is touching me!!");
			}
		}
	}
} // GameProject namespace