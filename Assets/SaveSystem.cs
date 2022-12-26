using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : Singleton<SaveSystem>
{
	SaveStructure data;

	protected override void Awake()
	{
		base.Awake();


	}

	private void Start()
	{
		
	}

	private void OnApplicationPause(bool pause)
	{
		
	}

	private void OnApplicationQuit()
	{
		
	}

	public SaveStructure GetData()
	{
		return data;
	}

	public class SaveStructure
	{
		public int balance;
		public List<Configuration.BusinessDescription> purchasedBusiness;
	}
}
