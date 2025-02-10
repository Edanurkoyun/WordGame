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
        // Oyun sona erdiðinde ShowGameOverPopup metodunun çaðrýlmasýný saðlar
        GameEvents.OnGameOver += ShowGameOverPopup;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= ShowGameOverPopup;
    }

    // oyun sona erdiðinde çaðrýlýr ve popup'ý aktif hale getirir
    private void ShowGameOverPopup()
    {

        gameOverpopup.SetActive(true);
    }
}
