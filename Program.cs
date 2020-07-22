using modulo1.Dto;
using modulo1.Service;
using System;
using System.Collections.Generic;

namespace modulo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome da oportunidade: ");
            string oportunidadeNome = Console.ReadLine();
            Console.Write("Digite o salário da oportunidade: ");
            string oportunidadeSalario = Console.ReadLine();

            OportunidadeService oportunidadeService = new OportunidadeService();

            var oportunidade =  oportunidadeService.Salvar(oportunidadeNome, oportunidadeSalario);

            oportunidade.Candidatos = new List<Candidato>();

            bool existeCandidato = true;

            while (existeCandidato)
            {
                Candidato candidato = new Candidato();
                Console.WriteLine("Digite o nome do candidato: ");
                candidato.Nome = Console.ReadLine();
                if (candidato.Nome != "")
                {
                    Console.WriteLine("Digite o e-mail do candidato: ");
                    candidato.Email = Console.ReadLine();
                    Console.WriteLine("Digite a nota do candidato: ");
                    candidato.Nota = Convert.ToInt32(Console.ReadLine());
                    oportunidade.Candidatos.Add(candidato);
                }
                else
                { 
                    existeCandidato = false;
                }
            }

            Console.WriteLine("Digite o nome do candidato [APROVADO]: ");
            string nomeCandidatoAprovado = Console.ReadLine();

            oportunidade = oportunidadeService.AtribuirCandidatoAprovado(oportunidade, nomeCandidatoAprovado);

            Console.WriteLine($"A oportunidade {oportunidade.Nome} possui o salário no valor de {oportunidade.Salario}");

            if (oportunidade.Candidatos.Count > 0)
            {
                Console.WriteLine("Estes são os candidatos: _______________________");  

                oportunidade.Candidatos.ForEach(c =>
                {
                    if (c.Aprovado)
                        Console.WriteLine($" - {c.Nome} ::: E-mail: {c.Email} ::: Nota: {c.Nota} [APROVADO]");
                    else
                        Console.WriteLine($" - {c.Nome} ::: E-mail: {c.Email} ::: Nota: {c.Nota}");
                });
            }


        }
    }
}
