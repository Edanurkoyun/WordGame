using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchingWord : MonoBehaviour
{
   public TextMeshProUGUI displayedText;
    public Image crossLine; // 

    private string _word;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        // Do�ru kelime bulundu�unda �al��acak olan metodu GameEvents.OnCorrectWord olay�na abone ediyoruz.
        GameEvents.OnCorrectWord += CorrectWord;
    }
    private void OnDisable()
    {
        GameEvents.OnCorrectWord -= CorrectWord;
    }

    public void SetWord(string word)
    {
        _word = word;
        displayedText.text = word;
    }
    // do�ru kelime bulunduktan sonra �a�r�lan metod.
    private void CorrectWord(string word, List<int> squareIndexes)
    {
        if(word== _word)
        {
            // do�ru kelime bulundu�u i�in kelimenin �zerindeki crossLine'� active ediyoruz ki �zeri �izilsin
           crossLine.gameObject.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
