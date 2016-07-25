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
		/// Set the transition duration, for smooth movement. The higher the number, the slower the transition.
		/// </summary>
		public float transitionDuration = 2.5f;
		/// <summary>
		/// Timer for the transition to start.
		/// </summary>
		private float transitionTimer;
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
		/// <summary>
		/// Gives the zoom out rate of the camera, when needed.
		/// </summary>
		private float zoomOutRate;
		/// <summary>
		/// Gives the zoom in rate of the camera, when needed.
		/// </summary>
		private float zoomInRate;
		/// <summary>
		/// Determines if the transform is being zoomed in by the Camera.
		/// </summary>
		private bool isZoomedIn;

		/// <summary>
		/// 
		/// </summary>
		private Camera cam;

		private float shakeDuration;
		private float shakeAmount = 1f;
		private float decreaseFactor = 1.0f;

		private Vector3 originalPos;
		private bool isTransitioning = false;

		void Start() { 
			// Calculate the x, y, and z position from the Transform we are following.
			xPos = distance * 0.70710678f;
			zPos = xPos;
			yPos = distance * 0.57735f;
			isZoomedIn = false;
			zoomOutRate = 1f;
			zoomInRate = 1f;
			cam = GetComponent<Camera>();
			SetToShakeCamera(1, 0.1f, 0.9f);
		}

		// Update is called once per frame
		void LateUpdate () {
			if(target) {
				if (!isTransitioning) {
					transform.position = new Vector3(target.position.x - xPos, 
						target.position.y + yPos, 
						target.position.z - zPos);

				} else {
					transition();
				}

				if (isZoomedIn) {
					zoomInCamera(zoomInRate);
				} else {
					zoomOutCamera(zoomOutRate);
				}

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
		/// <summary>
		/// Transitions the camera.
		/// </summary>
		private void transition() {
			if (transitionTimer < 1 && target) {
				Vector3 startPos = transform.position;
				transitionTimer += Time.deltaTime * (Time.timeScale / transitionDuration);

				transform.position = Vector3.Lerp(startPos, 
					new Vector3(target.position.x - xPos, target.position.y + yPos, target.position.z - zPos), 
					transitionTimer);
			} else {
				transitionTimer = 1f;
				transform.position = originalPos;
				isTransitioning = false;
			}
		}

		/// <summary>
		/// Start the transition, will have camera move to the next transform, smoothly.
		/// </summary>
		/// <param name="duration"></param>
		public void StartTransition(float duration) {
			transitionDuration = duration;
			transitionTimer = 0f;
			isTransitioning = true;
		}

		/// <summary>
		/// Set the new transform, then call <see cref="StartTransition(float duration)"/> to begin transition.
		/// </summary>
		/// <param name="newTransform"></param>
		public void SetNewTransform(Transform newTransform) {
			target = newTransform;
		}
		
		
		public void SetZoomInRate(float rate) {
			zoomInRate = rate;
		}

		public void SetZoomOutRate(float rate) {
			zoomOutRate = rate;
		}

		/// <summary>
		/// 
		/// </summary>
		private void zoomInCamera(float rate = 1f) {
			if (cam) {
				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 
					3f, 
					Time.deltaTime * rate);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void zoomOutCamera(float rate = 1f) {
			if (cam) {
				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 
					5f, 
					Time.deltaTime * rate);
			}
		}

		/// <summary>
		/// Zoom the camera. Use this function to start zooming in, update will do all the work.
		/// </summary>
		/// <param name="zoom"></param>
		public void ZoomCamera(bool zoom) {
			isZoomedIn = zoom;
		}
	}
}
