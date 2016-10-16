using UnityEngine;
using System.Collections;

namespace GameProject {

	public class Resistance : MonoBehaviour {
		/// <summary>
		/// Resistance float value. No percentage is necessary
		/// </summary>
		public float resist = 0.0f;
		/// <summary>
		/// Damage type resistance.
		/// </summary>
		public float damageResist = 0.0f;
		/// <summary>
		/// Element type that is also resisted.
		/// </summary>
		public ElementalType elementType;
		/// <summary>
		/// Resistance to some damage types. Pure damage cannot be resisted!
		/// </summary>
		public DamageType damageType;
		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		void Update() {

		}
	}
}