using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrdenGenerator : MonoBehaviour
{
    #region Componentes
    public TextMeshProUGUI ubicacionText;
    public TextMeshProUGUI cantidadElementosText;
    public TextMeshProUGUI prioridadText;
    public TextMeshProUGUI etiquetaSerialText;
    public Image imagenProducto;
    #endregion

    [SerializeField] OrdenDatos datos = new OrdenDatos();
    public Sprite[] imagenesProductos;
    private void Start()
    {
        GenerateOrder();
    }

    void RandomNumbers() { 
        datos.ubicacion = Random.Range(1000, 2000);
        datos.cantidadElementos = Random.Range(1000, 2000);
        datos.prioridad = Random.Range(1, 11);
        datos.etiquetaSerial = Random.Range(1000, 2000);

        DataManager.Instance.order = datos;
    }

    void AssignText() { 
        ubicacionText.text = $"Codigo de ubicacion: {datos.ubicacion}";
        cantidadElementosText.text = $"Cantidad de elementos: {datos.cantidadElementos}";
        prioridadText.text = $"Nivel de prioridad: {datos.prioridad}";
        etiquetaSerialText.text = $"Etiqueta serial: {datos.etiquetaSerial}";
    
    }
    void SelectImage() {
        int randomIndex = Random.Range(0, imagenesProductos.Length);

        imagenProducto.sprite = imagenesProductos[randomIndex];
    }

    public void GenerateOrder() {
        RandomNumbers();
        AssignText();
        SelectImage();
    }


}


