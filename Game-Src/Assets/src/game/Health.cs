using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Health is an ADT, designed to handle methods of modifying, reducing, and 
	/// keeping track of the Object's health.
	/// </summary>
	public class Health {
		/// <summary>
		/// Base health of any Actor, or object.
		/// </summary>
		public float baseHealth;
		/// <summary>
		/// The current health that the Actor, or object, has.
		/// </summary>
		private float currentHealth;
		/// <summary>
		/// Current max Health of the Actor, or Object.
		/// </summary>
		private float maxHealth;
		/// <summary>
		/// Max Health Status will be the current status of the maximum
		/// health, so as to not tinker with the original max health.
		/// </summary>
		private float maxHealthStatus;
		/// <summary>
		/// Current health regeneration rate (hp per sec).
		/// </summary>
		public float healthRegenRate;
		/// <summary>
		/// Max health regeneration rate, to keep track in case items reduce, or 
		/// increase, the rate.
		/// </summary>
		private float maxHealthRegenRate;
		/// <summary>
		/// 
		/// </summary>
		private float maxHealthRegenRateStatus;
		/// <summary>
		/// Is the Actor, or Object, still alive?
		/// </summary>
		private bool isAlive;

		#region Getters and Setters

		public bool IsAlive {
			get {
				return isAlive;
			} set {
				isAlive = value;
			}
		}

		#endregion

		public void Start() {
			maxHealth = baseHealth;
			currentHealth = maxHealth;
			maxHealthStatus = maxHealth;
		}

		public void Update() {

		}
		/// <summary>
		/// Appends the health. It is dynamic, which means you can either add health, 
		/// or remove some. Checks if the health reaches at or below 0, to which the 
		/// Object is considered, dead.
		/// </summary>
		/// <param name="health"></param>
		public void AppendHealth(float health) {
			currentHealth += health;

			if(currentHealth <= 0) {
				isAlive = false;
			} else {
				isAlive = true;
			}
		}
		/// <summary>
		/// Appends health to max health. This will increase, or decrease, the overall
		/// maximum health of the Object.
		/// </summary>
		/// <param name="health"></param>
		public void AppendMaxHealth(float health) {
			maxHealth += health;
			maxHealthStatus = maxHealth;
		}

		/// <summary>
		/// Reduces maximum health by a certain percentage.
		/// </summary>
		/// <param name="percentage">Percentage used to reduce the max health.</param>
		public void AppendMaxHealthByPercentage(float percentage) {
			maxHealthStatus = maxHealth * percentage;
			// Fix current Health relative to the maxHealth.
			currentHealth = currentHealth * percentage;
		}

		/// <summary>
		/// Resets the maxHealth status to the original. Keep in mind that the 
		/// current health stays relative to the max health.
		/// </summary>
		public void ResetMaxHealth() {
			float factor = maxHealth / maxHealthStatus;

			maxHealthStatus = maxHealth;
			// Fix current Health relative to the maxHealth.
			currentHealth *= factor;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="percentage"></param>
		public void AppendHealthRegenRateByPercentage(float percentage) {
			healthRegenRate = healthRegenRate * percentage;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="regen"></param>
		public void AppendHealthRegenRate(float regen) {
			healthRegenRate += regen;
		}
		/// <summary>
		/// 
		/// </summary>
		public void ResetHealthRegen() {
			healthRegenRate = maxHealthRegenRate;
		}
	}
}
