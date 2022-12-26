using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Business : MonoBehaviour
{
	Configuration.BusinessDescription thisBusinessDescription;

	[SerializeField] NameController nController;
	[SerializeField] ProgressController pbController;
	[SerializeField] BusinessInfoController bController;
	[SerializeField] UpgradeController upgController;

	#region Fields
	string businessName;
	
	float progressValue;
	
	int levelValue;
	
	float incomeValue;
	
	float levelUpCostValue;
	#endregion

	#region Setters and Getters
	public string BusinessName
	{
		get { return businessName; }
		set 
		{
			businessName = value;
			nController.BusinessName = businessName;
		}
	}
	public float ProgressValue
	{
		get { return progressValue; }
		set 
		{ 
			progressValue = value;
			pbController.ProgressBar = progressValue;
		}
	}
	public int LevelValue
	{
		get { return levelValue; }
		set 
		{
			levelValue = value;
			bController.LevelValue = levelValue.ToString();
		}
	}
	public float IncomeValue
	{
		get { return incomeValue; }
		set
		{
			incomeValue = value;
			bController.IncomeValue = incomeValue.ToString();
		}
	}
	public float LevelUpCostValue
	{
		get { return levelUpCostValue; }
		set
		{
			levelUpCostValue = value;
			bController.LevelUpCostValue = levelUpCostValue.ToString();
		}
	}

	#endregion


	public void InstantiateBusiness()
	{
		
	}
}
