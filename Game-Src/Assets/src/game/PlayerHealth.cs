using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace GameProject {
	/// <summary>
	/// Player Health script. This scipt will add the effect and such for the 
	/// Camera UI.
	/// </summary>
	public class PlayerHealth : Health {

		public Image imageDamage;
		public Image bloodSplat;

		public Color newColor;
		private float flashSpeed = 5f;

		// Use this for initialization
		public override void Start() {
			base.Start();
			newColor = new Color(1f, 0f, 0f, 0.1f);
		}

		// Update is called once per frame
		public override void Update() {
			base.Update();
			
			if (damaged) {
				imageDamage.color = newColor;
				bloodSplat.color = newColor;
			} else {
				imageDamage.color = Color.Lerp(imageDamage.color, Color.clear, flashSpeed * Time.deltaTime);
				bloodSplat.color = Color.Lerp(bloodSplat.color, Color.clear, flashSpeed * Time.deltaTime);
			}

			damaged = false;
		}
	}
}