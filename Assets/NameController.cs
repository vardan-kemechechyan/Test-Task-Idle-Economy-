using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameController : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI businessNameUI;
	public string BusinessName
	{
		get 
		{ 
			return businessNameUI.text;
		}
		set 
		{
			businessNameUI.text = value;
		}
	}
}
