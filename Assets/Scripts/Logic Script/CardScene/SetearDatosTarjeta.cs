using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetearDatosTarjeta : MonoBehaviour
{
    public InventoryItem tarjetaBlack;
    public InventoryItem tarjetaGold;
    public InventoryItem tarjetaBlue;
    public InventoryItem tarjetaVioleta;
    public InventoryItem tarjetaGreen;

    private void Start()
    {
        this.tarjetaBlack.amount = 0;
        this.tarjetaGold.amount = 0;
        this.tarjetaBlue.amount = 0;
        this.tarjetaVioleta.amount = 0;
        this.tarjetaGreen.amount = 0;
    }
}
