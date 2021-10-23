using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Panels
{
    MaxDarkPanel,
    NotEnoughGold,
    ResourseActionPanel,
    EnemyActionPanel,
    EnoughSpacePanel,
    OpenDarkPanelShow,
    OpenDarkPanelHide,
    WorkerStats,
    HeroStats,
    Impossible,
    WorkerSelected,
    CollectResource
}


public class PanelsManager : MonoBehaviour
{
    [SerializeField] private GameObject _maxDarkPanel;
    [SerializeField] private GameObject _notEnoughGold;
    [SerializeField] private GameObject _notEnoughSpace;
    [SerializeField] private GameObject _resourseActionPanel;
    [SerializeField] private GameObject _enemyActionPanel;
    [SerializeField] private GameObject _openDarkPanel;
    [SerializeField] private GameObject _workerStatsPanel;
    [SerializeField] private GameObject _heroStatsPanel;
    [SerializeField] private GameObject _impossiblePanel;
    [SerializeField] private GameObject _workerSelectedPanel;
    [SerializeField] private GameObject _collectResourcePanel;



    public void Show(Panels panel)
    {
        switch (panel)
        {
            case Panels.MaxDarkPanel:
                StartCoroutine(ShowPanel(_maxDarkPanel));
                break;
            case Panels.NotEnoughGold:
                StartCoroutine(ShowPanel(_notEnoughGold));
                break;
            case Panels.ResourseActionPanel:
                _ShowPanel(_resourseActionPanel);
                break;
            case Panels.EnemyActionPanel:
                _ShowPanel(_resourseActionPanel);
                break;
            case Panels.EnoughSpacePanel:
                StartCoroutine(ShowPanel(_notEnoughSpace));
                break;
            case Panels.OpenDarkPanelShow:
                _ShowPanel(_openDarkPanel);
                break;
            case Panels.OpenDarkPanelHide:
                _HidePanel(_openDarkPanel);
                break;
            case Panels.WorkerStats:
                _ShowPanel(_workerStatsPanel);
                break;
            case Panels.HeroStats:
                _ShowPanel(_heroStatsPanel);
                break;
            case Panels.Impossible:
                StartCoroutine(ShowPanel(_impossiblePanel));
                break;
            case Panels.WorkerSelected:
                StartCoroutine(ShowPanel(_workerSelectedPanel));
                break;
            case Panels.CollectResource:
                StartCoroutine(ShowPanel(_collectResourcePanel));
                break;
            default:
                break;
        }
    }
   
   private void _ShowPanel(GameObject panel)
    {
        panel.SetActive(true);

    }
    private void _HidePanel(GameObject panel)
    {
        panel.SetActive(false);

    }

    private IEnumerator ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(1f);        
        panel.SetActive(false);
    }
}
