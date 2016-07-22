using UnityEngine;
using System;
using System.Collections.Generic;

namespace GameProject {
	/// <summary>
	/// The condition of our Actor.
	/// </summary>
	public enum Condition {
		NOTHING,
		STUNNED,
		POISONED,
		FROZEN,
		BURNING,
		SHOCKED,
		BLEEDING,
		ENSTRANGLED,
		INFECTED,
		CURSED,
		CONFUSED,
		WEAKENED,
		STRENGTHENED,
		SCARED,
		INVULNERABLE,
	}

	public class Resistance {
		public string name;
		public DamageType DamType;
		public float resist;
	}


	/// <summary>
	/// Actor is the movable object that we interact with, s/he will be controlled by the user,
	/// AI, or an NPC.
	/// We can do what we want here without worrying too much on figuring out
	// the attacks and whatnot. This is a test though!
	/// </summary>
	public abstract class Actor : ActionObject {
		#region Private Attributes
		private float movementRate;

		/// <summary>
		/// Base health marks the base at which an ActionObject will define the default health.
		/// This is strictly based on whether or not our items may not need it, but if we defined a basic
		/// Actor, they will need a base health, to see if they have any health boosts and whatnot.
		/// </summary>
		private float baseHealth;
		/// <summary>
		/// The maximum health that our ActionObject currently has, so as to keep track of it during combat.
		/// </summary>
		private float maxHealth;
		/// <summary>
		/// Current health status of the ActionObject.
		/// </summary>
		private float health;
		/// <summary>
		/// Maximum energy that this ActionObject will have.
		/// </summary>
		private float maxEnergy;
		/// <summary>
		/// Current energy that the actor has.
		/// </summary>
		private float energy;

		/// <summary>
		/// Current buffs on the actor, which will affect his/her gameplay.
		/// </summary>
		private HashSet<SpellEffect> currentBuffs;
		/// <summary>
		/// Current debuffs on the actor, which will cause trouble on their gameplay.
		/// </summary>
		private HashSet<SpellEffect> currentDebuffs;

		/// <summary>
		/// The item the actor is stepping on.
		/// </summary>
		private Item walkedOverItem;

		#endregion

		#region Getters and Setters

		public float MaxEnergy {
			get {
				return maxEnergy;
			} set {
				maxEnergy = MaxEnergy;
			}
		}

		public float BaseHealth {
			get { 
				return baseHealth;
			} set {
				baseHealth = BaseHealth;
			}
		}

		public float MaxHealth {
			get { 
				return maxHealth;
			} set {
				maxHealth = MaxHealth;
			} 
		}

		public float Health {
			get {
				return health;
			} set {
				health = Health;
			}
		}

		public float Energy {
			get {
				return energy;
			} set {
				energy = Energy;
			}
		}

		public float MovementRate {
			get {
				return movementRate;
			} set {
				movementRate = MovementRate;
			}
		}

		public Item WalkedOverItem {
			get {
				return walkedOverItem;
			} set {
				walkedOverItem = value;
			}
		}

		#endregion


		public abstract override void Start();


		// Update is called once per frame
		public abstract override void Update();


		public virtual void MergeActors(Actor mergeActor) {

		}

		/// <summary>
		/// Inject any SpellEffect objects that collided with the Actor.
		/// </summary>
		public virtual void InjectSpellEffects(HashSet<SpellEffect> effects) {
		}

		public virtual void ReflectDamage(List<Actor> actors) {
		}

		/// <summary>
		/// Event gets trigged when the actor collides with a collectible item on the map
		/// This will store the item into the WalkedOverItem object.
		/// </summary>
		/// <param name="other">The item on the map</param>
		public void OnTriggerEnter(Collider other) {
			Debug.Log("I am triggered!!");
			Item result = other.GetComponent<Item>();
			if(result != null) {
				walkedOverItem = other.GetComponent<Item>();
			}
		}

		/// <summary>
		/// Intentionally updates to ensure that the 
		/// </summary>
		/// <param name="other"></param>
		public void OnTriggerStay(Collider other) {
			Debug.Log("I'm still triggered!");
			Item result = other.GetComponent<Item>();
			if(result != null) {
				walkedOverItem = other.GetComponent<Item>();
			}
		}

		/// <summary>
		/// Event gets trigged when the actor leaves the area that has a collectible item on the map
		/// This will assign null to the WalkedOverItem object.
		/// </summary>
		/// <param name="other">The item on the map</param>
		public void OnTriggerExit(Collider other) {
			Item result = other.GetComponent<Item>();
			if (result != null) {
				walkedOverItem = null;
			}
		}
	}
}
