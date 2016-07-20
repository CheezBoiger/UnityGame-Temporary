using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Movement is a Free Moving Application Script, which allows ActiveObjects to 
	/// be moveable by control. We can modify the movement speed by means of manipulation
	/// from Items, but player would need to do this.
	/// </summary>
	public class MovementController : MonoBehaviour {
		public float movementRate = 0.05f;

		private Vector3 moveVector;

		public float MovementRate {
			get {
				return MovementRate;
			} set {
				movementRate = value;
			}
		}

		// Use this for initialization
		void Start() {
			
		}

		// Update is called once per frame
		void Update() {
			moveVector = this.transform.position;
			Debug.Log("Object is moving!");		

			if(Input.GetKey(KeyCode.W)) {
				moveVector.z += movementRate;
				moveVector.x += movementRate;
			}
			
			if(Input.GetKey(KeyCode.S)) {
				moveVector.z -= movementRate;
				moveVector.x -= movementRate;
			}

			if(Input.GetKey(KeyCode.A)) {
				moveVector.x -= movementRate;
				moveVector.z += movementRate;
			}

			if(Input.GetKey(KeyCode.D)) {
				moveVector.x += movementRate;
				moveVector.z -= movementRate;
			}

			transform.position = moveVector;
		}
	}
}
