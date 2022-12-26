using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessManager : Singleton<BusinessManager>
{
	[SerializeField] Configuration Config;
	[SerializeField] Business businessPrefab;
	
	Dictionary<string, Configuration.BusinessInfo> Availablebusinesses;

	List<Business> AllActiveBusiness = new List<Business>();

	public void LoadBusinessFromTheSaveFile()
	{
		
	}

	public void InstantiateBusinesses()
	{
		
	}
}
