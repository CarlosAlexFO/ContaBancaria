
using System;

namespace Dio.Banco
{
    public class Conta
    {
   
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        public double SaldoTotal { get; set; }
        private TipoConta  TipoConta { get; set; }

        //metodos
        public Conta(string nome, double saldo, double credito, double saldoTotal, TipoConta tipoConta)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.SaldoTotal = saldo + credito;
            this.TipoConta = tipoConta;
        }
  


        public bool Sacar(double valorSaque)
        {
            //validar saldo insuficiente
            if (this.Saldo - valorSaque <(this.Credito * - 1))
            {
               Console.WriteLine("Saldo Insuficiente para saque!");
                return false;
            }

            //this.Saldo = - valorSaque;
            this.Saldo = this.Saldo - valorSaque;
            Console.WriteLine("O Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("O Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencial, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencial))
            {
                contaDestino.Depositar(valorTransferencial);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += " TipoConta: " + this.TipoConta + " | ";
            retorno += " Nome: " + this.Nome + " | ";
            retorno += " Saldo: " + this.Saldo + " | ";
            retorno += " Credito: " + this.Credito + " | ";
            retorno += " Saldo Total: " + this.SaldoTotal;
            return retorno;
        }

    }
}
