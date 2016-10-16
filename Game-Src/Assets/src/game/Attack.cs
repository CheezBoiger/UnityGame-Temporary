using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Attack is a script intended for use on Weapons, not Actors. 
	/// Obsolete, do not use!!
	/// </summary>
	[System.Obsolete]
	public class Attack : MonoBehaviour {
		/// <summary>
		/// This will have to change to Weapon (inherited by Item).
		/// </summary>
		private DamageContainer ownerDamage;
		/// <summary>
		/// Check if player is attacking.
		/// </summary>
		public bool isAttacking;
		/// <summary>
		/// how long the Component is attacking.
		/// </summary>
		private float attackTimer = 0.5f;

		public float currentTimer = 0.0f;

		// Use this for initialization
		public virtual void Start() {
			isAttacking = false;
			ownerDamage = GetComponent<DamageContainer>();
		}


		// Update is called once per frame
		public virtual void Update() {

			if (Input.GetKey(KeyCode.Mouse0)) {
				DealAttack();
			}

			if (isAttacking) {
				currentTimer += Time.deltaTime;
				if (currentTimer > attackTimer) {
					currentTimer = attackTimer;
					isAttacking = false;
				}
			}
		}


		/// <summary>
		/// Start the attack.
		/// </summary>
		public void DealAttack() {
			isAttacking = true;
			currentTimer = 0.0f;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="collision"></param>
		public void OnCollisionEnter(Collision collision) {
			Actor actor = collision.gameObject.GetComponent<Actor>();

			if (actor != null) {
				if (isAttacking) {
					Health health = actor.GetComponent<Health>();
					if (ownerDamage != null) {
						// Do damage with Weapon!
						health.ReceiveDamage(3f);
					}
				}
			}
		}
	}
}