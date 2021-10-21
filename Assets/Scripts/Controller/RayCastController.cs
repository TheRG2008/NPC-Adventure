using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private PanelsManager _panelsManager;
    [SerializeField] private PlayerMove _playerMove;
    private Enemy _enemy;
    private IItem _item;

    public Enemy Enemy => _enemy;
    public IItem Item  => _item;

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
                _playerMove.StopMove();
                _item = hit.collider.gameObject.GetComponent<Resource>();
                _panelsManager.ShowResourseActionPanel();
            }
            if (hit.collider.gameObject.GetComponent<Enemy>())
            {
                _enemy = hit.collider.gameObject.GetComponent<Enemy>();
                _panelsManager.ShowEnemyActionPanel();
            }
        }
    }
}
