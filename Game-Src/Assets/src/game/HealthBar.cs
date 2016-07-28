using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace GameProject {
	/// <summary>
	/// 
	/// </summary>
	public class HealthBar : MonoBehaviour {
		/// <summary>
		/// The distance of the canvas above the game object.
		/// </summary>
		public float distanceAbove = 2.0f;
		/// <summary>
		/// Health bar background.
		/// </summary>
		private Image healthBarBk;
		/// <summary>
		/// health bar status for the current health.
		/// </summary>
		private Image healthBarStatus;
		/// <summary>
		/// The Canvas that holds the health bar textures.
		/// </summary>
		private Canvas healthBarTexture;
		/// <summary>
		/// Health status script on the parent.
		/// </summary>
		private Health healthStatus;
		/// <summary>
		/// The target parent object, of which to level the health bar above.
		/// </summary>
		private Transform target;

		// Use this for initialization
		void Start() {
			healthBarTexture = GetComponent<Canvas>();
			target = transform.parent.transform;
			healthStatus = GetComponentInParent<Health>();

			healthBarTexture.transform.position = new Vector3(target.position.x,
				target.position.y + distanceAbove, 
				target.position.z);

			healthBarBk = transform
				.FindChild("HealthBack")
				.GetComponent<Image>();

			healthBarStatus = transform
				.FindChild("HealthBack")
				.FindChild("healthStatus")
				.GetComponent<Image>();
		}

		// Update is called once per frame
		void LateUpdate() {
			if (healthBarTexture && healthBarStatus) {
				float health = healthStatus.GetHealth();
				float maxHealth = healthStatus.GetMaxHealthStatus();

				Vector2 sizedVector = new Vector2((maxHealth * 0.4f), 4f);
				healthBarBk.rectTransform.sizeDelta = sizedVector;
				healthBarStatus.rectTransform.sizeDelta = sizedVector;

				healthBarStatus.fillAmount = health / maxHealth;
				// Angle towards camera.
				healthBarTexture.transform.eulerAngles = Camera.main.transform.eulerAngles;
			} else {
				if (!healthBarTexture) {
					Debug.Log("no helath bar texture!");
				} else {
					Debug.Log("No health bar status!");
				}

				if (!healthBarBk) {
					Debug.Log("No helath bk as well!");
				}

				throw new MissingReferenceException();
			}
		}

		public void SendDamageToHealthBar(float damage) {

		}

		public void SentHealToHealthBar(float heal) {

		}

	}
}