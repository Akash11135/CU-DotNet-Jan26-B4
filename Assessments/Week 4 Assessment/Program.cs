namespace Week_4_Assessment
{
    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; } = 1000.00m;

        public Patient(string name)
        {
            Name = name;
        }

        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }

    class InPatient : Patient
    {
        public int DaysSpent { get; set; }
        public decimal DailyRate { get; set; }

        public InPatient(string name, int daysSpent, decimal dailyRate)
            : base(name)
        {
            DaysSpent = daysSpent;
            DailyRate = dailyRate;
        }

        public override decimal CalculateFinalBill()
        {
            return BaseFee + (DaysSpent * DailyRate);
        }
    }

    class OutPatient : Patient
    {
        public decimal ProcedureFee { get; set; }

        public OutPatient(string name, decimal procedureFee)
            : base(name)
        {
            ProcedureFee = procedureFee;
        }

        public override decimal CalculateFinalBill()
        {
            return BaseFee + ProcedureFee;
        }
    }

    class EmergencyPatient : Patient
    {
        private int severityLevel;

        public int SeverityLevel
        {
            get { return severityLevel; }
            set
            {
               
                severityLevel = (value >= 1 && value <= 5) ? value : 1;
            }
        }

        public EmergencyPatient(string name, int severityLevel)
            : base(name)
        {
            SeverityLevel = severityLevel;
        }

        public override decimal CalculateFinalBill()
        {
            return BaseFee * SeverityLevel;
        }
    }

    class HospitalBilling
    {
        private List<Patient> PatientsRecord = new List<Patient>();

        public void AddPatient(Patient patient)
        {
            PatientsRecord.Add(patient);
        }

        public int GetPatientCount()
        {
            return PatientsRecord.Count;
        }

        public decimal CalculateTotalRevenue()
        {
            decimal totalRevenue = 0;
            foreach (Patient patient in PatientsRecord)
            {
                totalRevenue += patient.CalculateFinalBill();
            }
            return totalRevenue;
        }

        public void GenerateDailyReport()
        {
            Console.WriteLine("-------------------- DAILY REPORT --------------------");
            foreach (Patient patient in PatientsRecord)
            {
                Console.WriteLine(
                    $"Name : {patient.Name,-10} | Final Bill : ${patient.CalculateFinalBill().ToString("N2")}"
                );
            }
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"Total Patient Count     : {GetPatientCount()}");
            Console.WriteLine($"Total Revenue Generated : ${CalculateTotalRevenue().ToString("N2")}");
            Console.WriteLine("------------------------------------------------------");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalBilling bill = new HospitalBilling();

            bill.AddPatient(new InPatient("Akash", 3, 2000));
            bill.AddPatient(new OutPatient("Piyush", 3000));
            bill.AddPatient(new EmergencyPatient("Yash", 2));   
            bill.AddPatient(new EmergencyPatient("Ravi", 7));   

            bill.GenerateDailyReport();
        }
    }
}
