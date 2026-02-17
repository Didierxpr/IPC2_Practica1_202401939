namespace IPC2S1.Modelos

{
    public class LibroDigital : MaterialBiblioteca
    {
        private double tamanoMB;

        public LibroDigital(string titulo, string autor, string codigo, double tamanoMB)
            : base(titulo, autor, codigo)
        {
            this.tamanoMB = tamanoMB;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine("Tipo: Libro Digital");
            Console.WriteLine($"Tamaño: {tamanoMB} MB");
            Console.WriteLine("Máx préstamo: 3 días");
        }
    }
}
