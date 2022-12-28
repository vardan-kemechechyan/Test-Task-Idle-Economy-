using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BusinessInfoController : MonoBehaviour, IPurchasable
{
	[SerializeField] Business mBusiness;
	
	[SerializeField] TextMeshProUGUI levelValueUI;
	[SerializeField] TextMeshProUGUI levelUpCostValueUI;

	BusinessManager bManager;

	#region Fields

	int levelValue;
	float baseIncomeValue;
	float baselevelUpCost;

	#endregion

	#region Properties
	public int LevelValue
	{
		get { return levelValue; }
		set
		{
			levelValue = value;
			levelValueUI.text = value.ToString();
		}
	}

	public float BaseIncomeValue
	{
		get { return baseIncomeValue; } 
		set
		{
			baseIncomeValue = value;
		}
	}
	
	public float BaselevelUpCost
	{
		get { return baselevelUpCost; }
		set
		{
			baselevelUpCost =  value;
		}
	}

	public float FinalLevelUpCost
	{
		get { return (LevelValue + 1) * BaselevelUpCost; }
	}

	#endregion
	
	void UpdateLevelUpCostUI()
	{
		levelUpCostValueUI.text = $"cost: ${FinalLevelUpCost}";
	}
	
	public void InstaniateBusinessController(int level, float baseIncome, float baseCost )
	{
		LevelValue = level;
		BaseIncomeValue = baseIncome;
		BaselevelUpCost = baseCost;

		UpdateLevelUpCostUI();
	}

	public void Purchase()
	{
		if(bManager == null) bManager = BusinessManager.GetInstance();

		if(bManager.RequestPermissionToBuy( FinalLevelUpCost ))
		{
			LevelValue++;

			mBusiness.UpdateFinalIncome();
			mBusiness.Purchased = true;

			UpdateLevelUpCostUI();
		}
	}
}