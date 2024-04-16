using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingLivesText_Test : MonoBehaviour
{
    [SerializeField] private Text _remainingLiveText;

    private GameObject _remainingLivesManager;
    private RemainingLivesManager _rLManager;

    // Start is called before the first frame update
    void Start()
    {
        //_remainingLivesManager = GameObject.Find("Player");
        //_rLManager = _remainingLivesManager.GetComponent<RemainingLivesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //publicでstaticな変数を読み込み
        _remainingLiveText.text = RemainingLivesManager._remainingLivesValue.ToString();
        //DontDestroyOnLoad(gameObject)の呼び出し(ボツ)
        //_remainingLiveText.text = _rLManager.GetRemainingLives().ToString();
    }
}
