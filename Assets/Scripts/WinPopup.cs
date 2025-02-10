using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopup : MonoBehaviour
{

    public GameObject winPopup;
    // Start is called before the first frame update
    void Start()
    {
     winPopup.SetActive(false);
        
    }

    private void OnEnable()
    {
        GameEvents.OnBoardCompleted += ShowWinPopup;
    }
    private void OnDisable()
    {
        GameEvents.OnBoardCompleted -= ShowWinPopup;
    }

    private void ShowWinPopup()
    {
        // ShowWinPopup metodu, herhangi bir oyun tahtas� tamamland���nda popup'� g�sterir
        winPopup.SetActive(true);
    }

    public void LoadNextLevel()
    {
        // oyun tamamnland���nda bir sonraki levele ge�er
        GameEvents.LoadNextLevelMethod();
    }
}
