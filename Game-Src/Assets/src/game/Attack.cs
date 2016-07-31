using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Attack is a script intended for use on Weapons, not Actors.
	/// </summary>
	public class Attack : MonoBehaviour {
		/// <summary>
		/// This will have to change to Weapon (inherited by Item).
		/// </summary>
		private Damage ownerDamage;
		/// <summary>
		/// Check if player is attacking.
		/// </summary>
		public bool isAttacking;
		/// <summary>
		/// how long the Component is attacking.
		/// </summary>
		private float attackTimer = 1.0f;

		public float currentTimer = 0.0f;

		// Use this for initialization
		public virtual void Start() {
			isAttacking = false;
			ownerDamage = GetComponent<Damage>();
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
						health.ReceiveDamage(ownerDamage.GetCurrentDamage());
					}
				}
			}
		}
	}
}