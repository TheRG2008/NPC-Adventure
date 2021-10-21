using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Panels
{
    MaxDarkPanel,
    NotEnoughGold,
    ResourseActionPanel,
    EnemyActionPanel

}
public class PanelsManager : MonoBehaviour
{
    [SerializeField] private GameObject _maxDarkPanel;
    [SerializeField] private GameObject _notEnoughGold;
    [SerializeField] private GameObject _resourseActionPanel;
    [SerializeField] private GameObject _enemyActionPanel;


    public void Show(Panels panel)
    {
        //switch (switch_on)
        //{
        //    default:
        //}
    }
    public void ShowMaxDarkPanelAlert()
    {
        StartCoroutine(ShowPanel(_maxDarkPanel));
    }
    public void ShowNotEnoughGoldPanel()
    {
        StartCoroutine(ShowPanel(_notEnoughGold));
    }
    public void ShowResourseActionPanel()
    {
        _resourseActionPanel.SetActive(true);
    }
    public void ShowEnemyActionPanel()
    {
        _resourseActionPanel.SetActive(true);
    }

    private IEnumerator ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(1f);        
        panel.SetActive(false);
    }
}
