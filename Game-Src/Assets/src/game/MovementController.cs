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
		public float sprintRate = 0.1f;
		public bool isAttacking = false;
		public Camera cam = null;

		public float turnRate = 15.0f;
		public float sprintTurnRate = 12f;

		private float attackFocusSlow;
		private float maxSprintRate;
		private float maxMovementRate;
		private float maxTurnRate;
		private float maxSprintRotationRate;
		private float maxAttackFocusSlow;

		Quaternion targetRotation;
		/// <summary>
		/// The position of the movement at a certain direction.
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
		public virtual void Start() {
			maxMovementRate = movementRate;
			maxSprintRate = sprintRate;
			maxTurnRate = turnRate;
			maxSprintRotationRate = sprintTurnRate;
			maxAttackFocusSlow = movementRate * 0.8f;
			attackFocusSlow = maxAttackFocusSlow;
		}

		/// <summary>
		/// Rotates the Target GameObject to the direction of travel, relying on normalization, along with moving 
		/// the Target in several places by the moveVector.
		/// </summary>
		// Update is called once per frame
		public virtual void Update() {
			float rotationRate = turnRate;
			float moveRate = movementRate;
			lookVector = transform.forward;
			moveVector = this.transform.position;

			Debug.Log("Object is moving!");

			if(Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) {
				Debug.Log("Sprinting!");
				rotationRate += sprintTurnRate;
				moveRate += sprintRate;
			}

			if(Input.GetKey(KeyCode.Mouse1)) {
				Debug.Log("Focusing!");
				moveRate -= attackFocusSlow;
				Debug.LogFormat("moveRate: {0}", moveRate);
				zoomInCamera();
				isAttacking = true;
			} else {
				zoomOutCamera();
				isAttacking = false;
			}

			if(Input.GetKey(KeyCode.W)) {
				lookVector.x += 1.0f;
				lookVector.z += 1.0f;

				moveVector.z += moveRate;
				moveVector.x += moveRate;
			}
			
			if(Input.GetKey(KeyCode.S)) {
				lookVector.x -= 1.0f;
				lookVector.z -= 1.0f;

				moveVector.z -= moveRate;
				moveVector.x -= moveRate;
			}

			if(Input.GetKey(KeyCode.A)) {
				lookVector.x -= 1.0f;
				lookVector.z += 1.0f;

				moveVector.x -= moveRate;
				moveVector.z += moveRate;
			}

			if(Input.GetKey(KeyCode.D)) {
				lookVector.x += 1.0f;
				lookVector.z -= 1.0f;

				moveVector.x += moveRate;
				moveVector.z -= moveRate;
			}

			transform.position = moveVector;

			if(!isAttacking) {
				targetRotation = Quaternion.LookRotation(lookVector);
			} else {
				Vector3 mousPos = Input.mousePosition;
				mousPos = Camera.main.ScreenToWorldPoint(mousPos);
				mousPos.y = 0f;

				Debug.LogFormat("mouspos x: {0} y: {0} z: {0}", mousPos.x, mousPos.y, mousPos.z);
				targetRotation = Quaternion.LookRotation(mousPos);
			}

			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnRate);
			//Debug.LogFormat("Forward Vector x: {0} y: {0} z: {0}", lookVector.x, lookVector.y, lookVector.z);
		}

		public void appendMovementRate(float rate) {
			movementRate += rate;
		}

		public void reduceMovementRate(float percent) {
			movementRate = movementRate * percent;
		}

		public void resetMovementRate() {
			movementRate = maxMovementRate;
		}

		private void zoomInCamera() {
			if (cam) {
				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 3f, Time.deltaTime);
			}
		}

		private void zoomOutCamera() {
			if (cam) {
				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5f, Time.deltaTime);
			}
		}
	}
}
