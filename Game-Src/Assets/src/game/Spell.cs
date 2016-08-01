﻿using UnityEngine;
using System.Collections.Generic;

namespace GameProject {
	
	public enum SpellType {
	  ACTIVE,
	  PASSIVE,
	}
	/// <summary>
	/// Spell is an abstract class, bred to simply 
	/// </summary>
	public abstract class Spell : Entity {
		private string spellName;

		protected bool hasCooldown;
		protected int coolDownTimer;

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


		public void InjectBuffs(ActionObject obj) {

		}
	}
}
