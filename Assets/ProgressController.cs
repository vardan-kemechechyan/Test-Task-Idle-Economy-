using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour
{
	[SerializeField] Image progressbarUI;
	public float ProgressBar
	{
		get
		{
			return progressbarUI.fillAmount;
		}
		set
		{
			progressbarUI.fillAmount = value;
		}
	}
}
