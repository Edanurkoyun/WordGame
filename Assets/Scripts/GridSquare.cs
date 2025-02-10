using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEvents;

public class GridSquare : MonoBehaviour
{

    public int SquareIndex { get; set; }

    private AlphabetData.LetterData _normalLetterData; // Normal harf verisi.
    private AlphabetData.LetterData _selectedLetterData; // Se�ilen harf verisi.
    private AlphabetData.LetterData _correctLetterData; // Do�ru harf verisi.

    private SpriteRenderer _displayedImage;

    private bool _selected; // Bu, kullan�c�n�n kareyi se�ip se�medi�ini kontrol eder.
    private bool _clicked; // Bu,  kareye t�klan�ld���n� kontrol eder.
    private int _index = -1; // Bu karenin indeksini tuttar
    private bool _correct; // Bu harfin do�ru olup olmad���n� belirtir

    private AudioSource _source;
    public void SetIndex(int index)
    {
        _index = index;

    }
    public int GetIndex()
    {
        return _index;
    }
    // Start is called before the first frame update
    void Start()
    {
        _selected = false;
        _clicked = false;
        _correct = false;
        _displayedImage = GetComponent<SpriteRenderer>();
        _source = GetComponent<AudioSource>();
        
    }



    // Bu metot, kare se�ildi�inde tetiklenir
    private void OnEnable()
    {
        GameEvents.OnEnableSquareSelection += OnEnableSquareSelection;
        GameEvents.OnDisableSquareSelection += OnDisableSquareSelection;
        GameEvents.OnSelectSquare += SelectSquare;
        GameEvents.OnCorrectWord += CorrectWord;

        
    }
    // Bu metot, kare se�me i�lemini sonland�r�r.
    private void OnDisable()
    {
        GameEvents.OnEnableSquareSelection -= OnEnableSquareSelection;
        GameEvents.OnDisableSquareSelection -= OnDisableSquareSelection;
        GameEvents.OnSelectSquare -= SelectSquare;
        GameEvents.OnCorrectWord -= CorrectWord;
    }

    // Do�ru kelimeyi kontrol eden metot
    private void CorrectWord(string word, List<int> squareIndexes)
    {
        if(_selected && squareIndexes.Contains(_index))
        {
            _correct = true;
            _displayedImage.sprite = _correctLetterData.image;
        }
        _selected= false;
        _clicked= false;
    }



    // Kare se�imi yap�ld���nda �a�r�l�r
    public void OnEnableSquareSelection()
    {
        _clicked = true;
        _selected = false;
    }

    // Kare se�imi b�rak�ld���nda �a�r�l�r
    public void OnDisableSquareSelection()
    {
        _selected= false;
        _clicked= false;
        if (_correct == true)
        {
            _displayedImage.sprite = _correctLetterData.image;

        }
        else
        {
            _displayedImage.sprite=_normalLetterData.image;
        }
    }
    // Kareyi se�me i�lemi
    private void SelectSquare(Vector3 position)
    {
        if (this.gameObject.transform.position == position)   // E�er bu objenin pozisyonu belirtilen pozisyonla e�le�iyorsa
        {
            _displayedImage.sprite = _selectedLetterData.image; // se�ilen harfin g�rselini g�sterir
        }
    }


    // Update is called once per frame
    public void SetSprite(AlphabetData.LetterData normalLetterData, AlphabetData.LetterData selectedLetterData, AlphabetData.LetterData correctLetterData)
    {
        _normalLetterData = normalLetterData;
        _selectedLetterData = selectedLetterData;
        _correctLetterData = correctLetterData;

        GetComponent<SpriteRenderer>().sprite = _normalLetterData.image;

    }
    // Mouse t�klamas� ile kareyi se�me
    private void OnMouseDown()
    {
        OnEnableSquareSelection(); // kareyi se�me olay�n�n oldu�u method etkinle�tirilir.
        GameEvents.EnableSquareSelectionMethod();
        CheckSquare();
        _displayedImage.sprite=_selectedLetterData.image;

    }

    private void OnMouseEnter()
    {
        CheckSquare();
    }

    private void OnMouseUp()
    {
        GameEvents.ClearSelectionMethod();
        GameEvents.DisableSquareSelectionMethod();
    }
    // Kareyi kontrol eden metot
    public void CheckSquare()
    {
        if (_selected == false && _clicked==true)
        {
            if (SoundManager.instance.IsSoundFXMuted() == false)
            {
                _source.Play(); // kare se�me i�lemi ba�lad�ysa ses ba�lat�l�r
            }
            _selected = true;
            GameEvents.CheckSquareMethod(_normalLetterData.letter,gameObject.transform.position, _index);// karenin idexi kontrol edilir.
        }
    }


}
