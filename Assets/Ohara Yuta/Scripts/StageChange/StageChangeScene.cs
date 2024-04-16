using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageChangeScene : MonoBehaviour
{
    [SerializeField] StageManagerScript _stageManagerScript;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _backGround;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_stageManagerScript.GetNowStageNumber())
        {
            case 4:
                _image.sprite = _backGround[0];
                break;

            case 5:
                _image.sprite = _backGround[1];
                break;

            case 6:
                _image.sprite = _backGround[2];
                break;

            case 7:
                _image.sprite = _backGround[3];
                break;

            case 8:
                _image.sprite = _backGround[4];
                break;

            default:
                break;
        }
    }
}
