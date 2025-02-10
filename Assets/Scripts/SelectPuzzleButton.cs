using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectPuzzleButton : MonoBehaviour
{

    public GameData gameData;
    public GameLevelData levelData;
    public TextMeshProUGUI categoryText;
    public Image progressBarFilling;

    private string gameSceneName = "GameScene";

    private bool _levelLocked;
    // Start is called before the first frame update
    void Start()
    {
        _levelLocked = false;
        var button=GetComponent<Button>();
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
        button.interactable = true;
        UpdateButtonInformation();
        if (_levelLocked)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateButtonInformation()
    {
        var currentIndex = -1;
        var totalBoards = 0;

        // Seviye verileri aras�nda ge�erek mevcut kategori hakk�nda bilgi al�yoruz.
        foreach (var data in levelData.data)
        {
            if (data.categoryName == gameObject.name)
            {
                currentIndex = DataSaver.ReadCategoryCurrentIndexValues(gameObject.name);
                totalBoards = data.boardData.Count;

                // E�er kategori i�in ge�erli bir index yoksa, bunu s�f�rl�yoruz.
                if (levelData.data[0].categoryName == gameObject.name && currentIndex < 0)
                {
                    DataSaver.SaveCategoryData(levelData.data[0].categoryName, 0);
                    currentIndex = DataSaver.ReadCategoryCurrentIndexValues(gameObject.name);
                    totalBoards=data.boardData.Count;
                }
            }
        }
        if (currentIndex == -1)
        {
            _levelLocked = true;
        }
        // Kategori metnini ve ilerleme �ubu�unu g�ncelliyoruz.
        categoryText.text=_levelLocked ? string.Empty : (currentIndex.ToString() + "/" + totalBoards.ToString());
        progressBarFilling.fillAmount = (currentIndex >0  && totalBoards >0) ? ((float)currentIndex/(float)totalBoards) : 0f;

    }

    private void OnButtonClick()
    {
        // Se�ilen kategoriyi ayarlay�p oyun sahnesini y�kl�yoruz.
        gameData.selectedCategoryName = gameObject.name;
        SceneManager.LoadScene(gameSceneName);
    }
}
