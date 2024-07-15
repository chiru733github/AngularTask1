namespace HMS.Model.Entity
{
    public class PatientBill
    {
        public int Bill_No { get; set; }
        public DateTime Bill_Date { get; set; }
        public string Patient_Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Email_Id { get; set; }
        public string Mobile_No { get; set; }
    }
}
