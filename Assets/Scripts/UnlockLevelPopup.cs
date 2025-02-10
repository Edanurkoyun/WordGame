using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameEvents;


public class UnlockLevelPopup : MonoBehaviour
{
    [System.Serializable]   // tan�mlad���m de�erler inspector penceresinde g�r�ns�n diye bunu yazd�m

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
    // Kategoriyi a�ma i�lemi yap�ld���nda tetiklenen metot yani bir �nceki kategoride ��zmek i�in kategori kalmad���nda
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
        // Kazanma popup'�n� g�ster
        winPopup.SetActive(true);
    }




}
