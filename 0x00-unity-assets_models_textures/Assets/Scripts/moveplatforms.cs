using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplatforms : MonoBehaviour
{
	[SerializeField] float seedSpeed = 1f, seedSpeedRange = 0.5f;
	[SerializeField] Vector3 moveRange;
	private Vector3 originalPos, orientation, endPos;
	private float platformSpeed;
        // Define a dictionary to store the coroutines for each object
	private Dictionary<GameObject, Coroutine> playerMoveSyncDict = new Dictionary<GameObject, Coroutine>();

	void Start()
	{
		originalPos = transform.position;
		endPos =  originalPos + moveRange;
		platformSpeed = Random.Range(seedSpeed, seedSpeed + seedSpeedRange);
	}

	void FixedUpdate()
	{
		if (transform.position == originalPos)
			orientation = endPos;
		else if (transform.position == endPos)
			orientation = originalPos;

		transform.position = Vector3.MoveTowards(transform.position, orientation, platformSpeed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider other)
	{
		// Don't move pieces of the face if they haven't been detached.
		if (other.name != "Player" && other.transform.parent != null) return;

		// Debug.Log($"{other.name} Entered {this.name}");

		// Creates a new Coroutine for each object entering the collider
		// Keep only one copy of the routine per object
		if (!playerMoveSyncDict.ContainsKey(other.gameObject))
		{
			Coroutine moveSyncRoutine = StartCoroutine(syncPlayer(other));
			playerMoveSyncDict.Add(other.gameObject, moveSyncRoutine);
		}
	}

	void OnTriggerExit(Collider other)
	{
		// Don't move pieces of the face if they haven't been detached.
		if (other.name != "Player" && other.transform.parent != null) return;

		// Debug.Log($"{other.name} Exited {this.name}");

		// Destroy the coroutine associated with the exiting item
		Coroutine moveSyncRoutine;
		// Only if the Coroutine has actually been invoked on it
		if (playerMoveSyncDict.TryGetValue(other.gameObject, out moveSyncRoutine))
		{
			StopCoroutine(moveSyncRoutine);
			playerMoveSyncDict.Remove(other.gameObject);
		}
	}

	IEnumerator syncPlayer(Collider other)
	{
		// If there's a CharacterController present, grab it.
		CharacterController objController = other.GetComponent<CharacterController>();
		// This is because altering the position doesn't work when the controller is enabled
		// If one is found, we use its Move() method instead of adjusting the transform.

		while (true)
		{
			Vector3 oldPos = transform.position;
			yield return null;

			// Debug.Log($"Executing movement for {other.name} in trigger");

			Vector3 positionDiff = transform.position - oldPos;

			// The character controller already smoothly handles gravity
			// So if you're going down, we just ignore it here and let the CharacterController do it.
			positionDiff.y = Mathf.Max(0f, positionDiff.y);

			if (objController != null)
				objController.Move(positionDiff);
			else
				other.transform.position += positionDiff;
		}
	}
}
