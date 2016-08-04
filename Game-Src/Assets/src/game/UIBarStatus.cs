using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Proj {
	
}

namespace GameProject {
	/// <summary>
	/// UIBarStatus is a Script containing the Algorithm of displaying the health bar, and
	/// energy bar, above a 3D object, and projecting it over to the 2D camera UI.
	/// </summary>
	public class UIBarStatus : MonoBehaviour {
		private const float MAX_BAR_HEIGHT = 4f;
		private const float MAX_BAR_WIDTH_REDUCTION = 0.5f;
		private const float MAX_BAR_WIDTH = 128.0f;
		private float healthToBarWidth;

		/// <summary>
		/// The distance of the canvas above the game object.
		/// </summary>
		public float distanceAbove = 2.0f;
		/// <summary>
		/// 
		/// </summary>
		public float distanceBetweenBars = 1.0f;
		/// <summary>
		/// 
		/// </summary>
		private float lastHealthBarStatus = 0f;
		/// <summary>
		/// 
		/// </summary>
		private float lastCurrentHealthStatus = 0f;
		/// <summary>
		/// Health bar background.
		/// </summary>
		private Image healthBarBk;
		/// <summary>
		/// 
		/// </summary>
		private Image energyBarBk;
		/// <summary>
		/// health bar status for the current health.
		/// </summary>
		private Image healthBarStatus;
		private Image healthBarTaken;
		/// <summary>
		/// 
		/// </summary>
		private Image energyBarStatus;
		/// <summary>
		/// The Canvas that holds the health bar textures.
		/// </summary>
		private Canvas barTexture;
		/// <summary>
		/// Health status script on the parent.
		/// </summary>
		private Health healthStatus;
		/// <summary>
		/// 
		/// </summary>
		private Energy energyStatus;
		/// <summary>
		/// The target parent object, of which to level the health bar above.
		/// </summary>
		public Transform target;
		/// <summary>
		/// 
		/// </summary>
		public bool showHealthBar = true;
		/// <summary>
		/// Incorporate just in case we are dealing with multiplayer sessions.
		/// </summary>
		public bool showEnergyBar = false;
		//DamageType test = DamageType.COLD;

		// Use this for initialization
		void Start() {

			barTexture = GetComponent<Canvas>();
			healthStatus = target.GetComponentInParent<Health>();
			energyStatus = target.GetComponentInParent<Energy>();

			healthBarBk = transform
				.FindChild("HealthBack")
				.GetComponent<Image>();

			healthBarStatus = transform
				.FindChild("HealthBack")
				.FindChild("healthTaken")
				.FindChild("healthStatus")
				.GetComponent<Image>();

			healthBarTaken = transform
				.FindChild("HealthBack")
				.FindChild("healthTaken")
				.GetComponent<Image>();

			energyBarBk = transform
				.FindChild("EnergyBack")
				.GetComponent<Image>();

			energyBarStatus = transform
				.FindChild("EnergyBack")
				.FindChild("energyStatus")
				.GetComponent<Image>();

			healthToBarWidth = MAX_BAR_WIDTH * 2f;
			
		}

		// Update is called once per frame
		void LateUpdate() {
			if (barTexture && healthBarStatus) {
				Vector2 sizedVector;
				float health = healthStatus.GetHealth();
				float energy = energyStatus.GetCurrentEnergy();
				float maxHealth = healthStatus.GetMaxHealthStatus();
				float maxEnergy = energyStatus.GetMaxEnergyStatus();

				if (maxHealth >= healthToBarWidth) {
					sizedVector = new Vector2(MAX_BAR_WIDTH, MAX_BAR_HEIGHT);
				} else {
					sizedVector = new Vector2((maxHealth * MAX_BAR_WIDTH_REDUCTION), MAX_BAR_HEIGHT);
				}

				healthBarBk.rectTransform.sizeDelta =     Vector3.Lerp(healthBarBk.rectTransform.sizeDelta, 
					sizedVector, 
					Time.deltaTime);
				healthBarStatus.rectTransform.sizeDelta = Vector3.Lerp(healthBarStatus.rectTransform.sizeDelta, 
					sizedVector, 
					Time.deltaTime);
				healthBarTaken.rectTransform.sizeDelta = Vector3.Lerp(healthBarTaken.rectTransform.sizeDelta,
					sizedVector,
					Time.deltaTime);
				energyBarBk.rectTransform.sizeDelta =     Vector3.Lerp(energyBarBk.rectTransform.sizeDelta, 
					sizedVector, 
					Time.deltaTime);
				energyBarStatus.rectTransform.sizeDelta = Vector3.Lerp(energyBarStatus.rectTransform.sizeDelta, 
					sizedVector, 
					Time.deltaTime);

				healthBarStatus.fillAmount = health / maxHealth;
				healthBarTaken.fillAmount = Mathf.Lerp(healthBarTaken.fillAmount, healthBarStatus.fillAmount, Time.deltaTime * 2f);
				energyBarStatus.fillAmount = energy / maxEnergy;

				Vector3 pos = Camera.main.WorldToScreenPoint(target.position);

				healthBarBk.rectTransform.position = new Vector3(pos.x, pos.y + distanceAbove, pos.z);
				healthBarStatus.rectTransform.position = healthBarBk.rectTransform.position;
				
				energyBarBk.rectTransform.position = new Vector3(healthBarBk.rectTransform.position.x, 
					healthBarBk.rectTransform.position.y - distanceBetweenBars, 
					healthBarBk.rectTransform.position.z);

				energyBarStatus.rectTransform.position = energyBarBk.rectTransform.position;
				// Angle towards camera.
				barTexture.transform.eulerAngles = Camera.main.transform.eulerAngles;

				if (!showEnergyBar) {
					energyBarBk.enabled = false;
					energyBarStatus.enabled = false;
				} else {
					energyBarBk.enabled = true;
					energyBarStatus.enabled = true;
				}

				if (!showHealthBar) {
					healthBarBk.enabled = false;
					healthBarStatus.enabled = false;
				} else {
					healthBarBk.enabled = true;
					healthBarStatus.enabled = true;
				}
			} else {
				if (!barTexture) {
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