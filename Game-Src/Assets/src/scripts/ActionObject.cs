using UnityEngine;
using System.Collections;

namespace GameProject {


/*
* ActionObject will take care of holding all common mechanics of objects
* that will be interacting and performing actions within the game.
* 
*/   
public abstract class ActionObject : Entity { 

  public ActionObject() 
    { }

  public abstract override void Start();
  public abstract override void Update();
}
} // namespace GameProject
