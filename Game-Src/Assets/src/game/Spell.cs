using UnityEngine;
using System.Collections.Generic;

namespace GameProject {
  

public abstract class Spell {
  private string spellName;
  private float damage;
  private float damageMod;

  private List<SpellEffect> buffs;
  private List<SpellEffect> debuffs;
  }
}
