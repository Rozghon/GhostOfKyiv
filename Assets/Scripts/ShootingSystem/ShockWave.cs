using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _shockWave;

    private bool _isShock = false;

    private void Update()
    {
        if(!_isShock)
        {
            StartCoroutine(Shock());
        }
    }

    private IEnumerator Shock()
    {
        _isShock = true;
        _shockWave.SetActive(true);
        yield return new WaitForSeconds(1f);
        _shockWave.SetActive(false);
        yield return new WaitForSeconds(_delay);
        _isShock = false;
    }
}
