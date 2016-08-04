using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameProject {


	/// <summary>
	/// 
	/// </summary>
	public abstract class DamageContainer : MonoBehaviour {
		private float normalDamage;
		private float pureDamage;
		private float corruptDamage;

		private List<Damage> damages;

		// Use this for initialization
		public virtual void Start() {
			Damage vanDam = new Damage();
			vanDam.type = DamageType.NORMAL;
			vanDam.normalDamage = 10f;

			damages.Add(vanDam);
			Damage pan = new Damage();
			pan.type = DamageType.NORMAL;
			pan.normalDamage = 4f;

			damages.Add(pan);
			/////////////////////////////
			damages.Remove(pan);
		}


		// Update is called once per frame
		public virtual void Update() {


		}

		public void AddDamage(Damage damge) {

		}
	}
}