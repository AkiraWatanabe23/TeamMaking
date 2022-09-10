using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("オブジェクトの回転1"), SerializeField] public Transform _rotateOne;
    [Tooltip("オブジェクトの回転2"), SerializeField] public Transform _rotateTwo;
    [Tooltip("オブジェクトの回転3"), SerializeField] public Transform _rotateThree;
    [Tooltip("オブジェクトの回転4"), SerializeField] public Transform _rotateFour;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //全てのオブジェクトが内側を向いたらクリア...Clear()を実行
        if (_rotateOne.transform.rotation == Quaternion.Euler(0, 0, -135))
        {
            if (_rotateTwo.transform.rotation == Quaternion.Euler(0, 0, -135))
            {
                if (_rotateThree.transform.rotation == Quaternion.Euler(0, 0, -135))
                {
                    if (_rotateFour.transform.rotation == Quaternion.Euler(0, 0, -135))
                    {
                        Clear();
                    }
                }
            }
        }
    }

    void Clear()
    {
        SceneManager.LoadScene("Result");
    }
}
