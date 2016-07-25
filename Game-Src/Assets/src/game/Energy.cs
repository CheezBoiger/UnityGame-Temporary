using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Energy ADT used to handle methods of modifying, reducing, and keeping track of the 
	/// Object's health.
	/// </summary>
	public class Energy : MonoBehaviour {
		public float baseEnergy;

		private float currentEnergy;
		private float maxEnergy;
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