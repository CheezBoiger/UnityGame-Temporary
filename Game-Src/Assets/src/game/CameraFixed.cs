using UnityEngine;
using System.Collections;

namespace GameProject { 
	/// <summary>
	/// CameraFixed is a script to position the camera in a Top-down, isometric view. 
	/// There is some mathematics involved, yet some of it was sin and cos mathematics involved in 
	/// angling the camera depending on the distance provided. Be sure to make to un-parent the camera
	/// from an object, before attaching this script.
	/// </summary>
	public class CameraFixed : MonoBehaviour {
		/// <summary>
		/// The target is a Tranform that the camera may follow.
		/// </summary>
		public Transform target;
		/// <summary>
		/// The distance from the Transform.
		/// </summary>
		public float distance = 10.0f;
		/// <summary>
		/// The xPosition offset from the transform.
		/// </summary>
		private float xPos;
		/// <summary>
		/// The y position offset from the transform.
		/// </summary>
		private float yPos;
		/// <summary>
		/// The z position offset from the transform.
		/// </summary>
		private float zPos;

		private float shakeDuration;
		private float shakeAmount = 1f;
		private float decreaseFactor = 1.0f;

		private Vector3 originalPos;

		void Start() { 
			// Calculate the x, y, and z position from the Transform we are following.
			xPos = distance * 0.70710678f;
			zPos = xPos;
			yPos = distance * 0.57735f;
			SetToShakeCamera(1, 0.5f, 0.3f);
		}

		// Update is called once per frame
		void LateUpdate () {
			if(target) {
				transform.position = new Vector3(target.position.x - xPos,target.position.y + yPos,target.position.z - zPos);
				//transform.rotation = Quaternion.identity;
				originalPos = transform.position;
				shakeCamera();
				transform.eulerAngles = new Vector3(30,45,0);
			}
		}

		/// <summary>
		/// Sets up to shake the camera.
		/// </summary>
		/// <param name="duration"></param>
		/// <param name="amount"></param>
		/// <param name="factor"></param>
		public void SetToShakeCamera(float duration = 0f, float amount = 1.0f, float factor = 1.0f) {
			shakeDuration = duration;
			shakeAmount = amount;
			decreaseFactor = factor;
		}

		/// <summary>
		/// Perform camera shake.
		/// </summary>
		private void shakeCamera() {
			if(shakeDuration > 0) {
				Debug.Log("I am shaking!!");
				transform.position = transform.position + Random.insideUnitSphere * shakeAmount;
				shakeDuration -= Time.deltaTime * decreaseFactor;
			} else {
				shakeDuration = 0f;
				transform.position = originalPos;
			}
		}
	}
}
