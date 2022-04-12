using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpheres : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] List<GameObject> _spheres; //küreleri list içine aldýk.
    private float _senderTimeToWait = 1f;
    public bool DeactivateSpheresOrderSent;

    private void Start()
    {
        Debug.Log("Try to find capacity of list");
        Debug.Log(_spheres.Count); //listenin kapasitesini yazdýrdýk.
        StartCoroutine(MoveSpheresForward()); //1'er saniye aralýklarla küreleri ileri taþýdýk.
    }

    private IEnumerator MoveSpheresForward()
    {
        for (int i = 0; i < _spheres.Count; i++) //1'er saniye aralýklarla küreleri ileri taþýdýk.
        {
            _spheres[i].transform.position = _spheres[i].transform.position + new Vector3(0, 0, 5f);
            yield return new WaitForSeconds(_senderTimeToWait);
        }
        ActivateCubesOrderSent(); //son gönderme iþlemi bittikten sonra isteði gönderdik.
        DeactivateSpheres(); //küreleri burada deaktif et.
    }

    public void ActivateCubesOrderSent()
    {
        _gameManager.TestCubes.ActivateCubesOrderSent = true; //istek doðrultusunda ilgili bool'u true gönderme emri verdik.
    }

    public void DeactivateSpheres() //küreleri deaktif etme yöntemi.
    {
        for (int i = 0; i<_spheres.Count; i++)
        {
            _spheres[i].SetActive(false);
        }
    }

}
