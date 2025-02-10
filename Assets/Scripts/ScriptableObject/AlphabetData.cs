using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class AlphabetData : ScriptableObject
{
    [System.Serializable]   // Unity tarafýnda görünür saðlamasý için kullandým
    public class LetterData
    {
        public string letter; // harfi temisl eder
        public Sprite image;  // temsil edilen harfin karþýlýðýndaki görseli temsil eder
    }

    public List<LetterData> AlphabetPlain= new List<LetterData>();
    public List<LetterData> AlphabetNormal = new List<LetterData>();
    public List<LetterData> AlphabetHighlighted = new List<LetterData>();
    public List<LetterData> AlphabetWrong = new List<LetterData>();

}
