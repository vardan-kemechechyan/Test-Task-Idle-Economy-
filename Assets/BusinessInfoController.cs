using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BusinessInfoController : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI levelValueUI;
	[SerializeField] TextMeshProUGUI incomeValueUI;
	[SerializeField] TextMeshProUGUI levelUpCostValueUI;
	public string LevelValue
	{
		set
		{
			levelValueUI.text = value;
		}
	}
	public string IncomeValue
	{
		set
		{
			incomeValueUI.text = value;
		}
	}
	public string LevelUpCostValue
	{
		set
		{
			levelUpCostValueUI.text = $"cost: ${value}";
		}
	}
}
