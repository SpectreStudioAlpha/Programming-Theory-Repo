using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }


    public static MainManager Instance { get; private set; } //singleton instance
    public Color TeamColor; //variable to store the team color


   
    private void Awake()
    {
        if (Instance != null) //check if an instance already exists
        {
            Destroy(gameObject); //destroy this instance if one already exists
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor(); //load the color when the game starts

    }

    

}
