using UnityEngine;
using System.Collections;


namespace GameProject {

	public enum ObjectType {
		UNKNOWN,
		PLAYER,
		ENEMY,
		INANIMATE,
		BREAKABLE,
		ITEM,
		PROJECTILE,
	}

	/// <summary>
	/// Entity is a Relational object, giving everything in our map a type of 
	/// relation to one another, especially in terms of generalizing objects by
	/// grouping them. Unity uses tags to group as well, but this will serve as a 
	/// basic abstract object so as to help us understand eachothers intentions when
	/// writing our enemies, items, walls, breakables, crates, etc...
	/// </summary>
	public abstract class Entity : MonoBehaviour {
		protected float xPos;
		protected float yPos;
		// Maybe 3D vectors needed.
		protected float zPos;

		protected ObjectType objectType;
		protected bool invulnerable;
		/// <summary>
		/// Slow down time using this variable.
		/// </summary>
		protected bool slowedDown;
		

		public Entity() {
			xPos = this.transform.position.x;
			yPos = this.transform.position.y;
			zPos = this.transform.position.z;
			invulnerable = true;
			objectType = ObjectType.UNKNOWN;
			slowedDown = false;
		}


		public abstract void Start();
		public abstract void Update();
	}
} // namespace GameProject
