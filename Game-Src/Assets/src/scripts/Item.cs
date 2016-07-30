using UnityEngine;
using System.Collections.Generic;

namespace GameProject {
	/*
	 * DamageType is an enum record, allowing the variety of damage types in the game.
	 */
	public enum DamageType {
		NORMAL,
		FIRE,
		COLD,
		ELECTRIC,
		POSION,
	}

	public enum ItemType {
		MELEE,
		RANGED,
		POTION,
		ARMOR,

	}

	/*
	 * Main Item abstract class is intended to group our items as one. They contain spells (if
	 * specified), damage, a name, health modifications, energy modifications, movement modificiations,
	 * etc. They contain the important aspect of Abilities, which are scripts to allow cool mechanics
	 * that will be implemented into the gameplay.
	 */
	public abstract class Item : ActionObject {
		private ItemType typeOfItem;

		private float healthMod;
		private float energyMod;
		private float movementSpeedMod;
		private float damageMod;
		private float itemDamage;
		/*
		 * We should have only one ability per item, since it would be hectic to see too many
		 * abilities on one item.
		 */
		private Ability distinctAbility;
		/*
		 * Certain spells give certain buffs, debuffs, and 
		 */
		private HashSet<Spell> spells = new HashSet<Spell>();

		public abstract override void Start();
		public abstract override void Update();

		public abstract void injectEffects();
		public abstract void obtainCommonEffect();
	}
} // namespace GameProject
