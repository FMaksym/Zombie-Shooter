using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPanel : MonoBehaviour
{
    public TMPro.TMP_Text _bulletText;
    public TMPro.TMP_Text _clipSize;
    public TMPro.TMP_Text _gunName;

    public void RefreshAmountBulletText(int amountCount)
    {
        _bulletText.text = amountCount.ToString();
    }

    public void SetClipSizeText(int clipSize)
    {
        _clipSize.text = clipSize.ToString();
    }
    public void SetNameOfGunText(string gunName)
    {
        _gunName.text = gunName;
    }
}
