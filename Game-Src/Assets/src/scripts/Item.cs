using UnityEngine;
using System.Collections.Generic;

namespace GameProject {

/*
 * DamageType is an enum record, allowing the variety of damage types in the game.
 */
enum DamageType {
  NORMAL,
  FIRE,
  COLD,
  ELECTRIC,
  POSION,
}

/*
 * Main Item abstract class is intended to group our items as one. They contain spells (if
 * specified), damage, a name, health modifications, energy modifications, movement modificiations,
 * etc. They contain the important aspect of Abilities, which are scripts to allow cool mechanics
 * that will be implemented into the gameplay.
 */
public abstract class Item : ActionObject {
  
  private float healthMod;
  private float energyMod;
  private float movementSpeedMod;
  private float damageMod;
  private float itemDamage;

  private List<Spell> spells = new List<Spell>();

  public abstract override void Start();
  public abstract override void Update();
}
} // namespace GameProject
