using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Localise : MonoBehaviour
{
    Localization_base dataText;
    [SerializeField] string key;
    TMP_Text text_localized;
    // Start is called before the first frame update
    private void Awake()
    {
        text_localized = GetComponent<TMP_Text>();
    }
    void Start()
    {
        dataText = GameObject.FindGameObjectWithTag("Manager").GetComponent<Localization_base>();
        if(dataText!=null&&!string.IsNullOrEmpty(key))
        {
            string translate = dataText.GetTraslation(key);
            if (key != null&& translate!=null)
            {
                text_localized.text = translate;
            }
        }
        
    }

    public void SetLang()
    {
        if (dataText != null && !string.IsNullOrEmpty(key))
        {
            string translate = dataText.GetTraslation(key);
            if (key != null && translate != null)
            {
                text_localized.text = translate;
            }
        }
    }

}
