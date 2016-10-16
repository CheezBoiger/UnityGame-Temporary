using UnityEngine;
using System.Collections.Generic;

namespace GameProject {
	/// <summary>
	/// Defense is a component script for Actor, DO NOT USE ON WEAPONS OR ARMOR!!
	/// </summary>
	public abstract class Defense : MonoBehaviour {
		/// <summary>
		/// Actor's "natural" resistance.
		/// </summary>
		public Resistance actorResistance;

		/// <summary>
		/// Resistance from armor.
		/// </summary>
		public Resistance armorResistance;

		/// <summary>
		/// Increased Resistance from modifiers.
		/// </summary>
		private List<Resistance> resistances;

		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		void Update() {

		}
	}
}