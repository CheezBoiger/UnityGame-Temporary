using System.Collections;

namespace GameProject {
	public enum AffectOnType {
	  ALLIES,
	  ENEMIES,
	  OBJECTS,
	}

	/// <summary>
	/// SpellEffect allows descriptions about the effects that are contained in a Spell
	/// object. SpellEffect Desribes the damage, type, range, spread, AoE, and who it 
	/// affects, adding de/buffs to actors and items, or anthing really. 
	/// </summary>
	public abstract class SpellEffect {
	  private bool isBuff;
	  private bool hasTimer;

	  private string description;

	  private float radius;
	  private float spread;
	  private float areaOfEffect;

	  private int projectiles;
	  private int timer;

	  private AffectOnType affectOn;
	  private DamageType damType;
	  

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
