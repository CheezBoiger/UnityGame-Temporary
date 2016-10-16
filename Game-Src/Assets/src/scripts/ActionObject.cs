using UnityEngine;
using System.Collections.Generic;

namespace GameProject {
	/// <summary>
	///  ActionObject will take care of holding all common mechanics of objects
	/// that will be interacting and performing actions within the game.
	/// </summary>
	public abstract class ActionObject : Entity { 
		/// <summary>
		/// Current buffs on the actor, which will affect his/her gameplay.
		/// </summary>
		protected List<SpellEffect> currentBuffs;
		/// <summary>
		/// Current debuffs on the actor, which will cause trouble on their gameplay.
		/// </summary>
		protected HashSet<SpellEffect> currentDebuffs;

		public abstract override void Start();
		public abstract override void Update();


		public virtual void injectSpells() {
		}
	}
} // namespace GameProject
