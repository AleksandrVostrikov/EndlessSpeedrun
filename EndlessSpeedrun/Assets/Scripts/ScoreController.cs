using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    private int _seeds;

    public void AddSeeds(int value)
    {
        _seeds += value;
        _score.text = _seeds.ToString();
    }

    public int Score
    {
        get { return _seeds; }
    }



}
