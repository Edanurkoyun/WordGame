using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggleButton : MonoBehaviour
{
    // Buton türlerini belirtmek için enum kullandým
    public enum ButtonType
    {
        BackgrounMusic,SoundFx
    };

    public ButtonType type;

    public Sprite onSprite;
    public Sprite offSprite;

    public GameObject button;
    public Vector3 offButtonPosition;
    private Vector3 _onButtonPosition;
    private Image _image;
    // Start is called before the first frame update
    void Start()
    {
        _image=GetComponent<Image>();   
        _image.sprite = onSprite;
        _onButtonPosition= button.GetComponent<RectTransform>().anchoredPosition;
        ToggleButton();
    }

    public void ToggleButton()
    {
        var muted = false;
        // Buton türüne göre arka plan müziði veya ses efektlerini kontrol et
        if (type==ButtonType.BackgrounMusic)
        {
            muted = SoundManager.instance.IsBackgroundMusicMuted();

        }
        else
        {
            muted=SoundManager.instance.IsSoundFXMuted();
        }
        if(muted)// Eðer ses kapalýysa(muted == true)
        {
            _image.sprite=offSprite;
            button.GetComponent<RectTransform>().anchoredPosition = offButtonPosition;

        }
        else
        {
            _image.sprite = onSprite;
            button.GetComponent<RectTransform>().anchoredPosition = _onButtonPosition;
        }
    }



}
