using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStatsPanel : MonoBehaviour
{
    [SerializeField] private Text _coinCount;
    [SerializeField] private Text _lvl;
    [SerializeField] private Text _expBarelText;
    [SerializeField] private GameObject _expBarel;
    [SerializeField] private Text _reputationBarelText;
    [SerializeField] private GameObject _reputationExpBarel;
    [SerializeField] private Player _player;
    

    private void Awake()
    {
        _player.OnMainStatsChanged += MainStatsUpdate;        
    }

    private float BarelCalculation (float curentValue, float maxValue)
    {
        return curentValue / maxValue;
    }

    public void MainStatsUpdate ()
    {
        _coinCount.text = _player.Gold.ToString();
        _lvl.text = _player.Level.ToString();
        _expBarelText.text = $"{_player.CurrentExp}/{_player.TargetExp}";
        _reputationBarelText.text = $"{_player.CurrentReputation}/{_player.MaxReputation}";
        Image expBarel = _expBarel.GetComponent<Image>();
        Image reputationBarel = _reputationExpBarel.GetComponent<Image>();
        expBarel.fillAmount = BarelCalculation(_player.CurrentExp, _player.TargetExp);
        reputationBarel.fillAmount = BarelCalculation(_player.CurrentReputation, _player.MaxReputation);
    }
}
