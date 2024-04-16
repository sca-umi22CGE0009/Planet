using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveNextStage : MonoBehaviour
{
    [SerializeField] private float _changeTime = 4.0f;
    GameObject _stageManager;
    [SerializeField] StageManagerScript _stageManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoMainScean());
    }

    IEnumerator GoMainScean()
    {
        yield return new WaitForSeconds(_changeTime);
        SceneManager.LoadScene("RemainingLivesCheck");
    }
}
