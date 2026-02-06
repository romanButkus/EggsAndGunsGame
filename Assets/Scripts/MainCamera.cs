using UnityEngine;
using UnityEngine.Tilemaps;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;

    float _topLeftLimitX;
    float _topLeftLimitY;
    float _bottomRightLimitX;
    float _bottomRightLimiY;

    [SerializeField] private Tilemap _tilemap;

	void Start()
	{
        SetBounds(_tilemap);
	}

	public void SetBounds(Tilemap tilemap)
    {
        float _cameraSize = Camera.main.orthographicSize;
        float _aspectRatio = Camera.main.aspect * _cameraSize;

        Bounds _bounds = _tilemap.localBounds;

        _topLeftLimitX = _bounds.min.x + _aspectRatio;
        _topLeftLimitY = _bounds.max.y - _cameraSize;

        _bottomRightLimitX = _bounds.max.x - _aspectRatio;
        _bottomRightLimiY = _bounds.min.y + _cameraSize;
    }

	void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(_player.position.x, _topLeftLimitX, _bottomRightLimitX),
            Mathf.Clamp(_player.position.y, _bottomRightLimiY, _topLeftLimitY),
            transform.position.z
        );
	}
}
