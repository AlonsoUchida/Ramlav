public class AlmacenResult
{
    public int AlmID {get; set;}
    public string AlmDescripcion { get; set; }
    public string AlmDireccion { get; set; }
    public string InfoAlmacen { get; set; }
    public decimal[] LatLong { get; set; }
}

public class Almacen
{
    public int AlmID { get; set; }
    public string AlmDescripcion { get; set; }
    public string AlmDireccion { get; set; }
    public string AlmLatitud { get; set; }
    public string AlmLongitud { get; set; }
}
