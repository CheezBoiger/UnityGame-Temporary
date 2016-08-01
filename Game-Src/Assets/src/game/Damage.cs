using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// 
	/// </summary>
	public class Damage : MonoBehaviour {
		/// <summary>
		/// 
		/// </summary>
		public float baseDamage;
		/// <summary>
		/// 
		/// </summary>
		private float maxDamage;
		/// <summary>
		/// 
		/// </summary>
		private float maxDamageStatus;
		/// <summary>
		/// 
		/// </summary>
		private float currentDamage;
		/// <summary>
		/// 
		/// </summary>
		private DamageType damageType;

		// Use this for initialization
		public virtual void Start() {
			maxDamage = baseDamage;

			currentDamage = maxDamage;
			maxDamageStatus = maxDamage;
		}

		// Update is called once per frame
		public virtual void Update() {

		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public float GetCurrentDamage() {
			return currentDamage;
		}


		public float GetMaxDamange() {
			return maxDamageStatus;
		}

		public void ResetMaxDamage() {
			maxDamageStatus = maxDamage;
		}

		public void ResetAllDamage() {
			ResetMaxDamage();
			currentDamage = maxDamageStatus;
		}
	}
}