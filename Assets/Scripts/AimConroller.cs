using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimConroller : MonoBehaviour
{
    // 따라다닐 에임 이미지
    [SerializeField] RawImage aimImage;

    private void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        aimImage.transform.position = mousePosition;
    }
}
