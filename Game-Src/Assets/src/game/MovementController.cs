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
		public float turnRate = 15.0f;
		/// <summary>
		/// The rate of which the movement at a certain direction.
		/// </summary>
		private Vector3 moveVector;
		/// <summary>
		/// The direction from which the target transform is facing. This is the forward facing vector.
		/// </summary>
		private Vector3 lookVector;

		#region Getters and Setters
		public float MovementRate {
			get {
				return MovementRate;
			} set {
				movementRate = value;
			}
		}
		#endregion
		// Use this for initialization
		void Start() {
			
		}

		/// <summary>
		/// Rotates the Target GameObject to the direction of travel, relying on normalization, along with moving the Target
		/// in several places by the moveVector.
		/// </summary>
		// Update is called once per frame
		void Update() {
			lookVector = transform.forward;
			moveVector = this.transform.position;

			Debug.Log("Object is moving!");		

			if(Input.GetKey(KeyCode.W)) {
				lookVector.x += 1.0f;
				lookVector.z += 1.0f;

				moveVector.z += movementRate;
				moveVector.x += movementRate;
			}
			
			if(Input.GetKey(KeyCode.S)) {
				lookVector.x -= 1.0f;
				lookVector.z -= 1.0f;

				moveVector.z -= movementRate;
				moveVector.x -= movementRate;
			}

			if(Input.GetKey(KeyCode.A)) {
				lookVector.x -= 1.0f;
				lookVector.z += 1.0f;

				moveVector.x -= movementRate;
				moveVector.z += movementRate;
			}

			if(Input.GetKey(KeyCode.D)) {
				lookVector.x += 1.0f;
				lookVector.z -= 1.0f;

				moveVector.x += movementRate;
				moveVector.z -= movementRate;
			}

			transform.position = moveVector;

			Quaternion targetRotation = Quaternion.LookRotation(lookVector);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnRate);
		}
	}
}
