using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiAir : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;
	[SerializeField] private Rigidbody2D _rb;
	private Transform target;

	[Header("General")]

	public float range = 15f;

	[Header("Unity Setup Fields")]

	public string _targetTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

	public Transform firePoint;

	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	private void Update()
	{
		if (target == null)
		{
			UpdateTarget();
			return;
		}

		LockOnTarget();
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(_targetTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		}
		else
		{
			target = null;
		}

	}

	void LockOnTarget()
	{
		Vector2 _lookDirection = target.position - transform.position;
		float _angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg - 90f;
		_rb.rotation = _angle;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

	public void SetDamage(int _value)
    {
        _shooter.SetNewDamage(_value);
    }
}