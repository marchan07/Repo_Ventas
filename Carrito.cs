using System;
using System.Collections.Generic;
using System.Linq;

public class Carrito
{
    public List<CarritoItem> Items { get; private set; }

    public Carrito()
    {
        Items = new List<CarritoItem>();
    }

    // Agrega un ítem al carrito
    public void AgregarItem(CarritoItem item)
    {
        var existingItem = Items.FirstOrDefault(i => i.ProductoId == item.ProductoId);

        if (existingItem != null)
        {
            existingItem.Cantidad += item.Cantidad;
        }
        else
        {
            Items.Add(item);
        }
    }

    // Elimina un ítem del carrito
    public void EliminarItem(int productoId)
    {
        var item = Items.FirstOrDefault(i => i.ProductoId == productoId);
        if (item != null)
        {
            Items.Remove(item);
        }
    }

    // Calcula el total del carrito
    public decimal CalcularTotal()
    {
        return Items.Sum(i => i.Cantidad * i.PrecioUnitario);
    }

    // Vacía el carrito
    public void VaciarCarrito()
    {
        Items.Clear();
    }
}

public class CarritoItem
{
    public int ProductoId { get; set; }
    public string NombreProducto { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
}
