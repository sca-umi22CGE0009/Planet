using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingLivesText : MonoBehaviour
{
    private GameObject _remainingLivesManager;
    private RemainingLivesManager _rLManager;

    [SerializeField] private Text _remainingLives;

    // Start is called before the first frame update
    void Start()
    {
        _remainingLivesManager = GameObject.Find("RemainingLivesManager");
        _rLManager = _remainingLivesManager.GetComponent<RemainingLivesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _remainingLives.text = _rLManager.GetRemainingLives().ToString();
    }
}
