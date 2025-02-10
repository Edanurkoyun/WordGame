using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class AlphabetData : ScriptableObject
{
    [System.Serializable]   // Unity taraf�nda g�r�n�r sa�lamas� i�in kulland�m
    public class LetterData
    {
        public string letter; // harfi temisl eder
        public Sprite image;  // temsil edilen harfin kar��l���ndaki g�rseli temsil eder
    }

    public List<LetterData> AlphabetPlain= new List<LetterData>();
    public List<LetterData> AlphabetNormal = new List<LetterData>();
    public List<LetterData> AlphabetHighlighted = new List<LetterData>();
    public List<LetterData> AlphabetWrong = new List<LetterData>();

}
