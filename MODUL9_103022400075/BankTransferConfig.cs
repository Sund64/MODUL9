using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace MODUL9_103022400075
{
    public class NilDef
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public List<string> methods { get; set; }
        public Confirmation confirmation { get; set; }
        public NilDef() { }

    }
    public class Transfer
    {
        public double threshold { get; set; }
        public double low_fee { get; set; }
        public double high_fee { get; set; }
        public Transfer() { }
        public Transfer(double threshold, double low_fee, double high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }
    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
        public Confirmation() { }
        public Confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }
    public class BankTransferConfig
    {
        public NilDef config;

        public string lang { get; private set; }
        public object transfer { get; private set; }

        public static BankTransferConfig LoadConfig()
        {
            string jsonString = File.ReadAllText("bank_transfer_config");
            return JsonSerializer.Deserialize<BankTransferConfig>(jsonString);
        }

        private void SetDefault()
        {
            NilDef config = new NilDef();
            Transfer transfer = new Transfer();
            Confirmation confirmation = new Confirmation();
            config.lang = "en";
            transfer.threshold = 25000000;
            transfer.low_fee = 6500;
            transfer.high_fee = 15000;
            config.methods = ["RTO (real-time)", "SKN", "RTGS", "BI FAST"];
            confirmation.en = "yes";
            confirmation.id = "ya";
        }
    public void logiclang()
        {
            double x = 0;
            double biayatransfer = 0;
            double totalbiaya = 0;
            Transfer transfer = new Transfer();
            if (lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
                x = Console.Read();
                if (x < transfer.threshold)
                {
                    biayatransfer = transfer.low_fee;
                    totalbiaya = transfer.low_fee + x;
                    Console.WriteLine("Transfer fee :" + biayatransfer + ", total amount : " + totalbiaya);
                } else
                {
                    biayatransfer = transfer.high_fee;
                    totalbiaya = transfer.high_fee + x;
                    Console.WriteLine("Transfer fee :" + biayatransfer + ", total amount : " + totalbiaya);
                }
            }
            else if (lang == "id")
            {
                Console.WriteLine("Masuka jumlah uang yang akan ditransfer:");
                x = Console.Read();  
                if (x < transfer.threshold)
                {
                    biayatransfer = transfer.low_fee;
                    totalbiaya = transfer.high_fee + x;
                    Console.WriteLine("Biaya transfer :" + biayatransfer + ", total biaya : " + totalbiaya);
                }
                else
                {
                    biayatransfer = transfer.high_fee;
                    totalbiaya = transfer.high_fee + x;
                    Console.WriteLine("Biaya transfer :" + biayatransfer + ", total biaya : " + totalbiaya);
                }
            }

        }
    }
}