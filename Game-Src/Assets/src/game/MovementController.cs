using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Movement is a Free Moving Application Script, which allows ActiveObjects to 
	/// be moveable by control. We can modify the movement speed by means of manipulation
	/// from Items, but player would need to do this.
	/// </summary>
	public class MovementController : Movement {

		private float duration = 1f;
		public float increasing = 0.001f;
		private float decreaseFactor = 1f;
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
		public override void Start() {
			c = cam.GetComponent<CameraFixed>();
			maxMovementRate = movementRate;
			maxSprintRate = sprintRate;
			maxTurnRate = turnRate;
			maxSprintRotationRate = sprintTurnRate;
			maxFocusSlow = movementRate * 0.8f;
			focusSlow = maxFocusSlow;
		}

		#region Update Algorithm
		/// <summary>
		/// Rotates the Target GameObject to the direction of travel, relying on normalization, along with moving 
		/// the Target in several places by the moveVector.
		/// </summary>
		// Update is called once per frame
		public override void Update() {
			float rotationRate = turnRate;
			float moveRate = movementRate;
			lookVector = transform.forward;
			moveVector = this.transform.position;

			if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) {
				rotationRate += sprintTurnRate;
				moveRate += sprintRate;
			}

			if (Input.GetKey(KeyCode.Mouse1)) {
				moveRate -= focusSlow;
				Debug.LogFormat("moveRate: {0}", moveRate);
				if (c) {
					c.SetToShakeCamera(duration, increasing, decreaseFactor);
					increasing += Time.deltaTime * 0.001f;

					if (increasing > 0.1f) {
						increasing = 0.1f;
					}
					c.ZoomCamera(true);
				}
				isFocusing = true;
			} else {
				if (c) {
					c.ZoomCamera(false);
					c.StopCameraShake();
					increasing = 0.001f;
				}
				isFocusing = false;
			}
			
			if (Input.GetKey(KeyCode.W)) {
				lookVector.x += 1.0f;
				lookVector.z += 1.0f;

				moveVector.z += moveRate;
				moveVector.x += moveRate;
			}
			
			if (Input.GetKey(KeyCode.S)) {
				lookVector.x -= 1.0f;
				lookVector.z -= 1.0f;

				moveVector.z -= moveRate;
				moveVector.x -= moveRate;
			}

			if (Input.GetKey(KeyCode.A)) {
				lookVector.x -= 1.0f;
				lookVector.z += 1.0f;

				moveVector.x -= moveRate;
				moveVector.z += moveRate;
			}

			if (Input.GetKey(KeyCode.D)) {
				lookVector.x += 1.0f;
				lookVector.z -= 1.0f;

				moveVector.x += moveRate;
				moveVector.z -= moveRate;
			}
			
			transform.position = moveVector;

			if (isFocusing && cam) {
				Plane plane = new Plane(Vector3.up, transform.position);
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);

				Debug.DrawLine(ray.origin, ray.GetPoint(12f), Color.blue, 30f);
				float hitDist = 0f;
				
				if (plane.Raycast(ray, out hitDist)) {
					Vector3 targetPoint = ray.GetPoint(hitDist);
					Debug.DrawLine(transform.position, targetPoint, Color.yellow, 30f, false);
					targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				}
			} else {
				Debug.Log("IM STILL FUCKING ROTATING.");
				targetRotation = Quaternion.LookRotation(lookVector);
			}

			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnRate);
			//Debug.LogFormat("Forward Vector x: {0} y: {0} z: {0}", lookVector.x, lookVector.y, lookVector.z);
		}
		#endregion
	}
}
