using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpheres : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] List<GameObject> _spheres; //k�releri list i�ine ald�k.
    private float _senderTimeToWait = 1f;
    public bool DeactivateSpheresOrderSent;

    private void Start()
    {
        Debug.Log("Try to find capacity of list");
        Debug.Log(_spheres.Count); //listenin kapasitesini yazd�rd�k.
        StartCoroutine(MoveSpheresForward()); //1'er saniye aral�klarla k�releri ileri ta��d�k.
    }

    private IEnumerator MoveSpheresForward()
    {
        for (int i = 0; i < _spheres.Count; i++) //1'er saniye aral�klarla k�releri ileri ta��d�k.
        {
            _spheres[i].transform.position = _spheres[i].transform.position + new Vector3(0, 0, 5f);
            yield return new WaitForSeconds(_senderTimeToWait);
        }
        ActivateCubesOrderSent(); //son g�nderme i�lemi bittikten sonra iste�i g�nderdik.
        DeactivateSpheres(); //k�releri burada deaktif et.
    }

    public void ActivateCubesOrderSent()
    {
        _gameManager.TestCubes.ActivateCubesOrderSent = true; //istek do�rultusunda ilgili bool'u true g�nderme emri verdik.
    }

    public void DeactivateSpheres() //k�releri deaktif etme y�ntemi.
    {
        for (int i = 0; i<_spheres.Count; i++)
        {
            _spheres[i].SetActive(false);
        }
    }

}
