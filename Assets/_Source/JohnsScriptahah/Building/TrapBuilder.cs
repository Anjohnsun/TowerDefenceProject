using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBuilder : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [Range(3, 50)]
    [SerializeField] private float _maxBuildDistance = 5;
    
    [Header("-------------------")]
    [Header("Prefabs to keys")]
    [SerializeField] List<KeyCode> _trapKeys;
    [SerializeField] List<BasicTrap> _traps;
    [Header("-------------------")]

    private Dictionary<KeyCode, BasicTrap> _trapPrefabs = new Dictionary<KeyCode, BasicTrap>();

    private BasicTrap _flyingTrap;

    private void Awake()
    {
        for(int i = 0; i < _trapKeys.Count; i++)
        {
            _trapPrefabs.Add(_trapKeys[i], _traps[i]);
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F1))
            StartPlacingTrap(KeyCode.F1);

        if (_flyingTrap != null)
        {
            var ray = _camera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxBuildDistance, _flyingTrap.BuildSurface))
            {
                _flyingTrap.transform.position = new Vector3(Mathf.RoundToInt(hit.point.x),
                    0.2f,
                    Mathf.RoundToInt(hit.point.z));
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && _flyingTrap.CanBeGrounded == true)
            {
                _flyingTrap.BuildTrap();
                _flyingTrap = null;
            }
        }
    }

    public void StartPlacingTrap(KeyCode keyInvoker)
    {

        if (_flyingTrap != null)
            Destroy(_flyingTrap.gameObject);

        _flyingTrap = Instantiate(_trapPrefabs[keyInvoker]);
        Debug.Log("Instantiate");
    }

}
