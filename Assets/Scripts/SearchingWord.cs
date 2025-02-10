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
        // Doðru kelime bulunduðunda çalýþacak olan metodu GameEvents.OnCorrectWord olayýna abone ediyoruz.
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
    // doðru kelime bulunduktan sonra çaðrýlan metod.
    private void CorrectWord(string word, List<int> squareIndexes)
    {
        if(word== _word)
        {
            // doðru kelime bulunduðu için kelimenin üzerindeki crossLine'ý active ediyoruz ki üzeri çizilsin
           crossLine.gameObject.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
