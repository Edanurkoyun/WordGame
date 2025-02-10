using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{

    // Kategorinin mevcut indeks de�erini okur
    public static int ReadCategoryCurrentIndexValues(string name)
    {
        var value = -1;
        if (PlayerPrefs.HasKey(name))
        {
            value = PlayerPrefs.GetInt(name);
          
        }
        return value;
    }

    public static void SaveCategoryData(string categoryName, int currentIndex)
    {
        PlayerPrefs.SetInt(categoryName, currentIndex);
        PlayerPrefs.Save();
    }

    public static void ClearGameData(GameLevelData levelData)
    {
        foreach(var data in levelData.data)
        {
            PlayerPrefs.SetInt(data.categoryName, -1);
        }
        // Birinci Leveli Kitleme t�m oyunlar bitti�i i�in
        PlayerPrefs.SetInt(levelData.data[0].categoryName, 0);
        PlayerPrefs.Save();
    }
}
