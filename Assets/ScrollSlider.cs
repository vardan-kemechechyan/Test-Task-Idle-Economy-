using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollSlider : MonoBehaviour
{
	//small value check against to see if floats match
	private const float LABDA = 0.0001f;

	[SerializeField] private Scrollbar _scrollbar;

	private void Awake()
	{
		_scrollbar.size = 0;
	}

	public void OnScrollbarChanged()
	{
		_scrollbar.size = 0;
	}
}
