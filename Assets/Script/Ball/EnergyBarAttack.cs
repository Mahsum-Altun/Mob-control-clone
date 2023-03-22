using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarAttack : MonoBehaviour
{
    public int maxEnergy;
    public int currentEnergy;
    public EnergyBar energyBar;

    private void TakeEnergy(int energy)
    {
        currentEnergy += energy;
        energyBar.SetEnergy(currentEnergy);
        if (currentEnergy == 100)
        {
            currentEnergy = 0;
        }
    }
    public void EnergyReplenishment()
    {
        TakeEnergy(5);
    }
}
