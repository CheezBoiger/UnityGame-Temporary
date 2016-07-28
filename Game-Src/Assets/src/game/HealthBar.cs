using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace GameProject {
	public class HealthBar : MonoBehaviour {
		public float distanceAbove = 2.0f;
		private Image healthBarBk;
		private Image healthBarStatus;
		private Canvas healthBarTexture;
		private Health healthStatus;
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
				float maxHealth = healthStatus.GetMaxHealth();

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