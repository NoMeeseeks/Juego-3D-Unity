using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionAleatoria : MonoBehaviour
{
    public GameObject[] rainPrefabs; // Array de prefabricados de objetos de lluvia
    public float spawnInterval = 1.0f; // Intervalo de generación
    public float spawnAreaRadius = 5.0f; // Radio del área de generación

    void Start()
    {
        // Comenzar la generación de lluvia en intervalos
        StartCoroutine(SpawnRain());
    }

    IEnumerator SpawnRain()
    {
        // Bucle infinito para generar lluvia
        while (true)
        {
            // Esperar el intervalo especificado
            yield return new WaitForSeconds(spawnInterval);

            // Calcular una posición aleatoria dentro del área de generación
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnAreaRadius;
            spawnPosition.y = transform.position.y; // Mantener la altura constante

            // Seleccionar aleatoriamente un prefab de lluvia de la lista
            GameObject randomRainPrefab = rainPrefabs[Random.Range(0, rainPrefabs.Length)];

            // Instanciar el objeto de lluvia seleccionado en la posición calculada
            GameObject rain = Instantiate(randomRainPrefab, spawnPosition, Quaternion.identity);

            // Obtener el componente Rigidbody del objeto de lluvia
            Rigidbody rb = rain.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Configurar una velocidad aleatoria hacia abajo para simular la lluvia cayendo
                rb.velocity = Vector3.down * Random.Range(2f, 5f);
            }
        }
    }
}
