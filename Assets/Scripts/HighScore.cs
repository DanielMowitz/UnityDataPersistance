using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScore : MonoBehaviour
{
    public static HighScore Instance;
	 public int Score = 0;
	 public string HighScoreName = "";

	 private void Awake()
    {
		if (Instance != null)
    	{
			Destroy(gameObject);
			return;
    	}

		LoadHighScore();

		Instance = this;
      DontDestroyOnLoad(gameObject);
    }

	 [System.Serializable]
	 class SaveData
	 {
		public int Score;
		public string HighScoreName;
	 }

	 public void SaveHighScore()
	 {
		SaveData data = new SaveData();
		data.Score = Score;
		data.HighScoreName = HighScoreName;

		string serialized = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/savefile.json", serialized);
	 }

	 public void LoadHighScore()
	 {
		string path = Application.persistentDataPath + "/savefile.json";
    	if (File.Exists(path))
    	{
			string serialized = File.ReadAllText(path);
        	SaveData data = JsonUtility.FromJson<SaveData>(serialized);

			Score = data.Score;
			HighScoreName = data.HighScoreName;
    	}
	 }
}
