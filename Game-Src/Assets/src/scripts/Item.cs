using UnityEngine;
using System.Collections.Generic;

namespace GameProject {
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
		/*
		 * We should have only one ability per item, since it would be hectic to see too many
		 * abilities on one item.
		 */
		private Ability distinctAbility;
		/// <summary>
		/// Spells that come with the item, they are added to the Actor or ActionObject while
		/// they have them equipped or used.
		/// </summary>
		private HashSet<Spell> spells = new HashSet<Spell>();

		public abstract override void Start();
		public abstract override void Update();

		public abstract void injectEffects(ActionObject obj);
		public abstract void obtainCommonEffect(ActionObject obj);
	}
} // namespace GameProject
