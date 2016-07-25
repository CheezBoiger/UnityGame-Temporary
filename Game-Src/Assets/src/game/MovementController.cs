using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Movement is a Free Moving Application Script, which allows ActiveObjects to 
	/// be moveable by control. We can modify the movement speed by means of manipulation
	/// from Items, but player would need to do this.
	/// </summary>
	public class MovementController : MonoBehaviour {
		/// <summary>
		/// Movement rate, the speed of the transform that is moving.
		/// </summary>
		public float movementRate = 0.05f;
		/// <summary>
		/// The sprint speed boost, which is appended to <see cref="movementRate"/>.
		/// </summary>
		public float sprintRate = 0.1f;
		/// <summary>
		/// Check if the transform is focusing, which will cause it to slow down.
		/// </summary>
		public bool isFocusing = false;
		/// <summary>
		/// Camera that is attached.
		/// </summary>
		public Camera cam = null;
		/// <summary>
		/// The rate, or how fast, at which the transform rotates.
		/// </summary>
		public float turnRate = 15.0f;
		/// <summary>
		/// How fast the transform rotates, which is appened to turnRate.
		/// </summary>
		public float sprintTurnRate = 12f;
		/// <summary>
		/// When transform <see cref="isFocusing"/>, focusSlow is the rate at which the transform
		/// slows down, which is appended to <see cref="movementSlow"/>.
		/// </summary>
		private float focusSlow;
		/// <summary>
		/// Keeps the max sprint rate, to ensure we can reset our modified values.
		/// </summary>
		private float maxSprintRate;
		/// <summary>
		/// Keeps the max movment rate, to ensure we reset our modified values exactly as original.
		/// </summary>
		private float maxMovementRate;
		/// <summary>
		/// Keeps the max Turn rate, to ensure we reset our modified values as the original.
		/// </summary>
		private float maxTurnRate;
		/// <summary>
		/// Keeps the max sprint rotation rate, to ensure we reset our modified values as the original.
		/// </summary>
		private float maxSprintRotationRate;
		/// <summary>
		/// Kees the max focus slow speed, to ensure we reset our modified values as the original.
		/// </summary>
		private float maxFocusSlow;
		/// <summary>
		/// The rotation of which the transform needs to reach.
		/// </summary>
		Quaternion targetRotation;
		/// <summary>
		/// The position of the movement at a certain direction.
		/// </summary>
		private Vector3 moveVector;
		/// <summary>
		/// The direction from which the target transform is facing. This is the forward facing vector.
		/// </summary>
		private Vector3 lookVector;

		private CameraFixed c;

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
			c = Camera.main.GetComponent<CameraFixed>();
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
		public virtual void Update() {
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
				c.ZoomCamera(true);
				isFocusing = true;
			} else {
				c.ZoomCamera(false);
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

			if (isFocusing) {
				Plane plane = new Plane(Vector3.up, transform.position);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rate"></param>
		public void AppendMovementRate(float rate) {
			movementRate += rate;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="percent"></param>
		public void ReduceMovementRate(float percent) {
			movementRate = movementRate * percent;
		}

		/// <summary>
		/// 
		/// </summary>
		public void resetMovementRate() {
			movementRate = maxMovementRate;
		}
	}
}
