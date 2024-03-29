﻿using UnityEngine;
using System.Collections.Generic;
using System;

namespace GameProject {
	public abstract class Weapon : Item {
		/// <summary>
		/// Damage done by Weapon itself (This does not include the spell effects included in
		/// this object
		/// </summary>
		protected DamageContainer damageC; 
		/// <summary>
		/// The spell effects that are included in the weapon.
		/// </summary>
		protected List<SpellEffect> spellEffects;
		/// <summary>
		/// Check if weapon is attacking.
		/// </summary>
		private bool isAttacking = false;
		/// <summary>
		/// 
		/// </summary>
		private float timer;
		
		public override void injectEffects(ActionObject obj) {

		}

		public override void obtainCommonEffect(ActionObject obj) {

		}

		// Use this for initialization
		public override void Start() {

		}

		// Update is called once per frame
		public override void Update() {

		}

		public void AddDamage(Damage damage) {
		}

		public void OnCollisionEnter(Collision col) {

		}
	}
}