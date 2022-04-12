using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubes : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject[] _cubes; //k�pleri array i�ine ald�k.
    private float _waitTimer = 1f;
    public bool ActivateOrderCame;


    private void Start()
    {
        Debug.Log("Trying to find specific cube");
        Debug.Log(_cubes[2].name.ToString()); //istedi�imiz s�radaki k�p�n ismini yazd�rd�k.
        StartCoroutine(StartCubesDeactivateProcess()); //1'er saniye aral�klarla k�pleri deaktif ettik.
    }

    private IEnumerator StartCubesDeactivateProcess()
    {
        for (int i = 0; i < _cubes.Length; i++)
        {
            if (_cubes[i].activeInHierarchy == true)
            {
                _cubes[i].SetActive(false);
                yield return new WaitForSeconds(_waitTimer); 
            }
        }
        ActivateCubes();
    }

    public void ActivateCubes()
    {
        if(ActivateOrderCame == true)
            for (int i = 0; i<_cubes.Length; i++)
            {
                _cubes[i].SetActive(true);
            }
    }
}
