using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopup : MonoBehaviour
{
    public GameObject gameOverpopup; 

    // Start is called before the first frame update
    void Start()
    {
        gameOverpopup.SetActive(false);
        // Oyun sona erdi�inde ShowGameOverPopup metodunun �a�r�lmas�n� sa�lar
        GameEvents.OnGameOver += ShowGameOverPopup;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= ShowGameOverPopup;
    }

    // oyun sona erdi�inde �a�r�l�r ve popup'� aktif hale getirir
    private void ShowGameOverPopup()
    {

        gameOverpopup.SetActive(true);
    }
}
