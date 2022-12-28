using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SaveSystem))]
public class SaveSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var script = (SaveSystem)target;

        #region Delete Saves

        var style = new GUIStyle(GUI.skin.button)
        {
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold,
            fixedHeight = 40f
        };

        style.normal.textColor = Color.red;

        if(GUILayout.Button("Delete All Saves", style))
        {
            script.DeleteSave(0);
        }

		#endregion

		#region Save

		var style2 = new GUIStyle(GUI.skin.button)
		{
			alignment = TextAnchor.MiddleCenter,
			fontStyle = FontStyle.Bold,
			fixedHeight = 40f
		};

		style2.normal.textColor = Color.green;

		if(GUILayout.Button("Save", style2))
		{
			script.SaveData();
		}

		#endregion
	}
}
#endif