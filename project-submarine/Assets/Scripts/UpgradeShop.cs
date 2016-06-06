using UnityEngine;
using System.Collections;

public class UpgradeShop : MonoBehaviour {

	[SerializeField]
	private Canvas ShopWindow;
	[SerializeField]
	private GameObject Selection;
	[SerializeField]
	private GameObject Text;

	[SerializeField]
	private GameObject Weapon0;
	[SerializeField]
	private GameObject Weapon1;
	[SerializeField]
	private GameObject Weapon2;

	[SerializeField]
	private GameObject WeaponE0;
	[SerializeField]
	private GameObject WeaponE1;
	[SerializeField]
	private GameObject WeaponE2;

	[SerializeField]
	private GameObject Engine0;
	[SerializeField]
	private GameObject Engine1;
	[SerializeField]
	private GameObject Engine2;

	[SerializeField]
	private GameObject EngineE0;
	[SerializeField]
	private GameObject EngineE1;
	[SerializeField]
	private GameObject EngineE2;

	[SerializeField]
	private GameObject EngIcon;
	[SerializeField]
	private GameObject WepIcon;

	[SerializeField]
	private int UpgradeCostWeapon;
	[SerializeField]
	private int UpgradeCostEngine;

	[SerializeField]
	private Camera Camera1;
	[SerializeField]
	private Camera Camera2;


	private int current = 0;
	private bool SpeedPlus;
	private bool SpeedMin;
	private bool CanShop;
	private float Speed;

	void Awake()
	{
		ShopWindow.enabled = false;
		Camera1.enabled = true;
		Camera2.enabled = false;
		WepIcon.SetActive (true);
		EngIcon.SetActive (false);
	}

	public void Exit()
	{
		Text.SetActive (true);
		Pauze.Pause = false;
		ShopWindow.enabled = false;
		Camera1.enabled = true;
		Camera2.enabled = false;
	}

	// Update is called once per frame
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			CanShop = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			CanShop = false;
		}
	}

	public void Upgrade()
	{
		if(UIController.Pickups >= UpgradeCostWeapon && current == 0)
		{
			if(Weapon0.activeInHierarchy)
			{
				Weapon0.SetActive(false);
				Weapon1.SetActive(true);
				UpgradeCostWeapon += 10;
				UIController.Pickups -= UpgradeCostWeapon;
			}

			if(Weapon1.activeInHierarchy)
			{
				Weapon1.SetActive(false);
				Weapon2.SetActive(true);
				UpgradeCostWeapon += 15;
				UIController.Pickups -= UpgradeCostWeapon;
			}
		}

		if(UIController.Pickups >= UpgradeCostEngine && current == 1)
		{
			if(Engine0.activeInHierarchy)
			{
				Engine0.SetActive(false);
				Engine1.SetActive(true);
				UpgradeCostEngine += 10;
				UIController.Pickups -= UpgradeCostEngine;
			}

			if(Engine1.activeInHierarchy)
			{
				Engine1.SetActive(false);
				Engine2.SetActive(true);
				UpgradeCostEngine += 15;
				UIController.Pickups -= UpgradeCostEngine;
			}
		}
	}

	public void Next()
	{
		SpeedPlus = true;
	}

	public void Previous()
	{
		SpeedMin = true;
	}

	void FixedUpdate ()
	{
		Debug.Log (CanShop);
		Selection.transform.Translate(Vector3.right * Speed * Time.deltaTime);
		if (SpeedPlus == true)
		{
			Speed += 0.3f;

			if(Selection.transform.position.x > -1695f)
			{
				Speed = 0f;
				current++;
				WepIcon.SetActive (false);
				EngIcon.SetActive (true);
				SpeedPlus = false;
			}
		}


		if (SpeedMin == true)
		{
			Speed -= 0.3f;

			if(Selection.transform.position.x < -1720f)
			{
				Speed = 0f;
				current--;
				WepIcon.SetActive (true);
				EngIcon.SetActive (false);
				SpeedMin = false;
			}
		}


		if (CanShop == true)
		{
			if (Input.GetKey(KeyCode.E))
			{
				Pauze.Pause = true;
				Text.SetActive (false);
				ShopWindow.enabled = true;
				Camera1.enabled = false;
				Camera2.enabled = true;
			}
		}
	}
}
