using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI nameUI;
	[SerializeField] TextMeshProUGUI incomeUI;
	[SerializeField] TextMeshProUGUI levelupCostUI;

	bool upgradeStatus;
	public bool UpgradeStatus
	{
		get { return upgradeStatus; }
		set
		{
			upgradeStatus = value;
		}
	}

	string upgradeName;
	public string UpgradeName
	{
		get { return upgradeName; }
		set
		{
			upgradeName = value;
			nameUI.text = value;
		}
	}

	float income;
	public float Income
	{
		get { return income; }
		set
		{
			income = value/100 * ( UpgradeStatus ? 1 : 0 ) ;
			incomeUI.text = $"income: +{value}%";
		}
	}

	float levelupCost;
	public float LevelupCost
	{
		get { return levelupCost; }
		set
		{
			levelupCost = value;
			levelupCostUI.text = $"cost: ${value}";
		}
	}

	public void Instantiate( Configuration.UpgradeInfo upgrade)
	{
		UpgradeStatus = upgrade.purchasedStatus;
		UpgradeName = upgrade .upgradeName;
		Income = upgrade.incomeRate;
		LevelupCost = upgrade.cost;
	}
}
