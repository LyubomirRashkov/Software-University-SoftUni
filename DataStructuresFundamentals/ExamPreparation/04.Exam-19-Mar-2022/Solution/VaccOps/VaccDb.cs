namespace VaccOps
{
    using Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;
	using System.Linq;

	public class VaccDb : IVaccOps
    {
        private readonly Dictionary<string, Doctor> doctorsByName = new Dictionary<string, Doctor>();

        private readonly Dictionary<string, Patient> patientsByName = new Dictionary<string, Patient>();

        public void AddDoctor(Doctor doctor)
        {
            if (this.doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            this.doctorsByName.Add(doctor.Name, doctor);
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!this.doctorsByName.ContainsKey(doctor.Name)
                || this.patientsByName.ContainsKey(patient.Name))
            {
                throw new ArgumentException();
            }

            this.patientsByName.Add(patient.Name, patient);

            this.patientsByName[patient.Name].Doctor = doctor;

            this.doctorsByName[doctor.Name].Patients.Add(patient);
        }

        public IEnumerable<Doctor> GetDoctors() => this.doctorsByName.Values;

        public IEnumerable<Patient> GetPatients() => this.patientsByName.Values;

        public bool Exist(Doctor doctor) => this.doctorsByName.ContainsKey(doctor.Name);

        public bool Exist(Patient patient) => this.patientsByName.ContainsKey(patient.Name);

        public Doctor RemoveDoctor(string name)
        {
            if (!this.doctorsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            Doctor doctor = this.doctorsByName[name];

            foreach (var patient in doctor.Patients)
            {
                this.patientsByName.Remove(patient.Name);
            }

            this.doctorsByName.Remove(name);

            return doctor;
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            if (!this.doctorsByName.ContainsKey(oldDoctor.Name)
                || !this.doctorsByName.ContainsKey(newDoctor.Name)
                || !this.patientsByName.ContainsKey(patient.Name))
            {
                throw new ArgumentException();
            }

            this.doctorsByName[oldDoctor.Name].Patients.Remove(patient);

            this.doctorsByName[newDoctor.Name].Patients.Add(patient);

            this.patientsByName[patient.Name].Doctor = newDoctor;
        }

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry) 
            => this.doctorsByName.Values
                .Where(d => d.Popularity == populariry);

        public IEnumerable<Patient> GetPatientsByTown(string town) 
            => this.patientsByName.Values
                .Where(p => p.Town == town);

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
            => this.patientsByName.Values
                .Where(p => p.Age >= lo && p.Age <= hi);

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
            => this.doctorsByName.Values
                .OrderByDescending(d => d.Patients.Count)
                .ThenBy(d => d.Name);

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
            => this.patientsByName.Values
                .OrderBy(p => p.Doctor.Popularity)
                .ThenByDescending(p => p.Height)
                .ThenBy(p => p.Age);
    }
}
