using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization_base : MonoBehaviour
{
    public string language = "SP";
    public static Dictionary<string, string> dataText_ENG = new Dictionary<string, string>
    {
            { "play", "Play" },
            { "quit_lobby", "Quit Lobby" },
            { "leave_room", "Leave Room" },
            { "quit", "Quit" },
            { "find_match", "Find Match" },
            { "local_vs", "Local VS" },
            { "quit_game", "Quit Game" },
            { "hello", "Hello" },


    };

    public static Dictionary<string, string> dataText_SP = new Dictionary<string, string>
    {
            { "play", "Jugar" },
            { "quit_lobby", "Salir del lobby" },
            { "leave_room", "Dejar la sala" },
            { "quit", "Salir" },
            { "find_match", "Buscar Partida" },
            { "local_vs", "Batalla Local" },
            { "quit_game", "Salir del juego" },
            { "hello", "Hola" },


    };
    

    public string GetTraslation(string key)
    {
        string translate = "";
        if (language == "SP")
        {
            translate= dataText_SP[key];
        }
        else if (language == "ENG")
        {
            translate= dataText_ENG[key];

        }
        return translate;
    }

}
