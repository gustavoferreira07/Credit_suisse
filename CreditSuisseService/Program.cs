using CreditSuisseBusiness.Category;
using CreditSuisseBusiness.Interfaces;
using CreditSuisseBusiness.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CreditSuisseService
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceColletcion = new ServiceCollection();
            ConfigureServices(serviceColletcion);
            var serviceProvider = serviceColletcion.BuildServiceProvider();

            var serviceTrade = serviceProvider.GetServices<ITrade>();

           
                List<TradeModel> listaTransacoes = new List<TradeModel>();
                Console.WriteLine("** Credit Suisse Service **");
                Console.WriteLine("Data referência(Mês/Dia/Ano):");
                var referenceData = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                Console.WriteLine("Informe o número de negócios:");
                int businessCount = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Informe em sequência os seguintes dados: Valor transação, o setor do cliente e a data do próximo pagamento pendente(Mês/Dia/Ano). Respectivamento separados por Espaço");

                for (int i = 0; i < businessCount; i++)
                {                
                    string entrada = Console.ReadLine();
                    listaTransacoes.Add(StringToObject(entrada));                   
                }
               
                foreach(var transacao in listaTransacoes)
                {
                    foreach (var trade in serviceTrade)
                    {
                        var retorno = trade.ClassificateTrade(transacao);
                        if (retorno != null)
                        {
                            Console.WriteLine(retorno);
                            break;
                        } 

                    }
                }

            TradeModel StringToObject(string entrada)
            {
                var entradas = entrada.Split(" ");
                return
                    new TradeModel
                    {
                        Value = Double.Parse(entradas[0]),
                        ClientSector = entradas[1],
                        NextPaymentDate = DateTime.ParseExact(entradas[2], "MM/dd/yyyy", CultureInfo.InvariantCulture),
                        ReferenceDate = referenceData
                    };
            }
        }

       public static void ConfigureServices(IServiceCollection services)
       {
            services.AddScoped<ITrade, ExpiredCategory>()
                    .AddScoped<ITrade, MediumRiskCategory>()
                    .AddScoped<ITrade, HighRiskCategory>();

       }
        
    }
}
