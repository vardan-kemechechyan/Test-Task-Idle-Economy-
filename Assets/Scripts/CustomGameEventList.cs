using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class CustomGameEventList : MonoBehaviour
{
	public static Action<GameState> ChangeGameState = delegate( GameState gState) { };
	public static Action<float> GenerateIncome = delegate(float money) { };
}
