using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static Configuration;

public class SaveSystem : Singleton<SaveSystem>
{
	[SerializeField] string json_save;
	[SerializeField] Configuration config;

	BusinessManager bManager;

	public static bool SAVE_LOADED = false;

	string savePath = "/playerJSONdata.idle";
	SaveStructure data;

	public SaveStructure LoadData()
	{
		if(bManager == null ) bManager = BusinessManager.GetInstance();

		data = new SaveStructure();

		if( !File.Exists(Application.persistentDataPath + savePath) )
		{
			PlayerPrefs.SetFloat(Enums.PlayerPrefSaveNames.PLAYER_MONEY.ToString(), 0f);
			PlayerPrefs.SetInt(Enums.PlayerPrefSaveNames.FIRST_LAUNCH.ToString(), 1);
			
			PlayerPrefs.Save();

			data.businessessInformation = config.ReturnBusinessDescriptions();

			json_save = JsonUtility.ToJson(data);
			File.WriteAllText(Application.persistentDataPath + savePath, json_save);
		}
		else
		{
			json_save = File.ReadAllText(Application.persistentDataPath + savePath);
			data = JsonUtility.FromJson<SaveStructure>(json_save);

			config.LoadBusinessDescriptions(data.businessessInformation);
		}

		SAVE_LOADED = true;

		return data;
	}

	public void SaveData()
	{
		bManager.PrepareDataToSave();

		data = new SaveStructure();
		data.businessessInformation = config.ReturnBusinessDescriptions();

		json_save = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + savePath, json_save);
	}

	public void DeleteSave(int deleteType)
	{
		if(File.Exists(Application.persistentDataPath + savePath))
		{
			if(deleteType == 0)
			{
				File.Delete(Application.persistentDataPath + savePath);
				PlayerPrefs.DeleteAll();
			}

			PlayerPrefs.Save();
		}
	}

	[System.Serializable]
	public class SaveStructure
	{
		public List<BusinessDescription> businessessInformation = new List<BusinessDescription>();
	}
}
