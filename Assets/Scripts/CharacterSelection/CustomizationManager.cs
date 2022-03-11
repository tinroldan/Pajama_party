using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    enum AppearanceDetails
    {
        HAT_MODEL,
        SKIN_COLOR
    }

    [SerializeField] private GameObject[] hatModels;

    [SerializeField] private Color32[] playerColor;

    public CharacterSelect cs;

    [SerializeField] private Transform headAnchor;
    [SerializeField] private MeshRenderer skinRenderer;

    GameObject activeHair;

    int hatIndex = 0;
    int colorIndex = 0;

    public void HatButtonUp()
    {
        if(hatIndex < hatModels.Length - 1)
        {
            hatIndex++;
        }
        else
        {
            hatIndex = 0;
        }
        ApplyModification(AppearanceDetails.HAT_MODEL, hatIndex);
    }
    public void HatButtonDown()
    {
        if (hatIndex > 0)
        {
            hatIndex--;
        }
        else
        {
            hatIndex = hatModels.Length - 1; 
        }
        ApplyModification(AppearanceDetails.HAT_MODEL, hatIndex);
    }

    public void ColorButtonUp()
    {
        if (colorIndex < playerColor.Length - 1)
        {
            colorIndex++;
        }
        else
        {
            colorIndex = 0;
        }
        ApplyModification(AppearanceDetails.SKIN_COLOR, colorIndex);
    }
    public void ColorButtonDown()
    {
        if (colorIndex > 0)
        {
            colorIndex--;
        }
        else
        {
            colorIndex = playerColor.Length - 1;
        }
        ApplyModification(AppearanceDetails.SKIN_COLOR, colorIndex);
    }

    void ApplyModification(AppearanceDetails detail, int id)
    {
        switch (detail)
        {
            case AppearanceDetails.HAT_MODEL:
                if(activeHair != null)
                {
                    GameObject.Destroy(activeHair);
                }
                activeHair = Instantiate(hatModels[id]);
                activeHair.transform.SetParent(headAnchor);
                break;
            case AppearanceDetails.SKIN_COLOR:
                cs.players[cs.currentPlayer].gameObject.GetComponent<MeshRenderer>().material.color = playerColor[id];
                break;
            default:
                break;
        }
    }


}
