using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Enums;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] BusinessManager bManager;
	[SerializeField] SaveSystem		 sManager; //change to event

	GameState currentGameState;
	public GameState CurrentGameState
	{
		get { return currentGameState; }
		set 
		{
			currentGameState = value;
			CustomGameEventList.ChangeGameState(currentGameState);
		}
	}

	void OnApplicationFocus(bool hasFocus)
	{
		if(!hasFocus)
		{
			bManager.SaveData();
			sManager.SaveData();
		}
	}

	private IEnumerator Start()
	{
		Application.targetFrameRate = 60;

		CurrentGameState = GameState.PAUSED;

		sManager.LoadData();

		yield return new WaitUntil(() => SaveSystem.SAVE_LOADED == true);

		bManager.InstantiateBusinesses();

		CurrentGameState = GameState.PLAYING;
	}
}
