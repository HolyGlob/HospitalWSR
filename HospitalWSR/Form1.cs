using HospitalWSR.Templates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalWSR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        HttpClient client = new HttpClient();
        WSR2024Entities context = new WSR2024Entities();

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response =
                    await client.GetAsync("https://api.randomdatatools.ru/?count=50&params=LastName,FirstName,FatherName,Phone,Address,DateOfBirth,Email,Gender,PasportNum,snils");
            List<RandomData> data = JsonConvert.DeserializeObject<List<RandomData>>(await response.Content.ReadAsStringAsync());

            List<Gender> genders = context.Genders.ToList();

            foreach (RandomData randomData in data)
            {
                Patient patient = new Patient();
                patient.FirstName = randomData.FirstName;
                patient.MiddleName = randomData.FatherName;
                patient.LastName = randomData.Lastname;

                if (randomData.Gender == "Мужчина")
                {
                    patient.Gender = genders.Find(x => x.ID == 1);
                }
                else
                {
                    patient.Gender = genders.Find(x => x.ID == 2);
                }

                patient.BirthDate = DateTime.Parse(randomData.DateOfBirth);
                patient.Adress = randomData.Address;
                patient.Phone = randomData.Phone;
                patient.Email = randomData.Email;

                Passport passport = new Passport();
                string[] words = randomData.PasportNum.Split(' ');
                passport.number = words[0];
                passport.series = words[1];
                patient.Passport = passport;

                SNIL snils = new SNIL();
                snils.Number = randomData.snils;
                patient.SNIL = snils;

                MedicalCard card = new MedicalCard();
                card.ReleaseDate = DateTime.Now;
                patient.MedicalCard = card;

                context.Passports.Add(passport);
                context.Patients.Add(patient);
            }

            context.SaveChanges();

            dataGridView1.DataSource = context.Patients.ToList();
        }
    }
}
