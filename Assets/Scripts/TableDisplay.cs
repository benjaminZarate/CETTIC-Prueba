using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TableDisplay : MonoBehaviour
{
    [SerializeField] GameObject rowprefab = null;
    [SerializeField] Transform parent = null;

    public void CreateRow() {
        foreach (OrdenDatos datos in DataManager.Instance.lists.ordersList)
        {
            GameObject newRow = Instantiate(rowprefab);
            newRow.transform.SetParent(parent);
            newRow.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = datos.ubicacion.ToString();
            newRow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = datos.cantidadElementos.ToString();
            newRow.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = datos.prioridad.ToString();
            newRow.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = datos.etiquetaSerial.ToString();
        }
    }

    public void DestroyPreviousChild() {
        foreach (Transform obj in parent) {
            Destroy(obj.gameObject);
        }
    }
}
