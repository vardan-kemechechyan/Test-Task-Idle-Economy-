using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Resizes a UI element with a RectTransform to respect the safe areas of the current device.
/// This is particularly useful on an iPhone X, where we have to avoid the notch and the screen
/// corners.
/// 
/// The easiest way to use it is to create a root Canvas object, attach this script to a game object called "SafeAreaContainer"
/// that is the child of the root canvas, and then layout the UI elements within the SafeAreaContainer, which
/// will adjust size appropriately for the current device./// </summary>
public class PinToSafeArea : MonoBehaviour
{
	private Rect lastSafeArea;
	private RectTransform parentRectTransform;

	private CanvasScaler canvasScaler;
	private float topUnits;

	private void Start()
	{
		parentRectTransform = GetComponentInParent<RectTransform>();

		canvasScaler = FindObjectOfType<CanvasScaler>();
		ApplyVerticalSafeArea();
	}

	private void Update()
	{
		if(lastSafeArea != Screen.safeArea)
		{
			ApplyVerticalSafeArea();
		}
	}

	private void ApplyVerticalSafeArea()
	{
		lastSafeArea = Screen.safeArea;

		var topPixel = Screen.currentResolution.height - (Screen.safeArea.y + Screen.safeArea.height);

		var topRatio = topPixel / Screen.currentResolution.height;

		var referenceResolution = canvasScaler.referenceResolution;
		topUnits = referenceResolution.y * topRatio;

		var rectTransform = GetComponent<RectTransform>();

		rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, 0);
		rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -topUnits);
	}
}