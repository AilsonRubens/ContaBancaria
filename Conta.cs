using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Classes
{
    public abstract class Conta
    {
        public int Numero { get; protected set; }
        public int Agencia { get; protected set; }
        public string Titular { get; protected set; }
        public double Saldo { get; protected set; }
        public DateTime DataAbertura { get; protected set; }



        public Conta(int numero, int agencia, string titular)
        {
            this.Numero = numero;
            this.Agencia = agencia;
            this.Titular = titular;
            this.Saldo = 0;
            DataAbertura = DateTime.Now;
        }

        public Conta()
        {

        }

        public virtual void Saca(double valor)
        {
            bool podeSacar = ((valor <= this.Saldo) && (this.Saldo > 0));
            if (podeSacar)
                this.Saldo -= valor;
            else
                Console.WriteLine("Saldo insuficiente");
        }



        public virtual void Deposita(double valor)
        {
            bool podeSacar = valor > 0;
            if (podeSacar)
                this.Saldo += valor;
            else
            {
                Console.Clear();
                Console.WriteLine("Valor de depósito inválido.");
                Console.ReadLine();
            }
        }



        public virtual void Transfere(Conta destino, double valor)
        {
            bool podeTransferir = ((valor <= this.Saldo) && (this.Saldo > 0));
            if (podeTransferir)
            {
                this.Saldo -= valor;
                destino.Saldo += valor;
                Console.WriteLine("Transferência realizada com sucesso!");
            }
            else
                Console.WriteLine("Não há saldo suficiente.");

        }

    }

}
