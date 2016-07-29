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
		public float currentEnergy;
		/// <summary>
		/// The maximum energy that this Actor, or Object, has.
		/// </summary>
		private float maxEnergy;
		/// <summary>
		/// 
		/// </summary>
		private float maxEnergyStatus;
		/// <summary>
		/// 
		/// </summary>
		public float energyRegenRate;
		/// <summary>
		/// 
		/// </summary>
		private float maxEnergyRegenRate;
		/// <summary>
		/// 
		/// </summary>
		private float maxEnergyRegenRateStatus;
		/// <summary>
		/// 
		/// </summary>
		private bool energyDepleted;
		/// <summary>
		/// 
		/// </summary>
		private bool usedEnergy;

		
		// Use this for initialization
		void Start() {
			maxEnergy = baseEnergy;
			maxEnergyStatus = maxEnergy;

			if (currentEnergy > maxEnergy || currentEnergy < 0) {
				currentEnergy = maxEnergy;
			}

			if (maxEnergy > 0) {
				energyDepleted = false;
			}

			maxEnergyRegenRate = energyRegenRate;
			maxEnergyRegenRateStatus = maxEnergyRegenRate;

			usedEnergy = false;
		}

		
		// Update is called once per frame
		void Update() {
			if (((currentEnergy < maxEnergyStatus) ||
				(energyRegenRate < 0) && !energyDepleted)) {
				currentEnergy += Time.deltaTime * energyRegenRate;
			}

			if (currentEnergy > maxEnergyStatus && !energyDepleted) {
				currentEnergy = maxEnergyStatus;
			}

			if (usedEnergy) {

			} else {

			}
		}


		public float GetCurrentEnergy() {
			return currentEnergy;
		}


		public float GetMaxEnergyStatus() {
			return maxEnergyStatus;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="energy"></param>
		private void appendEnergy(float energy) {
			currentEnergy += energy;

			if (currentEnergy <= 0) {
				currentEnergy = 0;
				energyDepleted = true;
			} else {
				energyDepleted = false;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="energy"></param>
		public void AppendMaxEnergy(float energy) {
			maxEnergy += energy;
			maxEnergyStatus = maxEnergy;

			if (maxEnergy < 0) {
				maxEnergy = 0;
				maxEnergyStatus = 0;
				energyDepleted = true;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="percentage"></param>
		public void AppendMaxEnergyByPercentage(float percentage) {
			maxEnergyStatus = maxEnergy * percentage;
			// Fix current energy relative to max energy.
			currentEnergy = currentEnergy * percentage;
		}


		/// <summary>
		/// 
		/// </summary>
		public void ResetMaxEnergy() {
			float factor = maxEnergy / maxEnergyStatus;

			maxEnergyStatus = maxEnergy;
			currentEnergy *= factor;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="regen"></param>
		public void AppendEnergyRegenRate(float regen) {
			energyRegenRate += regen;
		}


		/// <summary>
		/// 
		/// </summary>
		public void ResetEnergyRegen() {
			energyRegenRate = maxEnergyRegenRate;
		}

		public void ResetEnergy() {
			ResetMaxEnergy();
			ResetEnergyRegen();
			energyDepleted = false;
			currentEnergy = maxEnergy;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="energy"></param>
		/// <returns></returns>
		public bool UseEnergy(float energy) {
			bool tookEnergy = false;

			if (energy <= currentEnergy) {
				currentEnergy -= energy;
				tookEnergy = true;
			}

			return tookEnergy;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="energy"></param>
		public void ReceiveEnergy(float energy) {
			appendEnergy(energy);
		}
	}
}