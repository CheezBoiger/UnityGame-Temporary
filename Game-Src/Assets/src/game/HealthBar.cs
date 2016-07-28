using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace GameProject {
	/// <summary>
	/// 
	/// </summary>
	public class HealthBar : MonoBehaviour {
		private const float MAX_BAR_HEIGHT = 2f;
		private const float MAX_BAR_WIDTH_REDUCTION = 0.5f;
		private const float MAX_BAR_WIDTH = 128.0f;

		private float healthToBarWidth;
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

			healthToBarWidth = MAX_BAR_WIDTH * 2f;
		}

		// Update is called once per frame
		void LateUpdate() {
			if (healthBarTexture && healthBarStatus) {
				Vector2 sizedVector;
				float health = healthStatus.GetHealth();
				float maxHealth = healthStatus.GetMaxHealthStatus();

				if (maxHealth >= healthToBarWidth) {
					sizedVector = new Vector2(MAX_BAR_WIDTH, MAX_BAR_HEIGHT);
				} else {
					sizedVector = new Vector2((maxHealth * MAX_BAR_WIDTH_REDUCTION), MAX_BAR_HEIGHT);
				}

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
					Debug.Log("No health bk as well!");
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