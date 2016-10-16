using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// RigidWhole is a Object Container ADT, designed to hold all objects associated with
	/// it.
	/// </summary>
	public class RigidWhole : MonoBehaviour {
		/// <summary>
		/// List holding all GameObjects associated with this transform.
		/// </summary>
		private ArrayList GameObjectList;
		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		void Update() {

		}

		/// <summary>
		/// Add a GameObject to this RigidWhole.
		/// </summary>
		/// <param name="obj"></param>
		public void AddGameObjectToList(GameObject obj) {
			GameObjectList.Add(obj);
		}

		private void stickPosition() {

		}
	}
}