using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScene : MonoBehaviour
{

    public GameLevelData levelData;

    public void ClearGameData()
    {
        DataSaver.ClearGameData(levelData);
        //��zd���m�z Kelimelerin Datalar�n� s�f�rl�yoruz burada
    }

   
}
