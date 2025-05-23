using SenaiKeys.Cusos;
using SenaiKeys.Salas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SenaiKeys.Academicos {
    public class MenuTestes : SalaManager {
        public SalaManager manager;


        public MenuTestes()
        {

            manager = new SalaManager();

            // Adicionando cursos pré-definidos
            manager.Curso.Add(new Curso("Matemática", 1, 0, 0) { Id = 1 });
            manager.Curso.Add(new Curso("História", 2, 0, 0) { Id = 2 });

            // Adicionando turmas pré-definidas
            manager.Turmas.Add(new Turma(101, 1, 0, 0));
            manager.Turmas.Add(new Turma(102, 2, 0, 0));

            // Adicionando salas pré-definidas
            manager.Salas.Add(new Sala(1, true, "Lab 1", 0, 1));
            manager.Salas.Add(new Sala(2, true, "Lab 2", 0, 2));
        }

        public void Exibir()
        {
            bool continuar = true;
            while (continuar) {
                Console.WriteLine("\n=== Menu de Testes Acadêmicos ===");
                Console.WriteLine("1 - Listar Salas");
                Console.WriteLine("2 - Buscar Sala por Chave");
                Console.WriteLine("3 - Editar Associação de Sala");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine()!;

                switch (opcao) {
                    case "1":
                        ListarSalas();
                        break;
                    case "2":
                        BuscarSala();
                        break;
                    case "3":
                        EditarAssociacao();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private void ListarSalas()
        {
            Console.WriteLine("\n--- Salas ---");
            foreach (var sala in manager.ListarSalas()) {
                Console.WriteLine($"Chave: {sala.Chave}, Lab: {sala.Laboratorio}, Curso: {sala.IdCurso}, Docente: {sala.IdDocente}");
            }
        }

        private void BuscarSala()
        {
            Console.Write("Informe a chave da sala: ");
            if (int.TryParse(Console.ReadLine(), out int chave)) {
                var sala = manager.BuscarSalaPorChave(chave);
                if (sala != null) {
                    Console.WriteLine($"Chave: {sala.Chave}, Lab: {sala.Laboratorio}, Curso: {sala.IdCurso}, Docente: {sala.IdDocente}");
                }
                else {
                    Console.WriteLine("Sala não encontrada.");
                }
            }
            else {
                Console.WriteLine("Chave inválida.");
            }
        }

        public void EditarAssociacao()
        {
            Console.Write("Chave da sala: ");
            if (!int.TryParse(Console.ReadLine(), out int chave)) { Console.WriteLine("Chave inválida."); return; }

            Console.Write("Novo IdDocente (ou Enter para manter): ");
            string docenteStr = Console.ReadLine()!;
            int? novoIdDocente = string.IsNullOrWhiteSpace(docenteStr) ? null : int.Parse(docenteStr);

            Console.Write("Novo IdCurso (ou Enter para manter): ");
            string cursoStr = Console.ReadLine()!;
            int? novoIdCurso = string.IsNullOrWhiteSpace(cursoStr) ? null : int.Parse(cursoStr);

            Console.Write("Novo Laboratório (ou Enter para manter): ");
            string novoLaboratorio = Console.ReadLine()!;

            Console.Write("Novo Número da Turma (ou Enter para manter): ");
            string turmaStr = Console.ReadLine()!;
            int? novoNumeroTurma = string.IsNullOrWhiteSpace(turmaStr) ? null : int.Parse(turmaStr);

            manager.EditarAssociacao(chave, novoIdDocente, novoIdCurso, string.IsNullOrWhiteSpace(novoLaboratorio) ? null : novoLaboratorio, novoNumeroTurma);
        }
    }

     //Extensões para facilitar o acesso às listas(pode ser ajustado conforme seu encapsulamento)
    //public partial class SalaManager {
    //    public List<Sala> Salas => salas;
    //    public List<Curso> Cursos => cursos;
    //    public List<Turma> Turmas => turmas;
    //}
}
