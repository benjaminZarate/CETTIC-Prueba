using System.IO;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [System.Serializable]
    public class ListObject { 
        public List<OrdenDatos> ordersList = new List<OrdenDatos>();
    }

    public ListObject lists = new ListObject();

    public OrdenDatos order;
    string json;

    #region Singleton
    public static DataManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void SaveData() {
        OrdenDatos newOrder = new OrdenDatos {
            ubicacion = order.ubicacion,
            cantidadElementos = order.cantidadElementos,
            prioridad = order.prioridad,
            etiquetaSerial = order.etiquetaSerial
        };

        lists.ordersList.Add(newOrder);
        json = JsonUtility.ToJson(lists,true);
        File.WriteAllText(Application.dataPath + "/orders.json", json);
    }

    public void LoadData() {
        if (!File.Exists(Application.dataPath + "/orders.json")) { 
            Debug.LogWarning("Json file doesn't exist"); 
            return; 
        }
        string jsonFile = File.ReadAllText(Application.dataPath + "/orders.json");
        lists = JsonUtility.FromJson<ListObject>(jsonFile);
    }
}

