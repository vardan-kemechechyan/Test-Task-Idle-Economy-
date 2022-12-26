using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Configuration : ScriptableObject
{
    [SerializeField] List<BusinessDescription> AvailableBusiness;

	[System.Serializable]
	public class BusinessDescription
    {
        public string businessName;
        public BusinessInfo businessInfo;
    }

	[System.Serializable]
    public class BusinessInfo
    {
		public float incomeDelay;
		public float baseCost;
		public float baseIncome;
        public float progressBarValue;
		public UpgradeInfo Upgrade1;
		public UpgradeInfo Upgrade2;
	}

	[System.Serializable]
    public struct UpgradeInfo
    {
        public float cost;
        public float incomeRate;
        public bool purchasedStatus;
    }
}
