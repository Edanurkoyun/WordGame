using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingWordList : MonoBehaviour
{
    public GameData currentGameData;
    public GameObject searchingWordPrefab;
    public float offset = 0.0f;  // Kelimeler aras�ndaki bo�luk mesafesi.
    public int maxColumns = 5;
    public int maxRows = 4;

    private int _columns = 2;
    private int _rows;
    private int _wordsNumber;

    private List<GameObject> _words= new List<GameObject>();// Olu�turulacak kelime nesnelerinin listesi.
     // Start is called before the first frame update
    private  void Start()
    {
        _wordsNumber = currentGameData.selectedBoardData.SearchWords.Count;
        if (_wordsNumber < _columns)
        {
            _rows = 1;
        }
        else
        {
            CalculateColumnsAndRowsNumber();
        }
        CreateWordObject();// Kelime nesnelerini olu�tur.
        SetWordsPosition(); // Kelimeleri do�ru pozisyonlara yerle�tir.
    }
    //Maksimum sat�r say�s�ndan daha fazla sat�r olu�turmay� engelleyen method
  private void CalculateColumnsAndRowsNumber()
    {
        do
        {
            _columns++;
            _rows = _wordsNumber / _columns;

        } while (_rows >= maxRows);
        // E�er s�tun say�s� maksimum s�tun say�s�n� ge�erse, s�tun say�s�n� s�n�rl�yoruz.
        if (_columns > maxColumns)
        {
            _columns = maxColumns;
            _rows=_wordsNumber / _columns;
        }
    }

    private bool TryIncreaseColumnNumber()
    {
        _columns++;
        _rows = _wordsNumber / _columns;
        if(_columns > maxColumns)
        {
            _columns = maxColumns;
            _rows=_wordsNumber / _columns;

            return false;
        }
        if(_wordsNumber % _columns>0)
        {
            _rows++;

        }
        return true;
    }


    // Kelime nesnelerini yaratma metodu.
    private void CreateWordObject()
    {
        var squareScale = GetSquareScale(new Vector3(1f, 1f, 0.1f));


        for(var index=0; index < _wordsNumber; index++)
        {

            // Her kelime i�in bir GameObject (kelime nesnesi) olu�turuyoruz.
            _words.Add(Instantiate(searchingWordPrefab) as GameObject);
            _words[index].transform.SetParent(this.transform);
            _words[index].GetComponent<RectTransform>().localScale = squareScale;
            _words[index].GetComponent<RectTransform>().localPosition=new Vector3(0f,0f,0f);
            _words[index].GetComponent<SearchingWord>().SetWord(currentGameData.selectedBoardData.SearchWords[index].Word);

        }
    }
    // Karelerin �l�e�ini hesaplama metodu.
    private Vector3 GetSquareScale(Vector3 defaultScale)
    {
        var finalScale = defaultScale;
        var adjustment = 0.01f;
        while (ShouldScaleDown(finalScale))
        {
            finalScale.x = adjustment;
            finalScale.y=adjustment;
            if(finalScale.x <= 0 || finalScale.y <= 0)
            {
                finalScale.x = adjustment;
                finalScale.y=adjustment;

                return finalScale;
            }
        }
        return finalScale;
    }

    // Karelerin daha k���k yap�lmas� gerekti�ini kontrol eden metot.
    private bool ShouldScaleDown(Vector3 targetScale)
    {
        var squareRect=searchingWordPrefab.GetComponent<RectTransform>();
        var parentRect=this.GetComponent<RectTransform>();

        var squareSize = new Vector3(0f, 0f);
        squareSize.x=squareRect.rect.width*targetScale.x+offset;
        squareSize.y=squareRect.rect.height*targetScale.y+offset;

        var totalSquareHeight=squareSize.y  * _rows;
        //olu�turdu�umuz kodda dikd�rtgen alanlara tam olarak s��mas�n� istiyoruz
        if (totalSquareHeight > parentRect.rect.height)
        {
            while(totalSquareHeight > parentRect.rect.height)
            {
                if (TryIncreaseColumnNumber())
                {
                    totalSquareHeight=squareSize.y* _rows;
                }
                else
                {
                    return true;
                }
            }
        }

        var totalSquareWidth = squareSize.x * _columns;
        if (totalSquareWidth > parentRect.rect.width)
        {
            return true;
        }
        return false;
    }
    // Kelimelerin do�ru pozisyonlara yerle�tirilmesini sa�layan metot.
    private void SetWordsPosition()
    {

        var squareRect = _words[0].GetComponent<RectTransform>();
        var wordOffset = new Vector2
        {
            x = squareRect.rect.width * squareRect.transform.localScale.x + offset,
            y = squareRect.rect.height * squareRect.transform.localScale.y + offset
        };

        int columnNumber = 0;
        int rowNumber = 0;
        var startPosition=GetFirstSquarePosition();
        // her kelime i�in uygun pozisyona yerle�tirme
        foreach ( var word in _words )
        {
            if(columnNumber+1> _columns)
            {
                columnNumber = 0;
                rowNumber++;
            }
            var positionX=startPosition.x+wordOffset.x * columnNumber;
            var positionY=startPosition.y+wordOffset.y * rowNumber;

            word.GetComponent<RectTransform>().localPosition= new Vector2 (positionX, positionY);
            columnNumber++;
        }
    }
    // �lk kelimenin yerle�tirilece�i pozisyonu hesaplayan metot.
    private Vector2 GetFirstSquarePosition()
    {
        var startPosition = new Vector2(0f, transform.position.y);
        var squareRect = _words[0].GetComponent<RectTransform>();   
        var parentRect=this.GetComponent <RectTransform>();
        var squareSize = new Vector2(0f, 0f);

        squareSize.x = squareRect.rect.width * squareRect.transform.localScale.x + offset;
        squareSize.y = squareRect.rect.height * squareRect.transform.localScale.y + offset;

        var shiftBy=(parentRect.rect.width - (squareSize.x* _columns)) / 2;
        startPosition.x=((parentRect.rect.width-squareSize.x)/ 2)*(-1);
        startPosition.x+= shiftBy;
        startPosition.y=(parentRect.rect.height- squareSize.y)/ 2;

        return startPosition;
    }
}
