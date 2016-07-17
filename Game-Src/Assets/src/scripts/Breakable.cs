using UnityEngine;
using System.Collections;

namespace GameProject {

	/// <summary>
	/// Breakables define objects that are able to be broken by ActiveObjects.
	/// All things involved in breakable objects (such as crates, walls, bushes, vases, etc)
	/// should be associated with Breakable. Attributes are still in the works.
	/// </summary>
	public abstract class Breakable : Entity {

		/// Use this for initialization
		public abstract override void Start();
		/// Update is called once per frame
		public abstract override void Update();
	}
}
