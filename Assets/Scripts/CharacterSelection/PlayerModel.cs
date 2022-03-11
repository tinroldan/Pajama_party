using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerModel", menuName ="Player")]
public class PlayerModel : ScriptableObject
{
    public string Name;

    public Material characterColor;

    public GameObject Player;

}
