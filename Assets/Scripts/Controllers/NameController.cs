using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameController : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI businessNameUI;
	string businessName;
	public string BusinessName
	{
		get 
		{
			return businessName;
		}
		set 
		{
			businessName = value;
			businessNameUI.text = value;
		}
	}
}
