using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customization : MonoBehaviour
{
    CharSelection cs;
    enum AppearanceDetail
    {
        HAT_MODEL,
        SKIN_COLOR
    }

    [SerializeField] private GameObject[] hatModels;

    GameObject activeHat;

    int hatIndex = 0;

    public void HatModelUp()
    {
        if(hatIndex < hatModels.Length - 1)
        {
            hatIndex++;
        }
        else
        {
            hatIndex = 0;
        }

        ApplyModification(AppearanceDetail.HAT_MODEL, hatIndex);
    }

    public void HatModelDown()
    {
        if (hatIndex > 0)
        {
            hatIndex--;
        }
        else
        {
            hatIndex = hatModels.Length - 1;
        }

        ApplyModification(AppearanceDetail.HAT_MODEL, hatIndex);
    }

    void ApplyModification(AppearanceDetail detail, int id)
    {
        switch (detail)
        {
            case AppearanceDetail.HAT_MODEL:
                if(activeHat != null)
                {
                    GameObject.Destroy(activeHat);
                }
                activeHat = GameObject.Instantiate(hatModels[id]);
                break;
            case AppearanceDetail.SKIN_COLOR:
                break;
            default:
                break;
        }
    }



}
