using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static GameEvents;

public static class GameEvents
{
   // Kare se�im etkinle�tirildi�inde �al��acak olay
    public delegate void EnableSquareSelection();
    public static event EnableSquareSelection OnEnableSquareSelection;
    public static void EnableSquareSelectionMethod()
    {
        if (OnEnableSquareSelection != null)
        {
            OnEnableSquareSelection();
        }
    }
    //******
    // Kare se�im b�rak�ld���nda �al��acak 
    public delegate void DisableSquareSelection();
    public static event DisableSquareSelection OnDisableSquareSelection;
    public static void DisableSquareSelectionMethod()
    {
        if (OnDisableSquareSelection != null)
        {
            OnDisableSquareSelection();
        }
        //******
    }

    //Kare se�imi  belirli bir pozisyon verildi�inde �al��acak 
    public delegate void SelectSquare(Vector3 position);
    public static event SelectSquare OnSelectSquare;
    public static void SelectSquareMethod(Vector3 position)
    {
        if (OnSelectSquare != null)
        {
            OnSelectSquare(position);
        }
        //******
    }
    //Kareyi kontrol etmek i�in �a�r�lacak bir olay(harf, pozisyon ve indeksle)
    public delegate void CheckSquare(string letter, Vector3 squarePosition, int squareIndex);
    public static event CheckSquare OnCheckSquare;
    public static void CheckSquareMethod(string letter, Vector3 squarePosition, int squareIndex)
    {
        if (OnCheckSquare != null)
        {
            OnCheckSquare(letter,squarePosition,squareIndex);
        }
        //******
    }

    //Se�imi temizleme olay�n� tetikleyen metot
    public delegate void ClearSelection();
    public static event ClearSelection OnClearSelection;
    public static void ClearSelectionMethod()
    {
        if (OnClearSelection != null)
        {
            OnClearSelection();
        }
        //******
    }
    //Do�ru kelime bulundu�unda �al��acak olay (kelime ve kare indeksleri ile)
    public delegate void CorrectWord(string word,List<int> squareIndexes);
    public static event CorrectWord OnCorrectWord;
    public static void CorrectWordMethod(string word, List<int> squareIndexes)
    {
        if(OnCorrectWord != null)
        {
            OnCorrectWord(word,squareIndexes);
        }
    }
    //******
    //Board (tahta) tamamland���nda �al��acak olay
    public delegate void BoardCompleted();
    public static event BoardCompleted OnBoardCompleted;
    public static void BoardCompletedMethod()
    {
        if (OnBoardCompleted != null)
        {
            OnBoardCompleted();
        }
        //******
    }
    //  Sonraki kategoriyi a�may� tetikleyen metot
    public delegate void UnlockNextCategory();
    public static event UnlockNextCategory OnUnlockNextCategory;
    public static void UnlockNextCategoryMethod()
    {
        if (OnUnlockNextCategory != null)
        {
            OnUnlockNextCategory();
        }
        //******
    }

    // Sonraki seviyeyi y�kleme olay�n� �a��ran metot
    public delegate void LoadNextLevel();
    public static event LoadNextLevel OnLoadNextLevel;
    public static void LoadNextLevelMethod()
    {
        if (OnLoadNextLevel != null)
        {
            OnLoadNextLevel();
        }
        //******
    }
    //Oyun sona erdi�inde �al��acak olan metod
    public delegate void GameOver();
    public static event GameOver OnGameOver;
    public static void GameOverMethod()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
        //******
    }
    //Ses efektlerinin kontrol�n�n yap�ld��� metod
    public delegate void ToggleSoundFX();
    public static event ToggleSoundFX OnToggleSoundFX;
    public static void OnToggleSoundFXMethod()
    {
        if (OnToggleSoundFX != null)
        {
            OnToggleSoundFX();
        }
        //******
    }

}


