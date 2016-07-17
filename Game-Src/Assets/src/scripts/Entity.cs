using UnityEngine;
using System.Collections;


namespace GameProject {

	enum ObjectType {
	  UNKNOWN,
	  PLAYER,
	  ENEMY,
	  INANIMATE,
	  BREAKABLE,
	}

	/// <summary>
	/// Entity is a Relational object, giving everything in our map a type of 
	/// relation to one another, especially in terms of generalizing objects by
	/// grouping them. Unity uses tags to group as well, but this will serve as a 
	/// basic abstract object so as to help us understand eachothers intentions when
	/// writing our enemies, items, walls, breakables, crates, etc...
	/// </summary>
	public abstract class Entity : MonoBehaviour {
	  float xPos;
	  float yPos;
	  // Maybe 3D vectors needed.
	  float zPos;

	  ObjectType type;
	  bool invulnerable;

	  public Entity() {
	    xPos = this.transform.position.x;
	    yPos = this.transform.position.y;
	    zPos = this.transform.position.z;
	    invulnerable = true;
	    type = ObjectType.UNKNOWN;
	  }


	  public abstract void Start();
	  public abstract void Update();
	}
} // namespace GameProject
