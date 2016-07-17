using UnityEngine;
using System.Collections.Generic;

namespace GameProject {
	
	public enum SpellType {
	  ACTIVE,
	  PASSIVE,
	}

	public abstract class Spell : Entity {
		private string spellName;

		private bool hasCooldown;

		private float damage;
		private float damageMod;

		private int coolDownTimer;

		private SpellType spellKind;
	  
		private List<SpellEffect> buffs;
		private List<SpellEffect> debuffs;


		public SpellType SpellKind {
			get {
				return spellKind;
			} set {
				spellKind = SpellKind;
			}
		}
	}
}
