﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalWSR
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WSR2024Entities : DbContext
    {
        public WSR2024Entities()
            : base("name=WSR2024Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Diagnosi> Diagnosis { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Hospitalization> Hospitalizations { get; set; }
        public virtual DbSet<MedicalCard> MedicalCards { get; set; }
        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<SNIL> SNILS { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<TreatmentType> TreatmentTypes { get; set; }
    }
}