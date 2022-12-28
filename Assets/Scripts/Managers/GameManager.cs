using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Enums;
using Unity.VisualScripting.FullSerializer;

public class GameManager : Singleton<GameManager>
{
	BusinessManager bManager;
	SaveSystem		 sManager;

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
		print("out of focus");

		if(!hasFocus)
			sManager.SaveData();
	}

	private IEnumerator Start()
	{
		Application.targetFrameRate = 60;

		bManager = BusinessManager.GetInstance();
		sManager = SaveSystem.GetInstance();

		CurrentGameState = GameState.PAUSED;

		sManager.LoadData();

		yield return new WaitUntil(() => SaveSystem.SAVE_LOADED == true);

		bManager.InstantiateBusinesses();

		CurrentGameState = GameState.PLAYING;
	}
}
