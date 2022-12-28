using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Configuration;

public class BusinessManager : Singleton<BusinessManager>, ISubscribeUnsubscribe
{
	[SerializeField] Configuration config;
	[SerializeField] Business businessPrefab;
	[SerializeField] Transform businessesParent;
	[SerializeField] TextMeshProUGUI balanceUI;

	List<Business> AllBusiness;
	List<BusinessDescription> AlleBusinessDescriptions;

	float playerBalance;
	public float PlayerBalance
	{
		get
		{
			return playerBalance;
		}
		set
		{
			playerBalance = value;
			balanceUI.text = $"Balance: ${playerBalance}";
		}
	}

	public void InstantiateBusinesses()
	{
		PlayerBalance = PlayerPrefs.GetFloat(Enums.PlayerPrefSaveNames.PLAYER_MONEY.ToString());

		Subscribe();

		AlleBusinessDescriptions = new List<BusinessDescription>();
		AlleBusinessDescriptions = config.ReturnBusinessDescriptions();

		AllBusiness = new List<Business>();

		foreach(var businessDescription in AlleBusinessDescriptions)
		{
			var business = Instantiate(businessPrefab, businessesParent);
			business.InstantiateBusiness(businessDescription);
			AllBusiness.Add(business);
		}
	}

	void IncreasePlayerBalance(float income)
	{
		PlayerBalance += income;
	}

	public bool RequestPermissionToBuy( float price )
	{
		if( PlayerBalance < price ) return false;

		PlayerBalance -= price;

		return true;
	}
	public void PrepareDataToSave()
	{
		foreach(var business in AllBusiness)
			business.UpdateBusinessDescription();

		PlayerPrefs.SetFloat(Enums.PlayerPrefSaveNames.PLAYER_MONEY.ToString(), PlayerBalance);
		PlayerPrefs.Save();
	}

	private void OnDestroy()
	{
		UnSubscribe();
	}

	private void OnDisable()
	{
		UnSubscribe();
	}

	public void Subscribe()
	{
		CustomGameEventList.GenerateIncome += IncreasePlayerBalance;
	}

	public void UnSubscribe()
	{
		CustomGameEventList.GenerateIncome -= IncreasePlayerBalance;
	}
}
