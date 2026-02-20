using IPC2S1.Modelos;
using System.Linq;

namespace IPC2S1.Servicios

{
    public class ServicioBiblioteca
    {
        private List<MaterialBiblioteca> materiales = new();
        private HashSet<string> codigos = new();

        public string GenerarCodigo()
        {
            string codigo = GeneradorCodigo.Generar(codigos);
            codigos.Add(codigo);
            return codigo;
        }

        public void Agregar(MaterialBiblioteca material)
        {
            materiales.Add(material);
            Console.WriteLine("Material agregado.");
        }

        public void MostrarTodos()
        {
            if (materiales.Count == 0)
            {
                Console.WriteLine("No hay materiales.");
                return;
            }

            foreach (var m in materiales)
            {
                Console.WriteLine("\n----------------");
                m.MostrarInfo();
            }
        }

        public MaterialBiblioteca? BuscarCodigo(string codigo)
        {
            return materiales.FirstOrDefault(m => m.Codigo == codigo);
        }

        public List<MaterialBiblioteca> BuscarTitulo(string titulo)
{
    return materiales
        .Where(m => m.Titulo.ToLower().Contains(titulo.ToLower()))
        .OrderBy(m => m.Titulo)
        .ToList();
}

        public List<MaterialBiblioteca> ObtenerDisponibles()
{
    return materiales.Where(m => !m.Prestado).ToList();
}

public List<MaterialBiblioteca> ObtenerPrestados()
{
    return materiales.Where(m => m.Prestado).ToList();
}

public int ContarTodos() => materiales.Count;
public int ContarDisponibles() => materiales.Count(m => !m.Prestado);
public int ContarPrestados() => materiales.Count(m => m.Prestado);
    }
}
