using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSelector : MonoBehaviour
{
    public GameData currentGameData;
    public GameLevelData levelData;

    // Start is called before the first frame update
    void Awake()
    {
        SelectSequentalBoardData();
    }

 private void SelectSequentalBoardData()
    {
        foreach(var data in levelData.data)
        {
            if(data.categoryName == currentGameData.selectedCategoryName)
            {
                // Seçilen kategoriye ait mevcut board indeksini okuyoruz. Bu deðer, oyuncunun o anki seviyesini belirtir.
                var boardIndex = DataSaver.ReadCategoryCurrentIndexValues(currentGameData.selectedCategoryName);
                if (boardIndex < data.boardData.Count)
                {
                    currentGameData.selectedBoardData = data.boardData[boardIndex];
                }
                else
                {
                    var randomIndex=Random.Range(0,data.boardData.Count);
                    currentGameData.selectedBoardData = data.boardData[randomIndex];
                }
            }
        }
    }
}
