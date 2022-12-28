using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Configuration;

public class UpgradeButton : MonoBehaviour, IPurchasable
{
	[SerializeField] TextMeshProUGUI nameUI;
	[SerializeField] TextMeshProUGUI incomeUI;
	[SerializeField] TextMeshProUGUI levelupCostUI;
	[SerializeField] Button button;

	UpgradeController pUpgController;
	BusinessManager bManager;

	#region Fields

	int id;
	bool upgradeStatus;
	string upgradeName;
	float income;
	float levelupCost;

	#endregion

	#region Properties
	public bool UpgradeStatus
	{
		get { return upgradeStatus; }
		set
		{
			upgradeStatus = value;
			button.interactable = !value;
			levelupCostUI.text = "BOUGHT";
		}
	}

	public string UpgradeName
	{
		get { return upgradeName; }
		set
		{
			upgradeName = value;
			nameUI.text = value;
		}
	}
	public int ID
	{
		get { return id; }
		set
		{
			id = value;
		}
	}

	public float Income
	{
		get { return income / 100 * (UpgradeStatus ? 1 : 0); }
		set
		{
			income = value;
			incomeUI.text = $"income: +{value}%";
		}
	}

	public float LevelupCost
	{
		get { return levelupCost; }
		set
		{
			levelupCost = value;
			levelupCostUI.text = $"cost: ${value}";
		}
	}

	#endregion
	
	
	public void Instantiate( UpgradeInfo upgrade)
	{
		button = GetComponent<Button>();
		button.onClick.AddListener( Purchase );

		UpgradeStatus = upgrade.purchasedStatus;
		UpgradeName = upgrade .upgradeName;
		Income = upgrade.incomeRate;
		LevelupCost = upgrade.cost;
		ID = upgrade.id;

		pUpgController = transform.parent.GetComponent<UpgradeController>();
	}

	public void Purchase()
	{
		if( UpgradeStatus ) return;

		if(bManager == null) bManager = BusinessManager.GetInstance();

		if(bManager.RequestPermissionToBuy( LevelupCost ) )
		{
			UpgradeStatus = true;

			pUpgController.UpdateUpgradeModifier();
		}
	}
}
