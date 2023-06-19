using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsForSpawn : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private GameObject[] _pointForSpawn;
    [Header("Model")]
    [SerializeField] private GameObject _model;
    [Header("K/D for Spawn(IN THE SECONDS)")]
    [SerializeField] private float _waitTime;
    [SerializeField] private float _reapetTime;
    [Header("List with Objests")]
    [SerializeField] private GameObject _listObjects;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), _waitTime, _reapetTime);
    }

    private void Spawn()
    {
        Instantiate(_model, _pointForSpawn[RandomizerOfPoints()].transform.position, Quaternion.identity, _listObjects.transform);
        StartCoroutine(Wait(_waitTime));
    }

    private int RandomizerOfPoints()
    {
        int index;
        index = Random.Range(0, _pointForSpawn.Length);
        return index;
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
