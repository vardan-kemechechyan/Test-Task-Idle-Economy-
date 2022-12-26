using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI nameUI;
	[SerializeField] TextMeshProUGUI incomeUI;
	[SerializeField] TextMeshProUGUI levelupCostUI;
	public string NameUI
	{
		set
		{
			nameUI.text = value;
		}
	}
	public string IncomeUI
	{
		set
		{
			incomeUI.text = $"income: +{value}%";
		}
	}
	public string LevelupCostUI
	{
		set
		{
			levelupCostUI.text = $"cost: ${value}";
		}
	}
}
