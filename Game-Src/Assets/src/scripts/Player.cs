using UnityEngine;
using System.Collections;
using System;

namespace GameProject {



/*
 * Player test, only for experimenting, not Official.
 */
public sealed class Player : Actor {

  public override void Start() {
  }


  // Update is called once per frame
  public override void Update () {
    //Debug.Log(this.gameObject.name);
  }


  public void OnApplicationFocus( bool focusStatus ) {
    Debug.Log("Player focused!!");
  }


  public void OnApplicationPause( bool pauseStatus ) {
    Debug.Log("Player is paused!!");
  }


  public void OnCollisionStay2D(Collision2D coll) {

    Actor enemy = coll.gameObject.GetComponent<Actor>();
    Debug.Log("I am collided!!");
    if (coll.gameObject.tag.CompareTo("Enemy") == 0) {
      Debug.Log("Enemy is touching me!!");
    }
  }
}
} // GameProject namespace