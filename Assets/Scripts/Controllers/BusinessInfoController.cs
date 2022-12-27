using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BusinessInfoController : MonoBehaviour
{
	[SerializeField] Business mBusiness;
	
	[SerializeField] TextMeshProUGUI levelValueUI;
	[SerializeField] TextMeshProUGUI levelUpCostValueUI;

	int levelValue;
	public int LevelValue
	{
		get { return levelValue; }
		set
		{
			levelValue = value;
			levelValueUI.text = value.ToString();
		}
	}

	float baseIncomeValue;
	public float BaseIncomeValue
	{
		get { return baseIncomeValue; } 
		set
		{
			baseIncomeValue = value;
		}
	}
	float baselevelUpCost;
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

	public void LevelUp()
	{
		LevelValue++;
		mBusiness.UpdateFinalIncome();
		UpdateLevelUpCostUI();
	}
}