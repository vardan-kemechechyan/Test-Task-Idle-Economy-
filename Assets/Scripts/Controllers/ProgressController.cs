using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour, ISubscribeUnsubscribe
{
	[SerializeField] Business mBusiness;
	[SerializeField] Image progressbarUI;

	float progressValue;
	float incomeDelay;
	bool businessPurchased;
	Enums.GameState currentGameState;

	public float ProgressValue
	{
		get	{ return progressValue; }
		set
		{
			progressValue = value;

			if(progressValue >= 1)
			{
				progressValue = 0;

				mBusiness.CalculateIncome();
			}

			progressbarUI.fillAmount = progressValue;
		}
	}
	public float IncomeDelay
	{
		get { return incomeDelay; }
		set 
		{
			incomeDelay = value;
		}
	}

	public bool BusinessPurchased
	{
		get { return businessPurchased; }
		set
		{
			businessPurchased = value;
		}
	}

	public Enums.GameState CurrentGameState
	{
		get { return currentGameState; }
		set 
		{
			currentGameState = value;
		}
	}

	void ChangeGameState( Enums.GameState gState )
	{ 
		CurrentGameState = gState;
	}

	public void Initialize( float incomeDelayTime, float progressBarValue)
	{
		IncomeDelay = incomeDelayTime;
		ProgressValue = progressBarValue;

		CurrentGameState = Enums.GameState.PAUSED;

		Subscribe();
	}

	private void OnDestroy()
	{
		UnSubscribe();
	}

	private void OnDisable()
	{
		UnSubscribe();
	}

	private void Update()
	{
		if(BusinessPurchased)
			if ( CurrentGameState == Enums.GameState.PLAYING && BusinessPurchased )
				ProgressValue +=  Time.deltaTime / IncomeDelay;
	}

	public void Subscribe()
	{
		CustomGameEventList.ChangeGameState += ChangeGameState;
	}

	public void UnSubscribe()
	{
		CustomGameEventList.ChangeGameState -= ChangeGameState;
	}
}
