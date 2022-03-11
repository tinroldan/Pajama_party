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
            { "start_game","Start Game" },
            { "loading","Loading..." },
            { "online_multiplayer","Online Multiplayer" },
            { "back","Back" },
            { "controls","Controls" },
            { "lang","Language" },
            { "sound","Sound" },
            { "settings","Settings" },
            { "move","Move" },
            { "throw","Throw" },
            { "dash","Dash" },

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
            { "start_game","Empezar Juego" },
            { "loading","Cargando..." },
            { "online_multiplayer","Multijugdor en linea" },
            { "back","Volver" },
            { "controls","Controles" },
            { "lang","Idioma" },
            { "sound","Sonido" },
            { "settings","Configuraciones" },
            { "move","Mover" },
            { "throw","Lanzar" },
            { "dash","Turbo" },
    };


    public string GetTraslation(string key)
    {
        string translate = "";
        if (language == "SP")
        {
            translate = dataText_SP[key];
        }
        else if (language == "ENG")
        {
            translate = dataText_ENG[key];

        }
        return translate;
    }

}
