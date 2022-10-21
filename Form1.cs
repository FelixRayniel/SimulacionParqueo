using System.Threading.Tasks;
using System.Timers;

namespace PruebaParqueo
{
    public partial class Form1 : Form
    {        
        //12, 303
        public Form1()
        {
            InitializeComponent();
            /*pictureBox1.Location = new Point(1,111);
            pictureBox8.Location = new Point(1, 301);
            pictureBox7.Location = new Point(1, 484);

            pictureBox2.Location = new Point(1454, 27);
            pictureBox3.Location = new Point(1454, 176);
            pictureBox4.Location = new Point(1454, 330);
            pictureBox5.Location = new Point(1454, 486);
            pictureBox6.Location = new Point(1454, 630);
            pictureBox9.Location = new Point(1454, 783);

            button5.Location = new Point(37,542);
            button1.Location = new Point(37, 692);
            label9.Location = new Point(384,628);
            label8.Location = new Point(384, 674);
            label10.Location = new Point(384, 717);

            label1.Location = new Point(1454, 197);
            label2.Location = new Point(1454, 350);
            label3.Location = new Point(1454, 507);
            label4.Location = new Point(1454, 649);
            label11.Location = new Point(1454, 802);*/

        }

        bool[] Parking = {true, true, true, true, true, true, true };
        PictureBox[] CaballoParking = new PictureBox[7];
        public PictureBox Caballo = new PictureBox();
        Random Llegadas = new Random();
        int [] TiempoCaballos = new int[7];
        int[] TiempoTotal = new int[7];

        int TA = 0, TT = 0;
        float MT = 0;

        bool C1 = false, C2 = false, C3 = false, C4 = false, C5 = false;

