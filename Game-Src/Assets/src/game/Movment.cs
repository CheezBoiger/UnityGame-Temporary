using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Movement is an abstract script, designed for multiple scripting.
	/// </summary>
	public abstract class Movement : MonoBehaviour {
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
		/// Camera that is attached. Ensure that you attach the camera following this 
		/// transform in order for this script to send modifications to it.
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
		protected float focusSlow;
		/// <summary>
		/// Keeps the max sprint rate, to ensure we can reset our modified values.
		/// </summary>
		protected float maxSprintRate;
		/// <summary>
		/// Keeps the max movment rate, to ensure we reset our modified values exactly as original.
		/// </summary>
		protected float maxMovementRate;
		/// <summary>
		/// Keeps the max Turn rate, to ensure we reset our modified values as the original.
		/// </summary>
		protected float maxTurnRate;
		/// <summary>
		/// Keeps the max sprint rotation rate, to ensure we reset our modified values as the original.
		/// </summary>
		protected float maxSprintRotationRate;
		/// <summary>
		/// Kees the max focus slow speed, to ensure we reset our modified values as the original.
		/// </summary>
		protected float maxFocusSlow;
		/// <summary>
		/// The rotation of which the transform needs to reach.
		/// </summary>
		protected Quaternion targetRotation;
		/// <summary>
		/// The position of the movement at a certain direction.
		/// </summary>
		protected Vector3 moveVector;
		/// <summary>
		/// The direction from which the target transform is facing. This is the forward facing vector.
		/// </summary>
		protected Vector3 lookVector;
		/// <summary>
		/// The Fixed Camera
		/// </summary>
		protected CameraFixed c;
		// Use this for initialization
		public abstract void Start();

		// Update is called once per frame
		public abstract void Update();

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