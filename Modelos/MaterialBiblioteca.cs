namespace IPC2S1.Modelos

{
    public abstract class MaterialBiblioteca
    {
        private string titulo;
        private string autor;
        private string codigo;
        private bool prestado;

        public string Titulo => titulo;
        public string Autor => autor;
        public string Codigo => codigo;
        public bool Prestado => prestado;

        public MaterialBiblioteca(string titulo, string autor, string codigo)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.codigo = codigo;
            this.prestado = false;
        }

        public virtual void Prestar()
        {
            if (!prestado)
            {
                prestado = true;
                Console.WriteLine("Material prestado.");
            }
            else
                Console.WriteLine("Ya está prestado.");
        }

        public virtual void Devolver()
        {
            if (prestado)
            {
                prestado = false;
                Console.WriteLine("Material devuelto.");
            }
            else
                Console.WriteLine("No estaba prestado.");
        }

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Código: {codigo}");
            Console.WriteLine($"Título: {titulo}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Estado: {(prestado ? "Prestado" : "Disponible")}");
        }
    }
}
