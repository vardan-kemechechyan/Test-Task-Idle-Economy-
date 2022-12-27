using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	public void InstantiateUpgradables(List<Configuration.UpgradeInfo> upgrades)
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
}
