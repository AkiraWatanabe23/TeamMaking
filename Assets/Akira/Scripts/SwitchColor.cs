using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    [SerializeField] private GameObject _startImage = default;
    [SerializeField] private Sprite _switchSprite = default;

    private void Start()
    {
        
    }

    private void Update()
    {
        //Gimmickクリアしたら、画像を差し替える
        //以下テスト
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _startImage.GetComponent<SpriteRenderer>().sprite = _switchSprite;
        }
    }
}
