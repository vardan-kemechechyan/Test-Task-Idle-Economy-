using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Configuration;

public class Business : MonoBehaviour
{
	BusinessDescription thisBusinessDescription;

	[SerializeField] NameController nController;
	[SerializeField] ProgressController pbController;
	[SerializeField] BusinessInfoController bController;
	[SerializeField] UpgradeController upgController;

	[SerializeField] TextMeshProUGUI incomeValueUI;

	#region Fields

	bool purchased;

	float finalIncome;

	#endregion

	#region Properties

	public bool Purchased
	{
		get { return purchased; }
		set 
		{ 
			purchased = value;
			pbController.BusinessPurchased= purchased;
		}
	}

	public float FinalIncome
	{
		get 
		{ 
			return finalIncome;
		}
		set 
		{
			finalIncome = value;
			incomeValueUI.text = value.ToString();
		}
	}

	#endregion

	public void InstantiateBusiness(BusinessDescription businessDescription)
	{
		thisBusinessDescription = businessDescription;

		pbController.Initialize(thisBusinessDescription.businessInfo.incomeDelay, thisBusinessDescription.businessInfo.progressBarValue);

		nController.BusinessName = thisBusinessDescription.businessName;

		if( !thisBusinessDescription.purchased )
			thisBusinessDescription.businessInfo.level = 0;

		bController.InstaniateBusinessController(thisBusinessDescription.businessInfo.level, thisBusinessDescription.businessInfo.baseIncome, thisBusinessDescription.businessInfo.baseCost);

		upgController.InstantiateUpgradables(thisBusinessDescription.businessInfo.Upgrades);

		Purchased = thisBusinessDescription.purchased;

		UpdateFinalIncome();
	}

	public void CalculateIncome()
	{
		CustomGameEventList.GenerateIncome( FinalIncome );
	}

	public void UpdateBusinessDescription() 
	{
		thisBusinessDescription.purchased = Purchased;
		thisBusinessDescription.businessInfo.progressBarValue = pbController.ProgressValue;
		thisBusinessDescription.businessInfo.level = bController.LevelValue;

		upgController.UpdateUpgradeDescriptions(thisBusinessDescription.businessInfo.Upgrades);
	}

	public void UpdateFinalIncome()
	{
		FinalIncome = bController.LevelValue * bController.BaseIncomeValue * upgController.UpgradeModifier;
		incomeValueUI.text = FinalIncome.ToString();
	}
}
