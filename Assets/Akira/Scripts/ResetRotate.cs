using UnityEngine;

public class ResetRotate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rotate = GameObject.Find("GimmickObjects");
        rotate.GetComponent<RotateGimmick>().RotateReset();
    }
}
