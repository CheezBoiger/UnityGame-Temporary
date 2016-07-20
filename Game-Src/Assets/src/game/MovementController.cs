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
		private Vector3 directionVector;

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

		/// <summary>
		/// Rotates the Target GameObject to the direction of travel.
		/// </summary>
		// Update is called once per frame
		void Update() {

			directionVector = transform.forward;
			moveVector = this.transform.position;

			Debug.Log("Object is moving!");		

			if(Input.GetKey(KeyCode.W)) {
				directionVector.x += 1.0f;
				directionVector.z += 1.0f;

				moveVector.z += movementRate;
				moveVector.x += movementRate;
			}
			
			if(Input.GetKey(KeyCode.S)) {
				directionVector.x -= 1.0f;
				directionVector.z -= 1.0f;

				moveVector.z -= movementRate;
				moveVector.x -= movementRate;
			}

			if(Input.GetKey(KeyCode.A)) {
				directionVector.x -= 1.0f;
				directionVector.z += 1.0f;

				moveVector.x -= movementRate;
				moveVector.z += movementRate;
			}

			if(Input.GetKey(KeyCode.D)) {
				directionVector.x += 1.0f;
				directionVector.z -= 1.0f;

				moveVector.x += movementRate;
				moveVector.z -= movementRate;
			}

			transform.position = moveVector;

			Quaternion targetRotation = Quaternion.LookRotation(directionVector);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 15.0f);
		}
	}
}
