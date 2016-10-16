using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProject {
	/// <summary>
	/// AbilityType determines the type that the ability does. In general, you can have a 
	/// morphing ability, allowing you to turn into a wild beast to wreck havoc on your foes.
	/// </summary>
	enum AbilityType {
		NOTHING,
		FLY,
		DEGRADE,
		HEAL,
		CONJURE,
		LIQUIFY,
		SOLIDIFY,
		STRENGTHEN,
		WEAKEN,
		MORPH,
		SUMMON,
		INVULNERABILITY,
		FIRE,
		COLD,
		POISON,
		SHOCK,
		FLATTEN,
		VORTEX,
		INVISIBILITY,
	}


	/// <summary>
	/// Ability marks the available actions that an Actor may be able to do. This means, An actor, such as an enemy, or the player,
	/// will be given special actions so as to make the game much more unique in terms of the behaviour of our Actors.
	/// </summary>
	public abstract class Ability : Entity {
		protected HashSet<SpellEffect> spellEffects;

		public override abstract void Start();

		public override abstract void Update();
		/// <summary>
		/// 
		/// </summary>
		public virtual void InjectSpellEffects() {

		}
	}
}
