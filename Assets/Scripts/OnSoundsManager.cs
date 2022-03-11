using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OnSoundsManager : MonoBehaviour
{
    [SerializeField] TMP_Text offText;
    [SerializeField] TMP_Text onText;
    [SerializeField]  Image togglImage;
    [Header("sprites")]
    [SerializeField]  Sprite onSprite,offSprite;
    [Header("colors")]
    [SerializeField]  Color onColor,offColor;

    public bool _onSound;

    private void Start()
    {
        if (!_onSound)
        {
            togglImage.sprite = offSprite;
            offText.color = offColor;
            onText.color = onColor;
        }
        else
        {
            togglImage.sprite = onSprite;
            offText.color = onColor;
            onText.color = offColor;
        }
    }

    public void onSound()
    {
        if(_onSound)
        {
            togglImage.sprite = offSprite;
            offText.color = offColor;
            onText.color = onColor;
            _onSound = false;
            Debug.Log("sound is Off");

        }
        else
        {
            togglImage.sprite = onSprite;
            offText.color = onColor;
            onText.color = offColor;
            _onSound = true;
            Debug.Log("sound is On");

        }
    }


}
