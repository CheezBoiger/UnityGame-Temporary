using UnityEngine;
using System.Collections;


namespace GameProject {
	public class Stats : MonoBehaviour {
		private DamageContainer overallDamage;
		private Defense overallDefense;

		// Use this for initialization
		void Start() {
			overallDamage = GetComponent<DamageContainer>();
			overallDefense = GetComponent<Defense>();
		}

		// Update is called once per frame
		void Update() {

		}
	}
}