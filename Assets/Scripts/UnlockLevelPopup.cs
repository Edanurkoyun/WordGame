using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameEvents;


public class UnlockLevelPopup : MonoBehaviour
{
    [System.Serializable]   // tanýmladýðým deðerler inspector penceresinde görünsün diye bunu yazdým

    public struct CategoryName
    {
        public string name;
        public Sprite sprite;
    };

    public GameData currentGameData;
    public List<CategoryName> categoryNames;
    public GameObject winPopup;
    public Image categoryNameImage;
    // Start is called before the first frame update
    void Start()
    {
        winPopup.SetActive(false);

        GameEvents.OnUnlockNextCategory += OnUnlockNextCategory;
    }
    private void OnDisable()
    {
        GameEvents.OnUnlockNextCategory -= OnUnlockNextCategory;
    }
    // Kategoriyi açma iþlemi yapýldýðýnda tetiklenen metot yani bir önceki kategoride çözmek için kategori kalmadýðýnda
    private void OnUnlockNextCategory()
    {
        bool captureNext=false;
        foreach(var writing in categoryNames)
        {
            if(captureNext) 
            { 
            categoryNameImage.sprite=writing.sprite;
            captureNext = false;
                break;
            }
            if (writing.name == currentGameData.selectedCategoryName)
            {
                captureNext = true;
            }
        }
        // Kazanma popup'ýný göster
        winPopup.SetActive(true);
    }




}