        string[] Ruta = { @"C:\Carro.png", @"C:\CarroRojo.png", @"C:\CarroAzul.png", @"C:\CarroAmarillo.png" };
        private void button5_Click(object sender, EventArgs e)
        {
            GetCaballo(NuevoCaballo());
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random n1 = new Random();

            if (Parking[0] == false)
            {

                if (TiempoCaballos[0] <= 0)
                {
                    CargarLabel(0);

                    if (CaballoParking[0].Location.X >= 1173)
                    {
                        if (C3 == false)
                        {
                            CaballoParking[0].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            CaballoParking[0].Refresh();
                            C3 = true;
                        }
                        CaballoParking[0].Left = CaballoParking[0].Left - n1.Next(10, 30);
                        
                    }
                    if (CaballoParking[0].Location.X <= 1173 && CaballoParking[0].Location.Y <= 176)
                    {
                        if (C4 == false)
                        {
                            CaballoParking[0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            CaballoParking[0].Refresh();
                            C4 = true;
                        }
                        CaballoParking[0].Top = CaballoParking[0].Top + n1.Next(10, 30);
                    }

                    if (CaballoParking[0].Location.X >= 12 && CaballoParking[0].Location.Y >= 176)
                    {
                        if (C5 == false)
                        {
                            CaballoParking[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            CaballoParking[0].Refresh();
                            C5 = true;
                        }
                        CaballoParking[0].Left = CaballoParking[0].Left - n1.Next(10, 30);

                    }

                    if (CaballoParking[0].Location.X <= 12 && CaballoParking[0].Location.Y >= 176)
                    {
                        CaballoParking[0].Visible = false;
                        Parking[0] = true;
                        TiempoC1.Enabled = false;
                        TA = TA + 1;
                        MT = MT + CalcularTotal(TiempoTotal[0]);
                        TT = TT + TiempoTotal[0];
                        LimpiarLabel();
                        CargarLabelTotales();

                    }
                    
                }
                else
                {
                    C1 = false;
                    C2 = false;
                    C3 = false;
                    C4 = false;
                    C5 = false;
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                }
            }

            if (Parking[0] == true)
            {
                CaballoParking[0] = Caballo;
                CaballoParking[0].BringToFront();

                if (Caballo.Location.X <= 1173)
                {
                    Caballo.Left = Caballo.Left + n1.Next(10, 30);
                }

                if (Caballo.Location.X >= 1173 && Caballo.Location.Y >= 66)
                {
                    //Caballo.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    //Caballo.Refresh();

                    if (C1==false)
                    {
                        Caballo.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        Caballo.Refresh();
                        C1 = true;
                    }
                    Caballo.Top = Caballo.Top - n1.Next(5, 10);

                }

                if (Caballo.Location.X <= 1498 && Caballo.Location.Y <= 66)
                {
                    if (C2 == false)
                    {
                        Caballo.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        Caballo.Refresh();
                        C2 = true;
                    }
                    Caballo.Left = Caballo.Left + n1.Next(5, 10);
                }

                if (Caballo.Location.X >= 1498 && Caballo.Location.Y <= 66)
                {
                    Parking[0] = false;
                    timer1.Enabled = false;
                    C1 = false;
                    C2 = false;
                    C3 = false;
                    C4 = false;
                    C5 = false;

                }
               
                
                if (Parking[0] == false && timer1.Enabled == false)
                {
                    //Thread.Sleep(Llegadas.Next(2000, 50000));
                    if (TiempoC1.Enabled == false)
                    {
                        TiempoCaballos[0] = Llegadas.Next(30, 120);
                        TiempoTotal[0] = TiempoCaballos[0];
                        TiempoC1.Enabled = true;
                    }
                    GetCaballo(NuevoCaballo());
                    timer2.Enabled = true;
                    
                }

            }
            


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random n2 = new Random();

            if (Parking[1] == false)
            {
                if (TiempoCaballos[1] <= 0)
                {
                    CargarLabel(1);

                    if (CaballoParking[1].Location.X >= 1173)
                    {
                        if (C3 == false)
                        {
                            CaballoParking[1].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            CaballoParking[1].Refresh();
                            C3 = true;
                        }
                        CaballoParking[1].Left = CaballoParking[1].Left - n2.Next(10, 30);

                    }
                    if (CaballoParking[1].Location.X <= 1173 && CaballoParking[1].Location.Y >= 176)
                    {
                        if (C4 == false)
                        {
                            CaballoParking[1].Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
                            CaballoParking[1].Refresh();
                            C4 = true;
                        }
               
                        CaballoParking[1].Top = CaballoParking[1].Top - n2.Next(10, 30);
                    }

                    if (CaballoParking[1].Location.X >= 12 && CaballoParking[1].Location.Y <= 176)
                    {
                        if (C5 == false)
                        {
                            CaballoParking[1].Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                            CaballoParking[1].Refresh();
                            C5 = true;
                        }
                        CaballoParking[1].Left = CaballoParking[1].Left - n2.Next(10, 30);

                    }

                    if (CaballoParking[1].Location.X <= 12 && CaballoParking[1].Location.Y <= 176)
                    {
                        CaballoParking[1].Visible = false;
                        Parking[1] = true;
                        TiempoC2.Enabled = false;
                        TA = TA + 1;
                        MT = MT + CalcularTotal(TiempoTotal[1]);
                        TT = TT + TiempoTotal[1];
                        LimpiarLabel();
                        CargarLabelTotales();
                    }

                }
                else
                {
                    timer2.Enabled = false;
                    timer3.Enabled = true;
                    C1 = false;
                    C2 = false;
                    C3 = false;
                    C4 = false;
                    C5 = false;
                }
            }

            if (Parking[1] == true)
            {
                CaballoParking[1] = Caballo;
                CaballoParking[1].BringToFront();

                if (Caballo.Location.X <= 1173)
                {
                    Caballo.Left = Caballo.Left + n2.Next(10, 30);
                }

                if (Caballo.Location.X >= 1173 && Caballo.Location.Y >= 219)
                {
                    if (C1 == false)
                    {
                        Caballo.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        Caballo.Refresh();
                        C1 = true;
                    }
                    Caballo.Top = Caballo.Top - n2.Next(5, 10);
                }

                if (Caballo.Location.X <= 1498 && Caballo.Location.Y <= 219)
                {
                    if (C2 == false)
                    {
                        Caballo.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        Caballo.Refresh();
                        C2 = true;
                    }
                    Caballo.Left = Caballo.Left + n2.Next(5, 10);
                }

                if (Caballo.Location.X >= 1498 && Caballo.Location.Y <= 219)
                {
                    Parking[1] = false;
                    timer2.Enabled = false;
                    C1 = false;
                    C2 = false;
                    C3 = false;
                    C4 = false;
                    C5 = false;
                }

                if (timer2.Enabled == false && Parking[1] == false)
                {
                    //Thread.Sleep(Llegadas.Next(2000, 50000));
                    if (TiempoC2.Enabled == false)
                    {
                        TiempoCaballos[1] = Llegadas.Next(30, 120);
                        TiempoTotal[1] = TiempoCaballos[1];
                        TiempoC2.Enabled = true;
                    }
                    GetCaballo(NuevoCaballo());
                    timer3.Enabled = true;
                }

            }
         
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Random n3 = new Random();

            if (Parking[2] == false)
            {
                if (TiempoCaballos[2] == 0)
                {
                    CargarLabel(2);

                    if (CaballoParking[2].Location.X >= 1173)
                    {
                        if (C3 == false)
                        {
                            CaballoParking[2].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            CaballoParking[2].Refresh();
                            C3 = true;
                        }
                        CaballoParking[2].Left = CaballoParking[2].Left - n3.Next(10, 30);

                    }
                    if (CaballoParking[2].Location.X <= 1173 && CaballoParking[2].Location.Y >= 176)
                    {
                        if (C4 == false)
                        {
                            CaballoParking[2].Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
                            CaballoParking[2].Refresh();
                            C4 = true;
                        }
                        CaballoParking[2].Top = CaballoParking[2].Top - n3.Next(10, 30);
                    }

                    if (CaballoParking[2].Location.X >= 12 && CaballoParking[2].Location.Y <= 176)
                    {
                        if (C5 == false)
                        {
                            CaballoParking[2].Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                            CaballoParking[2].Refresh();
                            C5 = true;
                        }
                        CaballoParking[2].Left = CaballoParking[2].Left - n3.Next(10, 30);
                    }

                    if (CaballoParking[2].Location.X <= 12 && CaballoParking[2].Location.Y <= 176)
                    {
                        
                        CaballoParking[2].Visible = false;
                        Parking[2] = true;
                        TiempoC3.Enabled = false;
                        TA = TA + 1;
                        MT = MT + CalcularTotal(TiempoTotal[2]);
                        TT = TT + TiempoTotal[2];
                        LimpiarLabel();
                        CargarLabelTotales();
                    }
                }
                else
                {
                    C1 = false;
                    C2 = false;
                    C3 = false;
                    C4 = false;
                    C5 = false;
                    timer3.Enabled = false;
                    timer4.Enabled = true;
                }
            }

            if (Parking[2] == true)
            {
                CaballoParking[2] = Caballo;
                CaballoParking[2].BringToFront();

                if (Caballo.Location.X <= 1173)
                {
                    Caballo.Left = Caballo.Left + n3.Next(10, 30);

                }

                if (Caballo.Location.X >= 1173 && Caballo.Location.Y <= 372)
                {
                    if (C1 == false)
                    {
                        Caballo.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        Caballo.Refresh();
                        C1 = true;
                    }
                    Caballo.Top = Caballo.Top + n3.Next(5, 10);
                }

                if (Caballo.Location.X <= 1498 && Caballo.Location.Y >= 372)
                {
                    if (C2 == false)
                    {
                        Caballo.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        Caballo.Refresh();
                        C2 = true;
                    }
                    Caballo.Left = Caballo.Left + n3.Next(5, 10);
                }


                if (Caballo.Location.X >= 1498 && Caballo.Location.Y >= 372)
                {
                    Parking[2] = false;
                    timer3.Enabled = false;
                    C1 = false;
                    C2 = false;
                    C3 = false;
                    C4 = false;
                    C5 = false;
                }

                if (timer3.Enabled == false && Parking[2] == false)
                {
                    //Thread.Sleep(Llegadas.Next(2000, 50000));
                    if (TiempoC3.Enabled == false)
                    {
                        TiempoCaballos[2] = Llegadas.Next(30, 120);
                        TiempoTotal[2] = TiempoCaballos[2];
                        TiempoC3.Enabled = true;
                    }
                    GetCaballo(NuevoCaballo());
                    timer4.Enabled = true;
                }

            }
           
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Random n4 = new Random();

            if (Parking[3] == false)
            {
                if (TiempoCaballos[3] == 0)
                {
                    CargarLabel(3);

                    if (CaballoParking[3].Location.X >= 1173)
                    {
                        if (C3 == false)
                        {
                            CaballoParking[3].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            CaballoParking[3].Refresh();
                            C3 = true;
                        }
                        CaballoParking[3].Left = CaballoParking[3].Left - n4.Next(10, 30);

                    }
                    if (CaballoParking[3].Location.X <= 1173 && CaballoParking[3].Location.Y >= 176)
                    {
                        if (C4 == false)
                        {
                            CaballoParking[3].Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
                            CaballoParking[3].Refresh();
                            C4 = true;
                        }

                        CaballoParking[3].Top = CaballoParking[3].Top - n4.Next(10, 30);
                    }

                    if (CaballoParking[3].Location.X >= 12 && CaballoParking[3].Location.Y <= 176)
                    {
                        if (C5 == false)
                        {
                            CaballoParking[3].Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                            CaballoParking[3].Refresh();
                            C5 = true;
                        }
                        CaballoParking[3].Left = CaballoParking[3].Left - n4.Next(10, 30);

                    }

                    if (CaballoParking[3].Location.X <= 12 && CaballoParking[3].Location.Y <= 176)
                    {
                        CaballoParking[3].Visible = false;
                        Parking[3] = true;
                        TiempoC4.Enabled = false;
                        TA = TA + 1;
                        MT = MT + CalcularTotal(TiempoTotal[3]);
                        TT = TT + TiempoTotal[3];
                        LimpiarLabel();
                        CargarLabelTotales();
                    }
                }
                else
                {
                    C1 = false;
                    C2 = false;
                    C3 = false;
                    C4 = false;
                    C5 = false;
                    timer4.Enabled = false;
                    timer5.Enabled = true;
                }
            }

            if (Parking[3] == true)
            {
                CaballoParking[3] = Caballo;
                CaballoParking[3].BringToFront();

                if (Caballo.Location.X <= 1173)
                {
                    Caballo.Left = Caballo.Left + n4.Next(10, 30);
                }

                if (Caballo.Location.X >= 1173 && Caballo.Location.Y <= 524)
                {
                    if (C1 == false)
                    {
                        Caballo.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        Caballo.Refresh();
                        C1 = true;
                    }
                    Caballo.Top = Caballo.Top + n4.Next(5, 10);
                }

                if (Caballo.Location.X <= 1498 && Caballo.Location.Y >= 524)
                {
                    if (C2 == false)
                    {
                        Caballo.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        Caballo.Refresh();
                        C2 = true;
                    }
                    Caballo.Left = Caballo.Left + n4.Next(5, 10);
                }

                if (Caballo.Location.X >= 1498 && Caballo.Location.Y >= 524)
                {
                    Parking[3] = false;
                    timer4.Enabled = false;
                    C1 = false;
                    C2 = false;
                    C3 = false;
                    C4 = false;
                    C5 = false;
                }

                if (timer4.Enabled == false && Parking[3] == false)
                {
                    //Thread.Sleep(Llegadas.Next(2000, 5000));
                    if (TiempoC4.Enabled == false)
                    {
                        TiempoCaballos[3] = Llegadas.Next(30, 120);
                        TiempoTotal[3] = TiempoCaballos[3];
                        TiempoC4.Enabled = true;
                    }
                    GetCaballo(NuevoCaballo());
                    timer5.Enabled = true;
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            Random n5 = new Random();

            if (Parking[4] == false)
            {
                if (TiempoCaballos[4] == 0)
                {
                    CargarLabel(4);

                    if (CaballoParking[4].Location.X >= 1173)
                    {
                        if (C3 == false)
                        {
                            CaballoParking[4].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            CaballoParking[4].Refresh();
                            C3 = true;
                        }
                        CaballoParking[4].Left = CaballoParking[4].Left - n5.Next(10, 30);

                    }
                    if (CaballoParking[4].Location.X <= 1173 && CaballoParking[4].Location.Y >= 176)
                    {
                        if (C4 == false)
                        {
                            CaballoParking[4].Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
                            CaballoParking[4].Refresh();
                            C4 = true;
                        }

                        CaballoParking[4].Top = CaballoParking[4].Top - n5.Next(10, 30);
                    }

                    if (CaballoParking[4].Location.X >= 12 && CaballoParking[4].Location.Y <= 176)
                    {
                        if (C5 == false)
                        {
                            CaballoParking[4].Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                            CaballoParking[4].Refresh();
                            C5 = true;
                        }
                        CaballoParking[4].Left = CaballoParking[4].Left - n5.Next(10, 30);

                    }

                    if (CaballoParking[4].Location.X <= 12 && CaballoParking[4].Location.Y <= 176)
                    {
                        CaballoParking[4].Visible = false;
                        Parking[4] = true;
                        TiempoC5.Enabled = false;
                        TA = TA + 1;
                        MT = MT + CalcularTotal(TiempoTotal[4]);
                        TT = TT + TiempoTotal[4];
                        LimpiarLabel();
                        CargarLabelTotales();
                    }
                }
                else
                {
                    C1 = false;
                    C2 = false;
                    C3 = false;
                    C4 = false;
                    C5 = false;
                    timer5.Enabled = false;
                    timer1.Enabled = true;
                }
            }

            if (Parking[4] == true)
            {
                CaballoParking[4] = Caballo;
                CaballoParking[4].BringToFront();

                if (Caballo.Location.X <= 1173)
                {
                    Caballo.Left = Caballo.Left + n5.Next(10, 30);
                }

                if (Caballo.Location.X >= 1173 && Caballo.Location.Y <= 672)
                {
                    if (C1 == false)
                    {
                        Caballo.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        Caballo.Refresh();
                        C1 = true;
                    }
                    Caballo.Top = Caballo.Top + n5.Next(5, 10);
                }

                if (Caballo.Location.X <= 1498 && Caballo.Location.Y >= 672)
                {
                    if (C2 == false)
                    {
                        Caballo.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        Caballo.Refresh();
                        C2 = true;
                    }

                    Caballo.Left = Caballo.Left + n5.Next(5, 10);
                }

                if (Caballo.Location.X >= 1498 && Caballo.Location.Y >= 672)
                {
                    C1 = false;
                    C2 = false;
                    C3 = false;
                    C4 = false;
                    C5 = false;
                    Parking[4] = false;
                    timer5.Enabled = false;
                }

                if (timer5.Enabled == false && Parking[4] == false)
                {
                    //Thread.Sleep(Llegadas.Next(2000, 5000));
                    if (TiempoC5.Enabled == false)
                    {
                        TiempoCaballos[4] = Llegadas.Next(30, 120);
                        TiempoTotal[4] = TiempoCaballos[4];
                        TiempoC5.Enabled = true;
                    }
                    GetCaballo(NuevoCaballo());
                    timer1.Enabled = true;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(12, 303);
        }
        public PictureBox NuevoCaballo()
        {
            var imgPictureBox = new PictureBox();
            imgPictureBox.Location = new System.Drawing.Point(12, 361);
            imgPictureBox.Size = new System.Drawing.Size(145, 103);
            imgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            imgPictureBox.Image = Image.FromFile(Ruta[Llegadas.Next(0,4)]);  //ebede532f6f5cf644a3fcf79d14b046c.gif
            Controls.Add(imgPictureBox);
            imgPictureBox.Visible = true;

            return imgPictureBox; 
        }

        public void GetCaballo(PictureBox caballo)
        {
            Caballo = caballo;   
        }

        private void TiempoC1_Tick(object sender, EventArgs e)
        {
            TiempoCaballos[0] = TiempoCaballos[0] - 1;

            if (TiempoCaballos[0] == 0)
            {
                TiempoC1.Stop();
            }
                
            label1.Text = "Tiempo Restante: "+ TiempoCaballos[0] + " Segundos";

            
        }

        private void TiempoC2_Tick(object sender, EventArgs e)
        {
            TiempoCaballos[1] = TiempoCaballos[1] - 1;

            if (TiempoCaballos[1] == 0)
            {
                TiempoC2.Stop();
            }

            label2.Text = "Tiempo Restante: " + TiempoCaballos[1] + " Segundos";

        }

        private void TiempoC3_Tick(object sender, EventArgs e)
        {
            TiempoCaballos[2] = TiempoCaballos[2] - 1;

            if (TiempoCaballos[2] == 0)
            {
                TiempoC3.Stop();
            }

            label3.Text = "Tiempo Restante: " + TiempoCaballos[2] + " Segundos";

        }

        private void TiempoC4_Tick(object sender, EventArgs e)
        {
            TiempoCaballos[3] = TiempoCaballos[3] - 1;

            if (TiempoCaballos[3] == 0)
            {
                TiempoC4.Stop();
            }

            label4.Text = "Tiempo Restante: " + TiempoCaballos[3] + " Segundos";

        }

        public float CalcularTotal(int Tiempo)
        {
            float PXS = 2;

            float Total = PXS * Tiempo;

            return Total;
        }

        public void LimpiarLabel()
        {
            label5.Text = "Salio Parque: 0";
            label6.Text = "Tiempo de Estacionamiento: 0 Segundos";
            label7.Text = "Total Por Servicio: 0 DOP";
        }

        public void CargarLabel(int indice)
        {
            label5.Text = "Salio Parqueo: " + (indice + 1).ToString();
            label6.Text = "Tiempo de Estacionamiento: " + TiempoTotal[indice].ToString() + " Segundos";
            label7.Text = "Total a Pagar: " + CalcularTotal(TiempoTotal[indice]) + " DOP";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            TiempoC1.Enabled = false;
            TiempoC2.Enabled = false;
            TiempoC3.Enabled = false;
            TiempoC4.Enabled = false;
            TiempoC5.Enabled = false;

        }

        private void TiempoC5_Tick(object sender, EventArgs e)
        {
            TiempoCaballos[4] = TiempoCaballos[4] - 1;

            if (TiempoCaballos[4] == 0)
            {
                TiempoC5.Stop();
            }

            label11.Text = "Tiempo Restante: " + TiempoCaballos[4] + " Segundos";
        }

        public void CargarLabelTotales()
        {
            label9.Text = "Total de Autos Atendidos: " + TA.ToString();
            label8.Text = "Total Tiempo Autos Estacionados: " + TT.ToString() + " Segundos";
            label10.Text = "Monto Total Cobrado: " + MT.ToString() + " DOP";
        }

    }
}

