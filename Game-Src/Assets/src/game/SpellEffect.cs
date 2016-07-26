using System.Collections;

namespace GameProject {
	/// <summary>
	/// Determines what entity does this Effect.
	/// </summary>
	public enum AffectOnType {
		ALLIES,
		ENEMIES,
		OBJECTS,
		PROJECTILES,
		ITEMS,
		SPELLS,
		ABILITIES,
	}

	/// <summary>
	/// SpellEffect allows descriptions about the effects that are contained in a Spell
	/// object. SpellEffect Desribes the damage, type, range, spread, AoE, and who it 
	/// affects, adding de/buffs to actors and items, or anthing really. 
	/// </summary>
	public abstract class SpellEffect {
		/// <summary>
		/// Checks whether the SpellEffect is a buff to the Entity, or a debuff.
		/// </summary>
		private bool isBuff;
		/// <summary>
		/// Does this SpellEffect have a timer?
		/// </summary>
		private bool hasTimer;
		/// <summary>
		/// Description of the Spell Effect.
		/// </summary>
		private string description;
		/// <summary>
		/// The Overall radius (distance/range) of the spell effect.
		/// The radius is measured by the displacement between the caster and 
		/// the target point.
		/// </summary>
		private float radius;
		/// <summary>
		/// Spread determines how far apart the projectiles/or the damage of this SpellEffect will
		/// separate from the start point to the target destination. Think of it as a cleave effect.
		/// </summary>
		private float spread;
		/// <summary>
		/// Determines the area of effect, or the effecting area at the starting point of the source (which is the 
		/// spell effect).
		/// </summary>
		private float areaOfEffect;
		/// <summary>
		/// If hasTimer is true, this timer will determine how long the SpellEffect lasts.
		/// </summary>
		private int timer;
		/// <summary>
		/// What does this SpellEffect affect?
		/// </summary>
		private AffectOnType affectOn;
		/// <summary>
		/// The damage type of this SpellEffect.
		/// </summary>
		private DamageType damType;
		/// <summary>
		/// bonusAffect is the point system that is highly dependent on the the DamageType, because it will
		/// determine whether the points in bonusAffect will be damaging, or healing, or fortifying, or energizing
		/// the ActiveObject.
		/// </summary>
		private float bonusAffect;

		#region Getters and Setters
		public bool IsBuff {
			get {
				return isBuff;
			} set {
				isBuff = IsBuff;
			}
		}

	  
		public string Description {
			get {
				return description;
			} set {
				description = Description;
			}
		}

	  
		public DamageType DamType {
			get {
				return damType;
			} set {
				damType = DamType;
			}
		}

		#endregion

		/// <summary>
		/// Apply the bonusAffect on the obj, which will be dependent on the DamageType.
		/// </summary>
		/// <param name="obj"></param>
		public virtual void ApplyBonusAffect(ref ActionObject obj) {
		}
	}
}
