using UnityEngine;

public interface ILumiObserver
{
    void OnLifeChange(int value);
    void OnFragmentCount(int value);
    void OnPowerUp(string value);
}
