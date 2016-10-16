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
		public Color bloodSplatColor;
		private float flashSpeed = 5f;

		private float healthSeverity = 10.1f;

		private float maxSeverity = 1.0f;
		// Use this for initialization
		public override void Start() {
			base.Start();
			newColor = new Color(1f, 0f, 0f, 0.1f);
			bloodSplatColor = new Color(1f, 0f, 0f, healthSeverity);

			bloodSplat.color = Color.clear;

			Rect bloodImage = bloodSplat.GetComponentInParent<Canvas>().pixelRect;
			Rect imageDam = imageDamage.GetComponentInParent<Canvas>().pixelRect;

			imageDamage.rectTransform.sizeDelta = new Vector2(imageDam.width, imageDam.height);
			bloodSplat.rectTransform.sizeDelta = new Vector2(bloodImage.width, bloodImage.height);
		}


		// Update is called once per frame
		public override void Update() {
			base.Update();
			
			if (damaged) {
				imageDamage.color = newColor;
				bloodSplat.color = bloodSplatColor;
			} else {
				imageDamage.color = Color.Lerp(imageDamage.color, Color.clear, flashSpeed * Time.deltaTime);
				bloodSplat.color = Color.Lerp(bloodSplat.color, Color.clear, flashSpeed * Time.deltaTime);
			}

			damaged = false;
		}
	}
}