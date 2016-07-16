using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace GameProject {

/*
 * Projectile is an Entity that acts as the default object that is in mid air, prior to being shot by
 * something. It will serve as a container, which will hold spell effects, and transfer them to something,
 * such as a wall, NPC, an Enemy, or the Player and his allies. The Mathematics, as well as the Physics, can
 * be overridable by child classes, simply because we may need a derived class to do something special.
 */
public abstract class Projectile : Entity {
  /*
   * current position of the projectile.
   */
  private Vector3 position;
  /*
   * Acceleration of the projectile, will it be able to speed up the velocity in mid air?
   */
  private float acceleration;
  /*
   * Current velocity that the projectile is going.
   */
  private float velocity;

  /*
   * The spell effects that are added into the projectile. These will carry along to the 
   * target, ultimately injecting the effects into the Actor, or Entity, whatever is hit.
   */
  private HashSet<SpellEffect> effects;

	// Use this for initialization
	public abstract override void Start ();
	

	// Update is called once per frame
	public abstract override void Update ();

  /*
   * Basic collision detect function for the Unity engine. Can be overrided by a child class of projectile,
   * to perform whatever they want. 
   */
  public virtual void OnCollisionEnter2D( Collision2D coll) {
    Actor actor = coll.gameObject.GetComponent<Actor>();
    
    if (actor != null) {
      // A simple test on changing the angle of our projectile by rotating it. In 2D you would use forward from vector3D.
      transform.rotation = Quaternion.AngleAxis(-45, Vector3.forward);
      Debug.Log("I hit an actor!!");
    } else {
      Debug.Log("Unkown object hit me.");
    }
  } 
}
} // GameProject namespace