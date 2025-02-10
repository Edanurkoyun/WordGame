using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class BoardData : ScriptableObject
{
    [System.Serializable]
    public class SearchingWord
    {
        [HideInInspector]
        public bool Found=false;
        public string Word;
    }
    [System.Serializable]

    // "BoardRow" s�n�f�, oyun tahtas�n�n her bir sat�r�n� temsil eder.
    public class BoardRow
    {
        public int Size;
        public string[] Row;
        public BoardRow() {}
        // Boyut verilerek sat�r olu�turulabilir.
        public BoardRow(int size) 
        {
            CreateRow(size);
        }
        // Yeni bir oyun tahtas� olu�turur (sat�r ve s�tun say�s�na g�re).
        public void CreateRow(int size)
        {
            Size= size;
            Row = new string[Size];
            ClearRow();
        }
       

        public void ClearRow()
        {
            for(int i = 0; i < Size; i++)
            {
                Row[i] = " ";
            }
        }
    }

    public float timeInSeconds;
    public int Columns = 0;
    public int Rows = 0;

    public BoardRow[] Board;

    public List<SearchingWord> SearchWords = new List<SearchingWord>();


    public void ClearWithEmptyString()
    {
        for(int i = 0;i < Columns; i++)
        {
            Board[i].ClearRow();
        }
    }

    public void CreateNewBoard()
    {
        Board= new BoardRow[Columns];
        for(int i = 0; i < Columns; i++)
        {
            Board[i]= new BoardRow(Rows);
        }
    }

    public void ClearData()
    {
        foreach(var word in SearchWords)
        {
            word.Found = false;  // Her kelimenin bulunma durumunu s�f�rlar.
        }
    }
}
