using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Health is an ADT, designed to handle methods of modifying, reducing, and 
	/// keeping track of the Object's health.
	/// </summary>
	public class Health : MonoBehaviour {
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

		public Health() {
		}

		public void Start() {
		}

		public void Update() {
		}
		/// <summary>
		/// Appends the health. It is dynamic, which means you can either add health, 
		/// or remove some. Checks if the health reaches at or below 0, to which the 
		/// Object is considered, dead.
		/// </summary>
		/// <param name="health"></param>
		public void appendHealth(float health) {
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
		public void appendMaxHealth(float health) {
			maxHealth += health;
			maxHealthStatus = maxHealth;
		}

		/// <summary>
		/// Reduces maximum health by a certain percentage.
		/// </summary>
		/// <param name="percentage">Percentage used to reduce the max health.</param>
		public void reduceMaxHealth(float percentage) {
			maxHealthStatus = maxHealth * percentage;
		}

		/// <summary>
		/// Resets the maxHealth status to the original.
		/// </summary>
		public void resetMaxHealth() {
			maxHealthStatus = maxHealth;
		}
	}
}
