using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ConsultaSinesp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserir placa aqui: ");
            var placa = Console.ReadLine();

            DebitosVeiculo debito = new DebitosVeiculo();
            ConsultarPlaca consultarPlaca = new ConsultarPlaca();

            XDocument doc = XDocument.Parse(consultarPlaca.Consultar(placa));
            XNamespace ns = "http://soap.ws.placa.service.sinesp.serpro.gov.br/";

            IEnumerable<XElement> responses = doc.Descendants("return");

            foreach (XElement response in responses)
            {
                debito.mensagemRetorno = (string)response.Element("mensagemRetorno");
                debito.codigoSituacao = (string)response.Element("codigoSituacao");
                debito.codigoRetorno = (string)response.Element("codigoRetorno");
                debito.situacao = (string)response.Element("situacao");
                debito.modelo = (string)response.Element("modelo");
                debito.marca = (string)response.Element("marca");
                debito.cor = (string)response.Element("cor");
                debito.ano = (string)response.Element("ano");
                debito.anoModelo = (string)response.Element("anoModelo");
                debito.placa = (string)response.Element("placa");
                debito.chassi = (string)response.Element("chassi");
                debito.uf = (string)response.Element("uf");
                debito.municipio = (string)response.Element("municipio");
                debito.dataDaConsulta = (string)response.Element("data");

                debito.dataAtualizacaoCaracteristicasVeiculo = (string)response.Element("dataAtualizacaoCaracteristicasVeiculo");
                debito.dataAtualizacaoRouboFurto = (string)response.Element("dataAtualizacaoRouboFurto");
                debito.dataAtualizacaoAlarme = (string)response.Element("dataAtualizacaoAlarme");

            }

            
            //retono a mensaguem 
            Console.WriteLine(debito );
            //Console.WriteLine(debito.mensagemRetorno);

            Console.ReadKey();
        }
    }
}
