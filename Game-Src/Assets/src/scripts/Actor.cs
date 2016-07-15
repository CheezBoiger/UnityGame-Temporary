using UnityEngine;
using System;
using System.Collections.Generic;

namespace GameProject {

  /* 
   * The condition of our Actor.
   */
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
}


public class Resistance {
  public string name;
  public DamageType DamType;
  public float resist;
}


/*
 * Actor is the movable object that we interact with, s/he will be controlled by the user,
 * AI, or an NPC.
 * We can do what we want here without worrying too much on figuring out
 * the attacks and whatnot. This is a test though!
 */
public abstract class Actor : ActionObject {
  #region Private Attributes
  private float movementRate;
  /*
   * Base health marks the base at which an ActionObject will define the default health.
   * This is strictly based on whether or not our items may not need it, but if we defined a basic
   * Actor, they will need a base health, to see if they have any health boosts and whatnot.
   */ 
  private float baseHealth;
  /*
   * The maximum health that our ActionObject currently has, so as to keep track of it during combat.
   */
  private float maxHealth;
  /*
   * Current health status of the ActionObject.
   */ 
  private float health;
  /*
   * Maximum energy that this ActionObject will have.
   */
  private float maxEnergy;
  /*
   * Current energy that the actor has.
   */
  private float energy;

  

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
  #endregion
  

  public abstract override void Start();


  // Update is called once per frame
  public abstract override void Update();


  public virtual void MergeActors(Actor mergeActor) {
    
  }


  public virtual void reflectDamage(List<Actor> actors) {
  }
}
}
