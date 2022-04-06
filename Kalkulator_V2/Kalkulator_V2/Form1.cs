using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator_V2
{
    public partial class Kalkulator : Form
    {
        public Kalkulator()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        string PierwszaLiczba ,DrugaLiczba;
        string działanie = "";
        int index = 0;
        string wykładnik = "";
        string symbol = "",pom;
        bool klik = false;
        Potęgi pot = new Potęgi();

        private void Clk_Click(object sender, EventArgs e)
        {
            Button Clk = (Button)sender;
            Window.Text = Window.Text + Clk.Text;
            if (działanie == "")
                PierwszaLiczba = Window.Text;
            else
                DrugaLiczba += Clk.Text;

            if (klik)
            {
                index = Window.Text.IndexOf(symbol);
                if (działanie == "")
                {
                    wykładnik = "";
                    var wyk = from n in Window.Text.Substring(index)
                              where Char.IsDigit(n)
                              select n;
                    foreach (var item in wyk)
                    {
                        wykładnik += item;
                    }
                }
                else
                {
                    wykładnik = "";                    
                    var wyk = from n in Window.Text.Substring(index)
                              where Char.IsDigit(n)
                              select n;
                    foreach (var item in wyk)
                    {
                        wykładnik += item;
                    }                   
                }
                klik = false;
            }
        }

        private void Clk_OP_Click(object sender, EventArgs e)
        {
            Button Clk_Op = (Button)sender;
            if(działanie == "")
            {
                Window.Text = Window.Text + Clk_Op.Text;
                działanie = Clk_Op.Text;
            }

            if (symbol != "")
            {
                Window.Clear();
                PierwszaLiczba = pot.Potęga(double.Parse(pom), double.Parse(wykładnik)).ToString();
                Window.Text = PierwszaLiczba + Clk_Op.Text;
            }     
        }

        private void Clk_Rw_Click(object sender, EventArgs e)
        {
            if (symbol != "")
            {
                if (wykładnik != "")
                {
                    if (działanie == "")
                    {
                        PierwszaLiczba = pot.Potęga(double.Parse(pom), double.Parse(wykładnik)).ToString();
                        Window.Clear();
                        Window.Text = PierwszaLiczba;
                    }
                    else
                    {
                        DrugaLiczba = pot.Potęga(double.Parse(pom), double.Parse(wykładnik)).ToString();
                    }
                }
            }

            if (działanie != "")
            {
                Działania wynik = new Działania(double.Parse(PierwszaLiczba), double.Parse(DrugaLiczba));

                Window.Clear();
                Window.Text = wynik.Operacja(działanie).ToString();
                PierwszaLiczba = Window.Text;
                DrugaLiczba = "";
                działanie = "";
            }                       
        }

        private void Clk_Prz_Click(object sender, EventArgs e)
        {
            Button Clk_Prz = (Button)sender;
            
                if (działanie == "")
                {
                    if(!PierwszaLiczba.Contains(","))
                    {
                        Window.Text += Clk_Prz.Text;
                        PierwszaLiczba = Window.Text;
                    }                    
                }
                else
                {
                    if(!DrugaLiczba.Contains(","))
                    {
                        Window.Text += Clk_Prz.Text;
                        DrugaLiczba = DrugaLiczba + Clk_Prz.Text;
                    } 
                }           
        }

        private void Clk_C_Click(object sender, EventArgs e)
        {
            Window.Clear();
            PierwszaLiczba = "";
            DrugaLiczba = "";
            działanie = "";
            pom = "";
        }

        private void BackSp_Click(object sender, EventArgs e)
        {
            BckSp zn = new BckSp();
            int ind = 0;
            Window.Text = zn.UsuńZnak(Window.Text);
            if (działanie == "")
                PierwszaLiczba = Window.Text;
            else
            {
                ind = Window.Text.IndexOf(działanie);
                DrugaLiczba = Window.Text.Substring(ind+1);
            }
                

            if (Window.Text.IndexOf(działanie) < 0)
                działanie = "";
            if (Window.Text.IndexOf(PierwszaLiczba) < 0)
                PierwszaLiczba = "";
            if(działanie != "")
                if (ind < 0)
                     DrugaLiczba = "";
            klik = true;

            if (Window.Text == "")
            {
                PierwszaLiczba = "";
                DrugaLiczba = "";
                działanie = "";
            }
        }

        private void Kwadrat_Click(object sender, EventArgs e)
        {
            Kwadrat_Liczby kw;

            if (działanie == "")
            {
                kw = new Kwadrat_Liczby(double.Parse(PierwszaLiczba));
                PierwszaLiczba = kw.kwadrat.ToString();
                Window.Text = PierwszaLiczba;
            }               
            else
            {
                index = Window.Text.IndexOf(działanie);
                Window.Text = Window.Text.Remove(index + 1);
                kw = new Kwadrat_Liczby(double.Parse(DrugaLiczba));
                DrugaLiczba = kw.kwadrat.ToString();
                Window.Text = Window.Text + DrugaLiczba;
            }              
        }

        private void Potęga_Click(object sender, EventArgs e)
        {
            Button Potęga_Clk = (Button)sender;
            klik = true;
            symbol = Potęga_Clk.Text;
            if(działanie == "")
            {
                pom = PierwszaLiczba;
                Window.Text = PierwszaLiczba + Potęga_Clk.Text;
            }
            else
            {
                pom = DrugaLiczba;
                index = Window.Text.IndexOf(działanie);
                Window.Text = Window.Text.Remove(index + 1);
                Window.Text += DrugaLiczba + Potęga_Clk.Text;
            }  
        }

        private void Clk_Pr_Click(object sender, EventArgs e)
        {
            Procenty pr;

            if (działanie == "")
            {
                pr = new Procenty(double.Parse(PierwszaLiczba));
                PierwszaLiczba = pr.Procent.ToString();
                Window.Text = PierwszaLiczba;
            }
            else
            {
                index = Window.Text.IndexOf(działanie);
                Window.Text = Window.Text.Remove(index + 1);
                pr = new Procenty(double.Parse(DrugaLiczba));
                DrugaLiczba = pr.Procent.ToString();
                Window.Text = Window.Text + DrugaLiczba;
            }
        }      
    }
}
