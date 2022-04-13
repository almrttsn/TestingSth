using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubes : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject[] _cubes;                       //k�pleri array i�ine ald�k.
    private float _waitTimer = 1f;
    public bool ActivateCubesOrderSent;


    private void Start()
    {
        Debug.Log("Trying to find specific cube");
        Debug.Log(_cubes[2].name.ToString());                   //istedi�imiz s�radaki k�p�n ismini yazd�rd�k.
        StartCoroutine(StartCubesDeactivateProcess());          //1'er saniye aral�klarla k�pleri deaktif ettik.
    }

    private IEnumerator StartCubesDeactivateProcess()           //1'er saniye aral�klarla k�pleri deaktif ettik.
    {
        for (int i = 0; i < _cubes.Length; i++)
        {
            if (_cubes[i].activeInHierarchy == true)    
            {
                _cubes[i].SetActive(false);
                yield return new WaitForSeconds(_waitTimer); 
            }
        }
        ActivateCubes();                                        //k�pleri tekrar aktif ettik.
        DeactiveSpheresOrderSent();                             //k�releri deaktif etme emrini g�nder.
    }

    public void ActivateCubes()                                 //aktive etme y�ntemi.
    {
        if(ActivateCubesOrderSent == true)                      //Game Manager'dan emir geldi. Emri veren TestSpheres
            for (int i = 0; i<_cubes.Length; i++)
            {
                _cubes[i].SetActive(true);
            }
    }

    public void DeactiveSpheresOrderSent()                      //g�nderilen emirin i�eri�i.
    {
        _gameManager.TestSpheres.DeactivateSpheresOrderSent = true;
    }
}
