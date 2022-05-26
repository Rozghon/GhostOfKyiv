using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTargeting : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rb;
	private Transform target;

	public float range = 15f;
	public string _targetTag = "Enemy";

	public float turnSpeed = 10f;
	[SerializeField] private float _speed = 10f;

	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	private void Update()
	{
		transform.Translate(Vector2.up * _speed * Time.fixedDeltaTime);

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
}
