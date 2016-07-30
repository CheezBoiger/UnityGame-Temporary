using UnityEngine;
using System.Collections;

namespace GameProject {

	public class Damage : MonoBehaviour {
		private Item itemOnHand;

		public float baseDamage;

		private float maxDamage;
		private float maxDamageStatus;
		private float currentDamage;

		// Use this for initialization
		void Start() {
			if (itemOnHand) {
			}
		}

		// Update is called once per frame
		void Update() {

		}
	}
}