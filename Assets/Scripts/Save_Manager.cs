using System.IO;
using UnityEngine;

public class Save_Manager : MonoBehaviour
{
        public static Save_Manager saveManager;
        public SaveData activeSave;
        public bool loaded;

        private void Awake() {
            saveManager = this;
            Load();

          
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                Save();
            }
            if (Input.GetKeyDown(KeyCode.B)) {
                Load();
            }
            if (Input.GetKeyDown(KeyCode.C)) {
                DeleteData();
            }
        }
        public void Save() {

            // SaveData saveData = new SaveData {
            //     guardados = guard
            //};
           
            string json = JsonUtility.ToJson(activeSave);
           File.WriteAllText(Application.dataPath + "/save.txt", json);
             Debug.Log("Guardado: " + json);
        }
        public void Load() {
            

            if (File.Exists(Application.dataPath + "/save.txt" )) {

                 string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
                 SaveData saveData = JsonUtility.FromJson<SaveData>(saveString);

               activeSave.character_1 = saveData.character_1;
            activeSave.character_2 = saveData.character_2;
                loaded = true;

                Debug.Log("Cargado: "+ saveString);
            }
        }
        public void DeleteData() {
            if (File.Exists(Application.dataPath + "/save.txt")) {
                File.Delete(Application.dataPath + "/save.txt");

                Debug.Log("Lo borré");
            }
        }
    }
    [System.Serializable]
    public class SaveData {
        public int guardados; 
        public GameObject character_1;
        public GameObject character_2;

   
    //public ScriptableObject onlineCharacter;

}
