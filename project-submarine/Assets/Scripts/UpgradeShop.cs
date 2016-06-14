using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour {

	[SerializeField]
	private Canvas ShopWindow;
	[SerializeField]
	private GameObject Selection;
	[SerializeField]
	private GameObject Text;

	[SerializeField]
	private GameObject Weapon1;
	[SerializeField]
	private GameObject Weapon2;
	[SerializeField]
	private GameObject Weapon3;

	[SerializeField]
	private GameObject WeaponE0;
	[SerializeField]
	private GameObject WeaponE1;
	[SerializeField]
	private GameObject WeaponE2;
	[SerializeField]
	private GameObject WeaponE3;

	[SerializeField]
	private GameObject Engine1;
	[SerializeField]
	private GameObject Engine2;
	[SerializeField]
	private GameObject Engine3;

	[SerializeField]
	private GameObject EngineE0;
	[SerializeField]
	private GameObject EngineE1;
	[SerializeField]
	private GameObject EngineE2;
	[SerializeField]
	private GameObject EngineE3;

	[SerializeField]
	private GameObject EngIcon;
	[SerializeField]
	private GameObject WepIcon;

	[SerializeField]
	private int UpgradeCostWeapon;
	[SerializeField]
	private int UpgradeCostEngine;

	[SerializeField]
	private Text Desc;

	[SerializeField]
	private Camera Camera1;
	[SerializeField]
	private Camera Camera2;


	private int current = 0;
	private bool SpeedPlus;
	private bool SpeedMin;
	public static bool CanShop;
	private float Speed;
	private string currentWepDesc;
	private string currentEngDesc;

	[SerializeField]
	private GameObject player;
	private PlayerMovement playerMovement;


	void Awake()
	{
		currentWepDesc = "+ 10 Damage";
		currentEngDesc = "+ turning speed";
		Desc.text = currentWepDesc;
		playerMovement = player.GetComponent<PlayerMovement> ();
		ShopWindow.enabled = false;
//		Camera1.enabled = true;
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

	public void Upgrade()
	{
		playerMovement.UpgradeEngine ();
		if (UIController.Pickups >= UpgradeCostWeapon && current == 0)
		{
			if (Weapon1.activeInHierarchy) {
				WeaponE0.SetActive (false);
				WeaponE1.SetActive (true);
				Weapon1.SetActive (false);
				Weapon2.SetActive (true);
				UIController.Pickups -= UpgradeCostWeapon;
				UpgradeCostWeapon += 10;
			}
		}
		if(UIController.Pickups >= UpgradeCostWeapon && current == 0)
		{
			if(Weapon2.activeInHierarchy)
			{
				WeaponE1.SetActive (false);
				WeaponE2.SetActive (true);
				Weapon2.SetActive(false);
				Weapon3.SetActive(true);
				UIController.Pickups -= UpgradeCostWeapon;
				UpgradeCostWeapon += 15;
			}
		}
		if(UIController.Pickups >= UpgradeCostWeapon && current == 0)
		{
			if(Weapon3.activeInHierarchy)
			{
				WeaponE2.SetActive (false);
				WeaponE3.SetActive (true);
				Weapon3.SetActive(false);
				SpeedPlus = true;
				UIController.Pickups -= UpgradeCostWeapon;
			}
		}

		if (UIController.Pickups >= UpgradeCostEngine && current == 1)
		{
			if (Engine1.activeInHierarchy) {
				EngineE0.SetActive (false);
				EngineE1.SetActive (true);
				Engine1.SetActive (false);
				Engine2.SetActive (true);
				UIController.Pickups -= UpgradeCostEngine;
				UpgradeCostEngine += 10;
			}
		}
		if(UIController.Pickups >= UpgradeCostEngine && current == 1)
		{
			if(Engine2.activeInHierarchy)
			{
				EngineE1.SetActive (false);
				EngineE2.SetActive (true);
				Engine2.SetActive(false);
				Engine3.SetActive(true);
				UIController.Pickups -= UpgradeCostEngine;
				UpgradeCostEngine += 15;
			}
		}
		if(UIController.Pickups >= UpgradeCostEngine && current == 1)
		{
			if(Engine3.activeInHierarchy)
			{
				EngineE2.SetActive (false);
				EngineE3.SetActive (true);
				Engine3.SetActive(false);
				SpeedMin = true;
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
		Selection.transform.Translate(Vector3.right * Speed * Time.deltaTime);
		if (SpeedPlus == true)
		{
			Speed += 0.3f;

			if(Selection.transform.position.x > -1695f)
			{
				Desc.text = currentEngDesc;
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

			if(Selection.transform.position.x < -1720.6f)
			{
				Desc.text = currentWepDesc;
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
