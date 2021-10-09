using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNumbersBehviours : MonoBehaviour
{
    [SerializeField] private GameObject prefabNumber;

    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

    private void Start()
    {
        InvokeRepeating("Spawn", 1, 10);
    }

    //visualizar tamanho da área
    void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    //criação e spawnar números
    private void Spawn()
    {
        Vector3 origin = transform.position;
        Vector3 range = transform.localScale / 2.0f;
        Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x), 0.6f, Random.Range(-range.z, range.z));
        Vector3 randomCoordinate = origin + randomRange;
        GameObject aux;
        aux = Instantiate(prefabNumber,randomCoordinate,Quaternion.identity);
        aux.name = "Number";
        aux.GetComponent<NumbersBehaviours>().SetNumber(Random.Range(1, 3));
    }
}
