namespace IPC2S1.Modelos

{
    public class LibroFisico : MaterialBiblioteca
    {
        private int numeroEjemplar;

        public LibroFisico(string titulo, string autor, string codigo, int numeroEjemplar)
            : base(titulo, autor, codigo)
        {
            this.numeroEjemplar = numeroEjemplar;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine("Tipo: Libro Físico");
            Console.WriteLine($"Ejemplar: {numeroEjemplar}");
            Console.WriteLine("Máx préstamo: 7 días");
        }
    }
}
