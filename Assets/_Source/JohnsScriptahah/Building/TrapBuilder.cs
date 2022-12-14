using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBuilder : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [Range(3, 50)]
    [SerializeField] private float _maxBuildDistance = 5;

    [SerializeField] KeyCode _buildTrapKey;
    [Header("-------------------")]
    [Header("Prefabs to keys")]
    [SerializeField] List<KeyCode> _trapKeys;
    [SerializeField] List<BasicTrap> _traps;
    [Header("-------------------")]
    [Header("LayerMasks")]
    [SerializeField] private LayerMask _floorMask;
    [SerializeField] private LayerMask _wallMask;
    [SerializeField] private LayerMask _ceilingMask;
    [Header("-------------------")]


    private Dictionary<KeyCode, BasicTrap> _trapPrefabs = new Dictionary<KeyCode, BasicTrap>();
    private BasicTrap _flyingTrap;
    private KeyCode _keyInvoker;
    private GameStateManager _gSManager;

    private void Start()
    {
        for (int i = 0; i < _trapKeys.Count; i++)
        {
            _trapPrefabs.Add(_trapKeys[i], _traps[i]);
        }
    }

    public void Construct(GameStateManager gSManager)
    {
        _gSManager = gSManager;
    }

    private void Update()
    {
        if (_flyingTrap != null)
        {
            var ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxBuildDistance, _flyingTrap.BuildSurface))
            {
                if (_flyingTrap.BuildSurface.Equals(_floorMask))
                {
                    _flyingTrap.transform.position = new Vector3(
                        Mathf.RoundToInt(hit.point.x),
                        hit.point.y + 0.5f,
                        Mathf.RoundToInt(hit.point.z));
                }
                else if (_flyingTrap.BuildSurface == _wallMask)
                {
                    var normal = new Vector3(Mathf.RoundToInt(hit.normal.x), 0, Mathf.RoundToInt(hit.normal.z));
                    if (normal.x == 0 && normal.z == 1)
                    {
                        _flyingTrap.transform.localRotation = new Quaternion(0, 0, 0, -90);
                        _flyingTrap.transform.position = new Vector3(
                        Mathf.RoundToInt(hit.point.x),
                        Mathf.RoundToInt(hit.point.y),
                        hit.point.z + .5f);
                    }
                    else if (normal.x == 0 && normal.z == -1)
                    {
                        _flyingTrap.transform.localRotation = new Quaternion(0, 180, 0, 0);
                        _flyingTrap.transform.position = new Vector3(
                        Mathf.RoundToInt(hit.point.x),
                        Mathf.RoundToInt(hit.point.y),
                        hit.point.z - .5f);
                    }
                    else if (normal.x == 1 && normal.z == 0)
                    {
                        _flyingTrap.transform.localRotation = new Quaternion(0, 90, 0, 90);
                        _flyingTrap.transform.position = new Vector3(
                        hit.point.x + .5f,
                        Mathf.RoundToInt(hit.point.y),
                        Mathf.RoundToInt(hit.point.z));
                    }
                    else if (normal.x == -1 && normal.z == 0)
                    {
                        _flyingTrap.transform.localRotation = new Quaternion(0, -90, 0, 90);
                        _flyingTrap.transform.position = new Vector3(
                        hit.point.x - .5f,
                        Mathf.RoundToInt(hit.point.y),
                        Mathf.RoundToInt(hit.point.z));
                    }
                }
                else if (_flyingTrap.BuildSurface == _ceilingMask)
                {
                    _flyingTrap.transform.position = new Vector3(
                        Mathf.RoundToInt(hit.point.x),
                        Mathf.RoundToInt(hit.point.y) - 0.2f - 0.5f,
                        Mathf.RoundToInt(hit.point.z));
                }
            }
        }
    }

    public void TryBuildTrap()
    {
        if (_flyingTrap.CanBeGrounded && MoneyManagerSingleton.Instance.TrySpendCoins(_flyingTrap.Cost))
        {
            _flyingTrap.BuildTrap();
            _gSManager.OnGameStateChanged += _flyingTrap.OnGameStateChanged;
            _flyingTrap = null;
            StartPlacingTrap(_keyInvoker);
        }
    }

    public void StartPlacingTrap(KeyCode keyInvoker)
    {

        if (_flyingTrap != null)
            Destroy(_flyingTrap.gameObject);

        _keyInvoker = keyInvoker;
        _flyingTrap = Instantiate(_trapPrefabs[keyInvoker]);
    }

    private void OnDisable()
    {
        Destroy(_flyingTrap.gameObject);
    }
}
