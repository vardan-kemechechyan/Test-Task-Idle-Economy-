using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

[CreateAssetMenu]
public class Configuration : ScriptableObject
{
    [SerializeField] List<BusinessDescription> AvailableBusiness;

	[System.Serializable]
	public class BusinessDescription
    {
        public int id;
		public string businessName;
        public bool purchased;
        public BusinessInfo businessInfo;
    }

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
        public int id;
		public string upgradeName;
        public float cost;
        public float incomeRate;
        public bool purchasedStatus;
    }

	public List<BusinessDescription> ReturnBusinessDescriptions()
	{
		return AvailableBusiness;
	}

    public void LoadBusinessDescriptions( List<BusinessDescription> saveFile)
    {
        for(int i = 0; i < saveFile.Count; i++)
        {
			AvailableBusiness[i] = saveFile[i];

			AvailableBusiness[i].purchased = saveFile[i].purchased;
			AvailableBusiness[i].businessInfo.progressBarValue = saveFile[i].businessInfo.progressBarValue;
            AvailableBusiness[i].businessInfo.level = saveFile[i].businessInfo.level;

			for(int j = 0; j < saveFile[i].businessInfo.Upgrades.Count; j++)
			{
				if(AvailableBusiness[i].businessInfo.Upgrades[j].id == saveFile[i].businessInfo.Upgrades[j].id)
				{
					AvailableBusiness[i].businessInfo.Upgrades[j].purchasedStatus = saveFile[i].businessInfo.Upgrades[j].purchasedStatus;
					continue;
				}
			}
		}
    }
}
