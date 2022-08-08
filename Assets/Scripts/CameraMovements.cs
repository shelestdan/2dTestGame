using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    private GameObject _player;
    private Transform _playerTransform;
    private Vector3 _offset;


    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerTransform = _player.GetComponent<Transform>();
        _offset = transform.position;

    }
    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = _playerTransform.position + _offset;
    }
}
