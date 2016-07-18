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

		void Start() { 
			// Calculate the x, y, and z position from the Transform we are following.
			xPos = distance * 0.70710678f;
			zPos = distance * 0.70710678f;
			yPos = distance * 0.57735f;
		}

		// Update is called once per frame
		void LateUpdate () {
			transform.position = new Vector3(target.position.x - xPos, target.position.y + yPos, target.position.z - zPos);
			//transform.rotation = Quaternion.identity;
			transform.eulerAngles = new Vector3(30, 45, 0);
		}
	}
}
