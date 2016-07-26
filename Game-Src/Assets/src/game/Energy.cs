using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Energy ADT used to handle methods of modifying, reducing, and keeping track of the 
	/// Object's health.
	/// </summary>
	public class Energy : MonoBehaviour {
		/// <summary>
		/// Base Energy of any Actor, or object.
		/// </summary>
		public float baseEnergy;
		/// <summary>
		/// Current energy that this Actor, or object, has.
		/// </summary>
		private float currentEnergy;
		/// <summary>
		/// The maximum energy that this Actor, or Object, has.
		/// </summary>
		private float maxEnergy;
		/// <summary>
		/// 
		/// </summary>
		private float currentMaxEnergyStatus;

		private float energyRegenRate;
		private float maxEnergyRegenRate;

		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		void Update() {

		}
	}
}