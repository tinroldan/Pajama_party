using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ChangeLang : MonoBehaviour
{
    Localization_base langData;
    [SerializeField] TMP_Dropdown langLabel;

    [SerializeField] UnityEvent lang_Event;

    string[] langsArray = new string[]
    {
        "SP",
        "ENG",
    };

    void Start()
    {
        langData = GameObject.FindGameObjectWithTag("Manager").GetComponent<Localization_base>();
        SetLang();
    }

    public void SetLang()
    {
        if(langData!=null)
        {
            langData.language = langsArray[langLabel.value];
        }

        if (lang_Event != null)
        {
            lang_Event.Invoke();
        }
    }
}
