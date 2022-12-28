using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BusinessDescription : ScriptableObject
{
	public string businessName;
	public bool purchased;
	public BusinessInfo businessInfo;

	[System.Serializable]
	public class BusinessInfo
	{
		public int level;
		public float incomeDelay;
		public float baseCost;
		public float baseIncome;
		public float progressBarValue;
		public List<UpgradeInfo> Upgrades;
	}

	[System.Serializable]
	public class UpgradeInfo
	{
		public string upgradeName;
		public float cost;
		public float incomeRate;
		public bool purchasedStatus;
	}
}
