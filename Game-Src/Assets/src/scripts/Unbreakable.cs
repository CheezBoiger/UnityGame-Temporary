using UnityEngine;
using System.Collections;

namespace GameProject {
	/// <summary>
	/// Unbreakable defines all objects that cannot break, these include 
	/// walls that define the bounds of the map, so that the play may not somehow
	/// jump out of the map, and other materials that should not be destroyed during 
	/// gameplay, by ActiveObjects.
	/// </summary>
	public abstract class Unbreakable : Entity {

		// Use this for initialization
		public abstract override void Start();
	
		// Update is called once per frame
		public abstract override void Update();
	}
}
