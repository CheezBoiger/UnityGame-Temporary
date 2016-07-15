using UnityEngine;
using System.Collections.Generic;

namespace GameProject {
  

public enum SpellType {
  ACTIVE,
  PASSIVE,
}


public abstract class Spell {
  private string spellName;
  private float damage;
  private float damageMod;
  private SpellType spellKind;
  

  public SpellType SpellKind {
    get {
      return spellKind;
    } set {
      spellKind = SpellKind;
    }
  }

  private List<SpellEffect> buffs;
  private List<SpellEffect> debuffs;
  }
}
