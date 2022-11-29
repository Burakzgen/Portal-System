using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform target;
    public Transform player;

    private CharacterController _characterController;
    private void Start()
    {
        _characterController = player.GetComponent<CharacterController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _characterController.enabled = false;
            player.forward = target.forward;
            player.position = target.position + target.forward;
            _characterController.enabled = true;
        }
    }
}
