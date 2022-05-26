using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public string _targetTag;

    [SerializeField] private string _spawnPointTag;
    [SerializeField] private bool _isReturnToSpawnPoints = true;

    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;

    private float _startingSpeed;
    private float _startingTurnSpeed;

    private Transform[] _spawnPoints;
    private Transform _curentTarget;
    private Transform _target;

    private Rigidbody2D _rb;

    private bool _isDecoy = false;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();

        FindSpawnPoints();
        FindTarget();
        _curentTarget = _target;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * _speed * Time.fixedDeltaTime);

        Vector2 _lookDirection = new Vector2(_curentTarget.position.x, _curentTarget.position.y) - _rb.position;
        float _angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _angle), _turnSpeed);

        if(_isDecoy)
        {
            StartCoroutine(Decoy());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == _targetTag && _isReturnToSpawnPoints)
        {
            _curentTarget = ChoseSpawnPoint();
        }
        else if (collision.transform.tag == _spawnPointTag)
        {
            _curentTarget = _target;
        }
    }

    private void FindSpawnPoints()
    {
        GameObject[] _findedSpawnPoints = GameObject.FindGameObjectsWithTag(_spawnPointTag);
        _spawnPoints = new Transform[_findedSpawnPoints.Length];
        for (int i = 0; i < _findedSpawnPoints.Length; i++)
        {
            _spawnPoints[i] = _findedSpawnPoints[i].GetComponent<Transform>();
        }
    }

    private void FindTarget()
    {
        _target = GameObject.FindGameObjectWithTag(_targetTag).GetComponent<Transform>();
    }

    private Transform ChoseSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }

    public void SetStartingStats()
    {
        _startingSpeed = _speed;
        _startingTurnSpeed = _turnSpeed;
    }

    public void SetSpeed()
    {
        int _level = GameRuller.instance.GetLevel();
        _speed = _startingSpeed + ((float)_level * 0.2f);
    }

    public void SetTurnSpeed()
    {
        int _level = GameRuller.instance.GetLevel();
        _turnSpeed = _startingTurnSpeed + ((float)_level * 0.005f);
    }

    public void SetCurrentTarget(string _targetTag)
    {
        _curentTarget = GameObject.FindGameObjectWithTag(_targetTag).transform;
    }

    public void StartDecoy()
    {
        _isDecoy = true;
    }

    private IEnumerator Decoy()
    {
        _isDecoy = true;
        SetCurrentTarget("Decoy");
        yield return new WaitForSeconds(3f);
        _curentTarget = _target;
        _isDecoy = false;
    }
}