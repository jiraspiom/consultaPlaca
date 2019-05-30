namespace ConsultaSinesp
{
    public class DebitosVeiculo
    {
        
        public string codigoRetorno { get; set; }
        public string mensagemRetorno { get; set; }
        public string codigoSituacao { get; set; }
        public string situacao { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public string cor { get; set; }
        public string ano { get; set; }
        public string anoModelo { get; set; }
        public string placa { get; set; }
        public string chassi { get; set; }
        public string uf { get; set; }
        public string municipio { get; set; }
        public string dataDaConsulta { get; set; }
        public string dataAtualizacaoCaracteristicasVeiculo { get; set; }
        public string dataAtualizacaoRouboFurto { get; set; }
        public string dataAtualizacaoAlarme { get; set; }

        public override string ToString()
        {
            return 
                  "--------------------------------------------------------" + "\n\r"
                + "Situação : " + situacao + "\r\n"
                + "Veiculo: " + modelo + " - " + ano + "/" + anoModelo + " - cor: " + cor + "\r\n"
                + "cidade: " + municipio + "/" + uf + "\r\n"
                + "Chassi final: " + chassi + "\r\n"
                + "\n\r"
                + "--------------------------------------------------------" + "\n\r"
                + "Cunsulta realizada em " + dataDaConsulta + "\n\r"
                + "--------------------------------------------------------" + "\n\r"
                + "Data da extração de dados do DENATRAN:" + "\n\r"
                + "RENAVAN: " + dataAtualizacaoCaracteristicasVeiculo +"\n\r"
                + "RESTRIÇÃO: " + dataAtualizacaoRouboFurto + "\n\r"
                + "ALERTA: " + dataAtualizacaoAlarme + "\n\r"
                + "--------------------------------------------------------" + "\n\r"; 




    //        return Id + ", "
    //+ Nome + ", "
    //+ Valor.ToString("F2", CultureInfo.InvariantCulture) + ", "
    //+ Categoria.Nome + ", "
    //+ Categoria.Classificacao;


            //            print("restricao : " + situacao
            //print("placa     : " + resultado.get('plate'))
            //print("chassis   : " + resultado.get('chassis'))
            //print("modelo    : " + resultado.get('model'))
            //print("marca     : " + resultado.get('brand'))
            //print("cor       : " + resultado.get('color'))
            //print("ano/modelo: " + resultado.get('year') + "/" + resultado.get('model_year'))
            //print("cidade    : " + resultado.get('city') + " - " + resultado.get('state'))
            //print("data da consulta: " + resultado.get('date'))

            //print("=========================================================")
            //print("codigo: " + codigoRetorno + " resultado: " + resultado.get('return_message') + " status: " + resultado.get('status_code'))
            //print("=========================================================")


        }

    }

}
