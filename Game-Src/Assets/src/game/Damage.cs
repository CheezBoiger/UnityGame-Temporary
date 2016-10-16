using UnityEngine;
using System.Collections;

namespace GameProject {
	/*
	 * DamageType is an enum record, allowing the variety of damage types in the game.
	 */
	public enum DamageType {
		NORMAL,   // normal resistance
		CORRUPT, // increased damage by resistance
		MYSTIC, // magical damage resistance.
		PURE, // not reduced by resistance
	}


	/// <summary>
	/// 
	/// </summary>
	public enum ElementalType {
		PHYSICAL, // No element
		COLD, // Cold element
		FIRE, // Fire element
		ELECTRIC, // Electric element
		POISON, // Poison element
		PLASMA,
	}


	/// <summary>
	/// 
	/// </summary>
	public class Damage : MonoBehaviour {
		public float damage;
		public float elementDamage;
		public ElementalType element;
		public DamageType type;


		// Use this for initialization
		void Start() {
		}


		// Update is called once per frame
		void Update() {

		}

	}
}