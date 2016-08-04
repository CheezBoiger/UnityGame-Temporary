using UnityEngine;
using System.Collections;

namespace GameProject {
		/*
	 * DamageType is an enum record, allowing the variety of damage types in the game.
	 */
	public enum DamageType {
		NORMAL,
		CORRUPT,
		PURE, // not reduced by resistance
	}


	public enum ElementalType {
		NONE,
		COLD,
		FIRE,
		ELECTRIC,
		POISON,
	}


	public class Damage : MonoBehaviour {
		public float normalDamage;
		public ElementalType element;
		public DamageType type;

		// Use this for initialization
		void Start() {
		}

		// Update is called once per frame
		void Update() {

		}

		public void addtoDamageContainer(DamageContainer container) {

		}
	}
}