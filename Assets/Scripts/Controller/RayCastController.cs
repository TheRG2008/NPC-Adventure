using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private PanelsManager _panelsManager;
    private PlayerMove _playerMove;
    private Enemy _enemy;
    private IItem _item;
    private Transform _transform;
    public List<Transform> WorkerTargets;

    public Enemy Enemy => _enemy;
    public IItem Resource  => _item;
    public Transform Transform => _transform; 

    private void Start()
    {
        WorkerTargets = new List<Transform>();
        _panelsManager = FindObjectOfType<PanelsManager>();
        _playerMove = FindObjectOfType<PlayerMove>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChoisObject();
        }
    }

    public void ChoisObject()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<Resource>())
            {                
                _item = hit.collider.gameObject.GetComponent<Resource>();
                _transform = hit.collider.gameObject.transform;
                WorkerTargets.Add(hit.collider.gameObject.transform);
                _panelsManager.Show(Panels.ResourseActionPanel);                   
            }
            if (hit.collider.gameObject.GetComponent<Enemy>())
            {
                _enemy = hit.collider.gameObject.GetComponent<Enemy>();
                _transform = hit.collider.gameObject.transform;
                _panelsManager.Show(Panels.EnemyActionPanel);
            }
        }
    }
}
