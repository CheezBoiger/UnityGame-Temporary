using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameProject {


	/// <summary>
	/// 
	/// </summary>
	public class DamageContainer : MonoBehaviour {
		/// <summary>
		/// Damage that actor does on his/her/its own!
		/// </summary>
		public Damage actorDamage;
		/// <summary>
		/// Weapon damage will specify the damage type!
		/// This will prevent having to make the player a damage dealer as well.
		/// </summary>
		public Damage weaponDamage;
		
		/// <summary>
		/// Weapons and armor can add damage to this. Temporary modifiers can also 
		/// be added.
		/// </summary>
		private List<Damage> damages;


		/// <summary>
		/// 
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		public virtual void Start() {

		}


		/// <summary>
		/// 
		/// </summary>
		public virtual void Update() {


		}


		public void AddDamage(Damage damage) {

		}
	}
}