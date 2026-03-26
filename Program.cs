using System;

class Producto
{
    private string nombre;
    private string codigo;
    private double precio;
    private int cantidad;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Codigo { get => codigo; set => codigo = value; }
    public double Precio { get => precio; set => precio = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }

    public Producto(string nombre, string codigo, double precio, int cantidad)
    {
        this.nombre = nombre;
        this.codigo = codigo;
        this.precio = precio;
        this.cantidad = cantidad;
    }

    public virtual double CalcularImpuesto()
    {
        return 0;
    }

    public void MostrarProducto()
    {
        Console.WriteLine("Producto: " + nombre);
        Console.WriteLine("Codigo: " + codigo);
        Console.WriteLine("Precio: " + precio);
        Console.WriteLine("Cantidad: " + cantidad);
    }
}

class ProductoElectronico : Producto
{
    public int GarantiaMeses { get; set; }

    public ProductoElectronico(string nombre, string codigo, double precio, int cantidad, int garantia)
        : base(nombre, codigo, precio, cantidad)
    {
        GarantiaMeses = garantia;
    }

    public override double CalcularImpuesto()
    {
        return Precio * 0.18;
    }
}

class ProductoAlimento : Producto
{
    public string FechaVencimiento { get; set; }

    public ProductoAlimento(string nombre, string codigo, double precio, int cantidad, string fecha)
        : base(nombre, codigo, precio, cantidad)
    {
        FechaVencimiento = fecha;
    }

    public override double CalcularImpuesto()
    {
        return Precio * 0.08;
    }
}

class Program
{
    static void Main()
    {
        ProductoElectronico laptop = new ProductoElectronico("Laptop", "P1001", 45000, 5, 12);
        ProductoAlimento leche = new ProductoAlimento("Leche", "A2001", 80, 20, "10/12/2026");

        laptop.MostrarProducto();
        Console.WriteLine("Garantia: " + laptop.GarantiaMeses + " meses");
        Console.WriteLine("Impuesto: " + laptop.CalcularImpuesto());

        Console.WriteLine();

        leche.MostrarProducto();
        Console.WriteLine("Vence: " + leche.FechaVencimiento);
        Console.WriteLine("Impuesto: " + leche.CalcularImpuesto());
    }
}