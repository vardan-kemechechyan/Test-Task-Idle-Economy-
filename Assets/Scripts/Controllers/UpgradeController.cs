using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BusinessDescription;
using static Configuration;

public class UpgradeController : MonoBehaviour
{
	[SerializeField] Business mBusiness;

	[SerializeField] UpgradeButton upgradeButtonPrefab;
	[SerializeField] List<UpgradeButton> upgradeButtons;

	float upgradeModifier;
	public float UpgradeModifier
	{
		get 
		{		
			return upgradeModifier;
		}
		set
		{
			upgradeModifier = 1 + value;

			mBusiness.UpdateFinalIncome();
		}
	}

	public void InstantiateUpgradables(List<UpgradeInfo> upgrades)
	{
		upgradeButtons = new List<UpgradeButton>();

		for(int i = 0; i < upgrades.Count; i++)
		{
			upgradeButtons.Add(Instantiate(upgradeButtonPrefab, transform));
			upgradeButtons[i].Instantiate( upgrades[i] );	
		}

		UpdateUpgradeModifier();
	}

	public void UpdateUpgradeModifier()
	{
		float modifier = 0;

		foreach(var upg in upgradeButtons)
			modifier += upg.Income;

		UpgradeModifier = modifier;
	}

	public void UpdateUpgradeDescriptions( List<UpgradeInfo> upgradelist)
	{
		for(int i = 0; i < upgradeButtons.Count; i++)
		{
			if(upgradeButtons[i].UpgradeName == upgradelist[0].upgradeName)
			{
				upgradelist[0].purchasedStatus = upgradeButtons[i].UpgradeStatus;
				continue;
			}
		}
	}
}
