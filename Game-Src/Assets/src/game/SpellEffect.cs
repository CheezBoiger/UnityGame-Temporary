using System.Collections;

namespace GameProject {


public enum EffectOnType {
  ALLIES,
  ENEMIES,
  OBJECTS,
}


public abstract class SpellEffect {
  private bool isBuff;
  private string description;
  private DamageType damType;
  private float radius;
  private EffectOnType effectOn;

  
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
}
}
