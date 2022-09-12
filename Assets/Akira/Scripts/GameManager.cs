using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("�I�u�W�F�N�g�̉�]1"), SerializeField] public Transform _rotateOne;
    [Tooltip("�I�u�W�F�N�g�̉�]2"), SerializeField] public Transform _rotateTwo;
    [Tooltip("�I�u�W�F�N�g�̉�]3"), SerializeField] public Transform _rotateThree;
    [Tooltip("�I�u�W�F�N�g�̉�]4"), SerializeField] public Transform _rotateFour;
    [SerializeField] Image _clear;

    // Start is called before the first frame update
    void Start()
    {
        _clear.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //�S�ẴI�u�W�F�N�g����������������N���A...Clear()�����s
        if (_rotateOne.transform.rotation == Quaternion.Euler(0, 0, -135))
        {
            if (_rotateTwo.transform.rotation == Quaternion.Euler(0, 0, -135))
            {
                if (_rotateThree.transform.rotation == Quaternion.Euler(0, 0, -45))
                {
                    if (_rotateFour.transform.rotation == Quaternion.Euler(0, 0, 135))
                    {
                        Clear();
                    }
                }
            }
        }
    }

    void Clear()
    {
        _clear.gameObject.SetActive(true);
        //SceneManager.LoadScene("Result");
    }
}
