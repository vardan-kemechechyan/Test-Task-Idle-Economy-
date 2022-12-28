using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Enums;

public class GameManager : MonoBehaviour
{
	[SerializeField] BusinessManager bManager;
	[SerializeField] SaveSystem		 sManager;

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
		{
			bManager.PrepareDataToSave();
			sManager.SaveData();

			print("out of focus");
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
